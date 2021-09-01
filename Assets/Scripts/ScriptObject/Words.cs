
using UnityEngine;

namespace QuizGame
{
    [CreateAssetMenu(fileName = "CharContainer", menuName = "QuizContainers/Char")]
    class Words : CellContainer
    {
        [SerializeField] private char _simbol;

        public override string GetAnsware()
        {
            return _simbol.ToString();

        }
    }
}
