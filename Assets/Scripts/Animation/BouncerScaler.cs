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
    public class BouncerScaler : Bouncer, IBounce
    {
        [SerializeField] private Vector2 _defaultScaleInFade;
        private Vector2 StrengthMax =>  _defaultScaleInFade* _strengthMax;
        private Vector2 StrengthMin =>  _defaultScaleInFade* _strengthMin;
        public override void Initialize()
        {
            base.Initialize();
        }


        public void Bouncing()
        {
            Sequence sequence;
            Func<Vector3, float, TweenerCore<Vector3, Vector3, VectorOptions>> reScale = delegate (Vector3 strength, float time)
            {
                return myTransform.DOScale(strength, time);
            };
            sequence = BouncingWithMetod(reScale, StrengthMax, StrengthMin);
            sequence.Append(reScale(_defaultScaleInFade, _timeToBounceSecond));
        }
    }
}
