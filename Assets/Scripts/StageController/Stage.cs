using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Events;

namespace QuizGame.StageController
{
    public class Stage : MonoBehaviour
    {
        [SerializeField] protected UnityEvent onAwake;

        public virtual void PlayStage()
        {
            onAwake?.Invoke();
        }

    }
}
