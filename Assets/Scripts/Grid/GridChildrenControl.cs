using System.Collections;
using System.Linq;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QuizGame.Grid
{
    [RequireComponent(typeof(GridResolutionFilter))]
    public class GridChildrenControl : SerializableMonoBehavior, IRectable, IActivatror
    {
        /// <summary>
        /// На случай если количество детей сетки будет превышать общую вместимость сетки
        /// примениться один из выбранных методов, который решит проблему остатков.
        /// </summary>
        public enum RemainsInstructions
        {
            OverflowHight = 1,          // Уберет ограничение по высоте
            HideAllRemains = 2,    // Скроет лишние элементы.
        }

        [SerializeField] private int _cellCountInWidth = 3, _cellCountInHight = 3;
        [SerializeField] private Vector2 _cellStep = Vector2.one;
        [SerializeField] private RemainsInstructions remainsAction;
        public int CellCountInWidth => _cellCountInWidth;
        public int CellCountInHight => _cellCountInHight;
        public Cell[] _cellChildren { get; private set; }
        [SerializeField] private UnityEvent OnInitialize;
        private Action OnSorted;
        void Start()
        {
            Initialize();
            SortByGrid();
        }

        public override void Initialize()
        {
            base.Initialize();
            var cellChildren = children.Select(c => c.GetComponent<Cell>());
            _cellChildren = cellChildren.Where(c => c != null).ToArray();
            for (int i = 0; i < _cellChildren.Length; i++)
            {
                _cellChildren[i].Initialize();
            }
            OnInitialize?.Invoke();
        }

        public void SortByGrid()
        {
            Vector2 currentCellPosition = Vector2.zero;
            for (int i = 0; i < _cellChildren.Length; i++)
            {
                _cellChildren[i].myTransform.localPosition = currentCellPosition * _cellStep;
                currentCellPosition.x++;
                if (currentCellPosition.x >= _cellCountInWidth)
                {
                    currentCellPosition.x = 0;
                    currentCellPosition.y++;
                }
            }
            SetRemainsInstruction();
            OnSorted?.Invoke();
        }

        public void SetGridWidth(int width)
        {
            _cellCountInWidth = width;
        }
        public void SetGridHidth(int hight)
        {
            _cellCountInHight = hight;
        }

        private void SetRemainsInstruction()
        {
            for (int i = 0; i < _cellChildren.Length; i++)
            {
                bool isActive = true;
                switch (remainsAction)
                {
                    case RemainsInstructions.HideAllRemains:
                        if (i >= _cellCountInWidth * _cellCountInHight)
                            isActive = false;
                        break;
                }
                _cellChildren[i].SetActivateCell(isActive);
            }
        }

        public Vector2Int GetSize()
        {
            return new Vector2Int(_cellCountInWidth, _cellCountInHight);
        }

        public void OnAction(Action additionalAaction)
        {
            OnSorted += additionalAaction;
        }

        public Vector2 GetPosition()
        {
            return myTransform.localPosition;
        }
    }
}
