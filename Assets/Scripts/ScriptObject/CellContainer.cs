using UnityEngine;
using UnityEditor;

namespace QuizGame
{
    public class CellContainer : ScriptableObject
    {
        [SerializeField] protected Sprite _icon;
        [SerializeField] protected float _defaultRotate;
        

        public Sprite Icon => _icon;
        public float DefaultRotate => _defaultRotate;

        public virtual string GetAnsware()
        {
            return "";
        }
    }
}