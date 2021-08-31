using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using System;
using DG.Tweening.Plugins;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace QuizGame.Animation
{
    public class BouncerPosition : Bouncer
    {
        private Vector2 _defaultPosition;

        public override void Initialize()
        {
            base.Initialize();
            _defaultPosition = myTransform.localPosition;
        }

        public void Bouncing()
        {
            Sequence sequence;
            Func<Vector3, float, TweenerCore<Vector3, Vector3, VectorOptions>> rePosition = delegate (Vector3 strength, float time)
            {
                return myTransform.DOLocalMove(strength, time);
            };
            sequence = BouncingWithMetod(rePosition, _strengthMax, _strengthMin);
            sequence.Append(rePosition(_defaultPosition, _timeToBounceSecond));
        }
    }
}
