using UnityEngine;
using System.Collections;
using UnityEngine.Events;
using UnityEngine.UI;
using DG.Tweening;
using DG.Tweening.Plugins;
using DG.Tweening.Core;
using DG.Tweening.Plugins.Options;

namespace QuizGame
{
    public class QuestionGenerator : MonoBehaviour
    {
        [SerializeField] private Spawner _spawner;
        [SerializeField] private Text _questionLog;
        [SerializeField] private UnityEvent _onRightAnsware;
        [SerializeField] private float _delayTimeToSetRightAnsware = 0.5f;

        public void SetQuest()
        {
            _questionLog.text = "Find " + _spawner.UniqueContainer.Cell.GetAnsware();
            _spawner.UniqueContainer.VariantAnswer.SetRightAnsware(delegate
            {
                StartCoroutine(WaitDelayToRightAnsware());
            });
        }

        private IEnumerator WaitDelayToRightAnsware()
        {
            yield return new WaitForSeconds(_delayTimeToSetRightAnsware);
            _onRightAnsware?.Invoke();
        }
    }
}
