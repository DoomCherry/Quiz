using System.Collections;
using System;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QuizGame
{
    public class Spawner : SerializableMonoBehavior,IInitialisable
    {
        [Serializable]
        public class QuizContainerCollection
        {
            [SerializeField] private CellContainer[] _cellContainers;
            [SerializeField] private string _collectionNameInSingular;

            public CellContainer[] CellContainers => _cellContainers;
            public int CellsCount => CellContainers.Length;
            public string CollectionNameInSingular => _collectionNameInSingular;


        }
        [SerializeField] private QuizContainerCollection[] quizContainerCollection;
        [SerializeField] private ContainerController prefab;
        [SerializeField] private UnityEvent OnInitialize;
        [SerializeField] private UnityEvent OnSpawnEnd;

        public int collectionCount => quizContainerCollection.Length;

        [SerializeField] private int _spawnCount = 3;
        void Start()
        {
            Initialize();
            Spawn();
        }

        public void Spawn()
        {
            DestroyAllChild();
            SpawnCellsWithOnceUnique(UnityEngine.Random.Range(0, collectionCount), _spawnCount);
            Initialize();
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

        private void SpawnCellsWithOnceUnique(int collectionNumber, int count)
        {
            int randomIndexInRangeCollection = UnityEngine.Random.Range(0, quizContainerCollection[collectionNumber].CellsCount);                       // Берем случайный индекс уникальной ячецйки
            CellContainer uniqueCell = quizContainerCollection[collectionNumber].CellContainers[randomIndexInRangeCollection];                          // Ссылка на уникальную ячейку 
            CellContainer[] newContainerCollection = quizContainerCollection[collectionNumber].CellContainers.Where(c => c != uniqueCell).ToArray();    // Коллекция без уникальной ячейки
            int newCollectionCount = newContainerCollection.Length;
            int collectCounParam = Mathf.CeilToInt(((float)(newCollectionCount) / count));                                                              // Модификатор количества повторов коллекции

            CellContainer[] collectForMix = new CellContainer[0];
            for (int i = 0; i < collectCounParam; i++)
            {
                collectForMix = collectForMix.Union(newContainerCollection).ToArray();
            }
            System.Random random = new System.Random();
            collectForMix.Take(count);
            collectForMix[0] = uniqueCell;
            collectForMix = collectForMix.OrderBy(x => random.Next()).ToArray();                                                                        // Рандомная последовательность коллекции с хотя бы одним уникальным элементом


            for (int i = 0; i < count; i++)
            {
                ContainerController exemplar = Instantiate(prefab, myTransform);
                exemplar.SetContainer(collectForMix[i]);
            }
        }
    }
}
