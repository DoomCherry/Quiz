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
    public class Bouncer : MonoBehaviour, IInitialisable
    {
        public enum BounceInstruction
        {
            ChangeScale = 0,
            ChangePosition
        }
        [SerializeField] private BounceInstruction bounceInstruction;
        [SerializeField] private float _timeToBounceSecond = 1;
        [SerializeField] private Vector2 _strengthMax = Vector2.one * 2;
        [SerializeField] private Vector2 _strengthMin = Vector2.one * 0.5f;
        private Transform _mytransform;
        private Vector2 _defaultScale, _defaultPosition;
        private Vector2 StrengthMax => _defaultScale * _strengthMax;
        private Vector2 StrengthMin => _defaultScale * _strengthMin;
        void Start()
        {
            Initialize();
        }

        public void Initialize()
        {
            _mytransform = transform;
            _defaultScale = _mytransform.localScale;
            _defaultPosition = _mytransform.localPosition;
        }

        public void Bouncing()
        {
            Func<Vector3, float, TweenerCore<Vector3, Vector3, VectorOptions>> reScale = delegate (Vector3 strength, float time)
              {
                  return _mytransform.DOScale(strength, time);
              };
            Func<Vector3, float, TweenerCore<Vector3, Vector3, VectorOptions>> rePosition = delegate (Vector3 strength, float time)
            {
                return _mytransform.DOMove(strength, time);
            };
            Sequence sequence;
            switch (bounceInstruction)
            {
                case BounceInstruction.ChangeScale:
                    sequence = BouncingWithMetod(reScale);
                    sequence.Append(reScale(_defaultScale,_timeToBounceSecond));
                    break;
                case BounceInstruction.ChangePosition:
                    sequence = BouncingWithMetod(rePosition);
                    sequence.Append(rePosition(_defaultPosition, _timeToBounceSecond));
                    break;
            }

        }

        /// <summary>
        /// Реализует bouncing для плавающего атрибута (позиции, прозрачности, масштаба, итд)
        /// </summary>
        /// <param name="instruction"> DoTween метод исполнитель</param>
        /// <returns>Sequence для продолжения работы, если необходимо</returns>
        private Sequence BouncingWithMetod(Func<Vector3, float, TweenerCore<Vector3, Vector3, VectorOptions>> instruction)
        {
            Sequence sequence = DOTween.Sequence();
            sequence.Append(instruction(StrengthMin, _timeToBounceSecond));
            sequence.Append(instruction(StrengthMax, _timeToBounceSecond));
            return sequence;
        }

    }
}
