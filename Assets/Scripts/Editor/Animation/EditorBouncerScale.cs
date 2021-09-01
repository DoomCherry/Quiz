using UnityEngine;
using UnityEditor;
using QuizGame.Animation;

namespace QuizEditor.Animation
{
    public class EditorBouncerScale : Editor
    {
        [CustomEditor(typeof(BouncerScaler))]
        public class EditorGridChildrenControl : EditorInitialisableActivator<BouncerScaler>
        {
            private BouncerScaler bouncer;
            private void OnEnable()
            {
                bouncer = InitializeTarget();
            }

            public override void OnInspectorGUI()
            {
                TestActivator("Test bounce scale (Game only)", delegate { bouncer.Bouncing(); });
                base.OnInspectorGUI();
            }
        }
    }
}