using UnityEngine;
using UnityEditor;
using QuizGame.Animation;
using QuizEditor;

namespace QuizEditor.Animation
{
    public class EditorBouncerPosition : Editor
    {
        [CustomEditor(typeof(BouncerPosition))]
        public class EditorGridChildrenControl : EditorInitialisableActivator<BouncerPosition>
        {
            private BouncerPosition bouncer;
            private void OnEnable()
            {
                bouncer = InitializeTarget();
            }

            public override void OnInspectorGUI()
            {
                TestActivator("Test bounce position (Game only)", bouncer.Bouncing);
                base.OnInspectorGUI();
            }
        }
    }
}