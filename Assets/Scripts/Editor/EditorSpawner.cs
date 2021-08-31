using UnityEngine;
using UnityEditor;
using QuizGame;

namespace QuizEditor
{
    [CustomEditor(typeof(Spawner))]
    public class EditorSpawner : EditorInitialisableActivator<Spawner>
    {
        private Spawner spawner;
        private void OnEnable()
        {
            spawner = InitializeTarget();
        }

        public override void OnInspectorGUI()
        {
            TestActivator("Test Spawn", spawner.Spawn);
            if(GUILayout.Button("Destroy all children"))
            {
                spawner.DestroyAllChild();
            }
            base.OnInspectorGUI();
        }
    }
}