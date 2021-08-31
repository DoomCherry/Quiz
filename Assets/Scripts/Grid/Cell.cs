using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.Grid
{
    public class Cell : SerializableMonoBehavior
    {
        public bool IsActive => _isActive;

        private bool _isActive;
        public void SetActivateCell(bool isActivate)
        {
            _isActive = isActivate;
            for (int i = 0; i < children.Length; i++)
            {
                children[i].SetActive(isActivate);
            }
        }
    }
}
