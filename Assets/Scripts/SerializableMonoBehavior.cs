using UnityEngine;
using System.Collections;
using System;

namespace QuizGame
{
    public class SerializableMonoBehavior : MonoBehaviour, IInitialisable
    {
        public Transform myTransform { get; private set; }
        public GameObject myGameObject { get; private set; }
        protected GameObject[] children;

        public virtual void Initialize()
        {
            myTransform = transform;
            myGameObject = gameObject;
            children = new GameObject[myTransform.childCount];
            for (int i = 0; i < myTransform.childCount; i++)
            {
                children[i] = myTransform.GetChild(i).gameObject;
            }
        }

    }
}