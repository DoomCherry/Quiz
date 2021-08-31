using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace QuizGame.ClickFinder
{
    public class CellButton : MonoBehaviour
    {
        [SerializeField] private UnityEvent OnClick;
        void Start()
        {

        }

        public void Click()
        {
            OnClick?.Invoke();
        }

    }
}
