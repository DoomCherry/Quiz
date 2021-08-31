using UnityEngine;
using UnityEditor;

namespace QuizGame
{
    [CreateAssetMenu(fileName = "NumberContainer", menuName = "QuizContainers/Number")]
    public class Number : CellContainer
    {
        public int number;
    }
}