using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuizVariantAnswer : MonoBehaviour
{
    public bool thisAnswareIsRight { get; private set; }
    [SerializeField] private UnityEvent OnRightAnsware;
    [SerializeField] private UnityEvent OnWrongAnsware;
    void Start()
    {

    }

    public void GetAnsware()
    {
        if(thisAnswareIsRight)
        {
            OnRightAnsware?.Invoke();
        }
        else
        {
            OnWrongAnsware?.Invoke();
        }
    }
}
