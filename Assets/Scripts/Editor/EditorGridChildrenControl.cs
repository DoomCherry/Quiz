using UnityEngine;
using UnityEditor;
using QuizGame.Grid;

namespace QuizEditor
{
    [CustomEditor(typeof(GridChildrenControl))]
    public class EditorGridChildrenControl : EditorInitialisableActivator<GridChildrenControl>
    {
        private GridChildrenControl gridControl;
        private void OnEnable()
        {
            gridControl = InitializeTarget();
        }

        public override void OnInspectorGUI()
        {
            TestActivator("Sort Grid", gridControl.SortByGrid);
            base.OnInspectorGUI();
        }
    }
}