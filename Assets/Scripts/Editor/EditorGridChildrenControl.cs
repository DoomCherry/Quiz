using UnityEngine;
using UnityEditor;
using QuizGame.Grid;

namespace QuizEditor
{
    [CustomEditor(typeof(GridChildrenControl))]
    public class EditorGridChildrenControl : Editor
    {
        private GridChildrenControl gridControl;
        private void OnEnable()
        {
            gridControl = (GridChildrenControl)target;
            gridControl.Initialize();
        }

        public override void OnInspectorGUI()
        {
            if (GUILayout.Button("Sort Grid"))
            {
                gridControl.SortByGrid();
            }
            base.OnInspectorGUI();
        }
    }
}