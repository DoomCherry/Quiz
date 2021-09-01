using UnityEngine;
using UnityEditor;

namespace QuizGame
{
    [CreateAssetMenu(fileName = "NumberContainer", menuName = "QuizContainers/Number")]
    public class Number : CellContainer
    {
        [SerializeField]private int _number;

        public override string GetAnsware()
        {
            return _number.ToString();

        }
    }
}