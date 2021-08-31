using System.Collections;
using System.Linq;
using System.Collections.Generic;
using UnityEngine;

namespace QuizGame
{
    public class ResolutionFilter<T> : SerializableMonoBehavior
        where T: IRectable, IActivatror
    {
        public enum ScaleInstruction
        {
            MaxScale = 0,
            MinScale,
            WidthAndHight,
            NoScale
        }

        [SerializeField] private ScaleInstruction _scaleInstruction;

        protected T resolutionDependencyObject;
        
        void Start()
        {
            Initialize();
        }

        public virtual void Initialize(T resolutionObject)
        {
            base.Initialize();
            resolutionDependencyObject = resolutionObject;
            resolutionDependencyObject.OnAction(AutoResolute);
        }

        public virtual void AutoResolute()
        {
            Resize();
        }

        private void Resize()
        {
            float size;
            Vector2 rect = resolutionDependencyObject.GetSize();
            switch (_scaleInstruction)
            {
                case ScaleInstruction.MaxScale:
                    size = 1 / (float)Mathf.Max(rect.x, rect.y);
                    myTransform.localScale = new Vector3(size, size, myTransform.localScale.y);
                    break;
                case ScaleInstruction.MinScale:
                    size = 1 / (float)Mathf.Min(rect.x, rect.y);
                    myTransform.localScale = new Vector3(size, size, myTransform.localScale.y);
                    break;
                case ScaleInstruction.WidthAndHight:
                    myTransform.localScale = new Vector3(rect.x, rect.y);
                    break;
            }
        }
    }
}
