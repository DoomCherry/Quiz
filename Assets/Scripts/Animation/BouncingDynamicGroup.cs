using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using DG.Tweening;
using DG.Tweening.Plugins;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;


namespace QuizGame.Animation
{
    public class BouncingDynamicGroup : SerializableMonoBehavior
    {
        [SerializeField] private float delayTime = 0.5f;
        private IBounce[] findingBouncingGroup;

        public void BounceAllFindingGroup()
        {
            FindBouncingElement();
            Sequence sequence = DOTween.Sequence();
            for (int i = 0; i < findingBouncingGroup.Length; i++)
            {
                sequence.AppendCallback(findingBouncingGroup[i].Bouncing);
                sequence.AppendInterval(delayTime);
            }
        }

        private void FindBouncingElement()
        {
            Initialize();
            findingBouncingGroup = children.Select(b => b.GetComponent<IBounce>()).ToArray();
        }
    }
}
