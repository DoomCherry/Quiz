using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGame.Animation
{
    public class BouncerScaleFadeOut : BouncerScaler
    {
        public override Sequence Bouncing()
        {
            Sequence sequence = base.Bouncing();
            sequence.Append(myTransform.DOScale(Vector3.zero, _timeToBounceSecond));
            return sequence;
        }
    }
}
