using UnityEngine;
using UnityEditor;
using QuizGame.Animation;

namespace QuizEditor.Animation
{
    public class EditorBouncer : Editor
    {
        [CustomEditor(typeof(Bouncer))]
        public class EditorGridChildrenControl : Editor
        {
            private Bouncer bouncer;
            private void OnEnable()
            {
                bouncer = (Bouncer)target;
                bouncer.Initialize();
            }

            public override void OnInspectorGUI()
            {
                if (GUILayout.Button("Test bounce in game"))
                {
                    bouncer.Bouncing();
                }
                base.OnInspectorGUI();
            }
        }
    }
}