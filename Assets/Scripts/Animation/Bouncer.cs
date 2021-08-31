using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Plugins;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace QuizGame.Animation
{
    public class Bouncer : SerializableMonoBehavior, IInitialisable,IActivatror
    {
        public enum BounceInstruction
        {
            ChangeScale = 0,
            ChangePosition
        }
        private Action onBouncingEnd;
        [SerializeField] protected float _timeToBounceSecond = 1;
        [SerializeField] protected Vector2 _strengthMax = Vector2.one * 2;
        [SerializeField] protected Vector2 _strengthMin = Vector2.one * 0.5f;
        
        void Start()
        {
            Initialize();
        }


        /// <summary>
        /// Реализует bouncing для плавающего атрибута (позиции, прозрачности, масштаба, итд)
        /// </summary>
        /// <param name="instruction"> DoTween метод исполнитель</param>
        /// <returns>Sequence для продолжения работы, если необходимо</returns>
        protected Sequence BouncingWithMetod(Func<Vector3, float, TweenerCore<Vector3, Vector3, VectorOptions>> instruction, Vector2 max, Vector2 min)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(instruction(max, _timeToBounceSecond));
            sequence.Append(instruction(min, _timeToBounceSecond));
            sequence.OnComplete(
                delegate { 
                    onBouncingEnd?.Invoke();
                });
            return sequence;
        }

        public void OnAction(Action action)
        {
            onBouncingEnd += action;
        }
    }
}
