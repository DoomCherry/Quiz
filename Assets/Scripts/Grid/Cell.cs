using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.Grid
{
    public class Cell : MonoBehaviour, IInitialisable
    {
        [SerializeField] private SpriteRenderer sprite;
        public Transform myTransform { get; private set; }


        void Update()
        {

        }

        public void SetActivateCell(bool isActivate)
        {
            sprite.enabled = isActivate;
        }
        public void Initialize()
        {
            myTransform = transform;
        }
    }
}
