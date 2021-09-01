using UnityEngine;
using UnityEditor;
using QuizGame.Animation;

namespace QuizEditor.Animation
{
    public class EditorBounceScaleFadeIn : Editor
    {

        [CustomEditor(typeof(BounceScaleFadeIn))]
        public class EditorGridChildrenControl : EditorInitialisableActivator<BounceScaleFadeIn>
        {
            private BounceScaleFadeIn bouncer;
            private void OnEnable()
            {
                bouncer = InitializeTarget();
            }

            public override void OnInspectorGUI()
            {
                TestActivator("Test fade in bounce scale (Game only)", bouncer.Bouncing);
                base.OnInspectorGUI();
            }
        }
    }
}