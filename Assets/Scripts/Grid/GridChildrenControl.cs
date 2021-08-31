using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.Grid
{
    public class GridChildrenControl : MonoBehaviour, IInitialisable
    {
        /// <summary>
        /// На случай если количество детей сетки будет превышать общую вместимость сетки
        /// примениться один из выбранных методов, который решит проблему остатков.
        /// </summary>
        public enum RemainsInstructions
        {
            OverflowHight = 1,          // Уберет ограничение по высоте
            ClampAllHideRemains = 2,    // Скроет лишние элементы.
        }

        [SerializeField] private int _cellCountInWidth = 3, _cellCountinHight = 3;
        [SerializeField] private Vector2 _cellStep = Vector2.one;
        [SerializeField] private RemainsInstructions remainsAction;

        private Cell[] _children;
        private Transform _myTransform;
        void Start()
        {
            Initialize();
            SortByGrid();
        }



        public void SortByGrid()
        {
            Vector2 currentCellPosition = Vector2.zero;
            for (int i = 0; i < _children.Length; i++)
            {
                _children[i].myTransform.position = currentCellPosition * _cellStep;
                currentCellPosition.x++;
                if (currentCellPosition.x >= _cellCountInWidth)
                {
                    currentCellPosition.x = 0;
                    currentCellPosition.y++;
                }
            }
            SetRemainsInstruction();
        }

        public void Initialize()
        {
            _myTransform = transform;
            _children = _myTransform.GetComponentsInChildren<Cell>();
            for (int i = 0; i < _children.Length; i++)
            {
                _children[i].Initialize();
            }
        }

        private void SetRemainsInstruction()
        {
            for (int i = 0; i < _children.Length; i++)
            {
                bool isActive = true;
                switch (remainsAction)
                {
                    case RemainsInstructions.ClampAllHideRemains:
                        if (i >= _cellCountInWidth * _cellCountinHight)
                            isActive = false;
                        break;
                }
                _children[i].SetActivateCell(isActive);
            }
        }
    }
}
