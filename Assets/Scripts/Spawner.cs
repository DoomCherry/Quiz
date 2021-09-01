using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QuizGame
{
    public class Spawner : SerializableMonoBehavior, IInitialisable
    {
        [Serializable]
        public class QuizContainerCollection
        {
            [SerializeField] private CellContainer[] _cellContainers;
            public int[] UniqueSequence => _uniqueSequence;

            private int[] _uniqueSequence;
            public void GenerateUniqueSequence()
            {
                if (_uniqueSequence == null)
                {
                    _uniqueSequence = new int[_cellContainers.Length];
                    for (int i = 0; i < _uniqueSequence.Length; i++)
                    {
                        _uniqueSequence[i] = i;
                    }
                    _uniqueSequence = _uniqueSequence.OrderBy(x => UnityEngine.Random.Range(0, 100)).ToArray();
                }
            }
            public CellContainer[] CellContainers => _cellContainers;
            public int CellsCount => CellContainers.Length;

        }
        [SerializeField] private QuizContainerCollection[] quizContainerCollection;
        [SerializeField] private ContainerController prefab;
        [SerializeField] private UnityEvent OnInitialize;
        [SerializeField] private UnityEvent OnSpawnEnd;

        public int CollectionCount => quizContainerCollection.Length;
        public ContainerController UniqueContainer => currentSpawnSequence[_uniqueIndex];

        [SerializeField] private int _spawnCount = 3;
        private int _uniqueIndex;
        private int spawnTry = 0;
        void Start()
        {
            Initialize();
        }

        public void SetSpawnCount(int count)
        {
            _spawnCount = count;
        }

        public void Spawn()
        {
            DestroyAllChild();
            GenerateUniqueSequence();
            SpawnCellsWithOnceUnique(UnityEngine.Random.Range(0, CollectionCount), _spawnCount);
            Initialize();
            spawnTry++;
            OnSpawnEnd?.Invoke();
        }

        public override void Initialize()
        {
            base.Initialize();
            OnInitialize?.Invoke();
        }

        public void DestroyAllChild()
        {
            Initialize();                                    // В случае появления новых объектов
            for (int i = 0; i < children.Length; i++)
            {
                DestroyImmediate(children[i].gameObject);
            }
            Initialize();                                    // Переинициализировать структуру после ее изменения
        }
        public List<ContainerController> currentSpawnSequence { get; private set; } = new List<ContainerController>();
        private void GenerateUniqueSequence()
        {
            for (int i = 0; i < quizContainerCollection.Length; i++)
            {
                quizContainerCollection[i].GenerateUniqueSequence();
            }
        }
        private void SpawnCellsWithOnceUnique(int collectionNumber, int count)
        {
            QuizContainerCollection current = quizContainerCollection[collectionNumber];
            int sequenceSize = current.UniqueSequence.Length;
            int randomIndexInRangeCollection = current.UniqueSequence[spawnTry% sequenceSize];                      // Берем случайный индекс уникальной ячецйки
            CellContainer uniqueCell = current.CellContainers[randomIndexInRangeCollection];                          // Ссылка на уникальную ячейку 
            CellContainer[] newContainerCollection = current.CellContainers.Where(c => c != uniqueCell).ToArray();    // Коллекция без уникальной ячейки
            int newCollectionCount = newContainerCollection.Length;
            int collectCounParam = Mathf.CeilToInt(((float)(newCollectionCount) / count));                            // Модификатор количества повторов коллекции

            CellContainer[] collectForMix = new CellContainer[0];
            for (int i = 0; i < collectCounParam; i++)
            {
                collectForMix = collectForMix.Union(newContainerCollection).ToArray();
            }
            collectForMix = collectForMix.Take(count).ToArray();
            collectForMix = collectForMix.OrderBy(x => UnityEngine.Random.Range(0,100)).ToArray();                               // Рандомная последовательность коллекции с хотя бы одним уникальным элементом
            _uniqueIndex = UnityEngine.Random.Range(0, collectForMix.Length);
            collectForMix[_uniqueIndex] = uniqueCell;

            currentSpawnSequence.Clear();
            for (int i = 0; i < count; i++)
            {
                ContainerController exemplar = Instantiate(prefab, myTransform);
                exemplar.SetContainer(collectForMix[i]);
                currentSpawnSequence.Add(exemplar);
            }
        }
    }
}
