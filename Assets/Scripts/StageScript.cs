using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class StageScript : MonoBehaviour
{
    [SerializeField] private UnityEvent[] allGameStage;
    private int _nextStageIs = 0;
    private int CurrentStage => _nextStageIs - 1;
    void Start()
    {
        NextStage();
    }

    public void NextStage()
    {
        if(_nextStageIs < allGameStage.Length)
        {
            allGameStage[_nextStageIs]?.Invoke();
            _nextStageIs++;
        }
    }

    public void ResetStage()
    {
        _nextStageIs = 0;
        NextStage();
    }
}
