using System.Collections;
using System;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Plugins;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace QuizGame.Animation
{
    public class BouncerScaler : Bouncer
    {
        private Vector2 _defaultScale;
        private Vector2 StrengthMax => _defaultScale * _strengthMax;
        private Vector2 StrengthMin => _defaultScale * _strengthMin;
        public override void Initialize()
        {
            base.Initialize();
            _defaultScale = myTransform.localScale;
        }

        public void Bouncing()
        {
            Sequence sequence;
            Func<Vector3, float, TweenerCore<Vector3, Vector3, VectorOptions>> reScale = delegate (Vector3 strength, float time)
            {
                return myTransform.DOScale(strength, time);
            };
            sequence = BouncingWithMetod(reScale,StrengthMax, StrengthMin);
            sequence.Append(reScale(_defaultScale, _timeToBounceSecond));
        }
    }
}
