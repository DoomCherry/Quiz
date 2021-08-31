using UnityEngine;
using UnityEditor;
using System.Collections;
using System;
using QuizGame;

namespace QuizEditor
{
    public class EditorInitialisableActivator<T> : Editor
        where T: IInitialisable
    {
        private T InitialiliseActivator;
        private void OnEnable()
        {
            InitializeTarget();
        }

        protected T InitializeTarget()
        {
            InitialiliseActivator = (T)(IInitialisable)target;
            InitialiliseActivator.Initialize();
            return InitialiliseActivator;
        }

        protected void TestActivator(string message, Action action)
        {
            if (GUILayout.Button(message))
            {
                action.Invoke();
            }
        }
    }
}