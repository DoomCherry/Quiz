using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class QuizVariantAnswer : MonoBehaviour
{
    public bool ThisAnswareIsRight { get; private set; }
    [SerializeField] private UnityEvent _onRightAnsware;
    [SerializeField] private UnityEvent _onWrongAnsware;
    void Start()
    {

    }

    public void SetRightAnsware(Action additionalAction)
    {
        ThisAnswareIsRight = true;
        _onRightAnsware.AddListener( delegate { additionalAction?.Invoke(); });
    }

    public void GetAnsware()
    {
        if(ThisAnswareIsRight)
        {
            _onRightAnsware?.Invoke();
        }
        else
        {
            _onWrongAnsware?.Invoke();
        }
    }
}
