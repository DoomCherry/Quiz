using UnityEngine;
using System.Collections;
using System.Linq;
using System;

namespace QuizGame.Grid
{
    public class GridResolutionFilter : ResolutionFilter<GridChildrenControl>
    {
        [SerializeField] private GridChildrenControl grid;

        private Transform _gridParent => grid.myTransform.parent;
        private Cell[] _cellChildren => grid._cellChildren;

        public override void Initialize()
        {
            base.Initialize(grid);
            grid.OnAction(AutoResolute);
        }

        public override void AutoResolute()
        {
            base.AutoResolute();
            ChangePosition();
        }

        private void ChangePosition()
        {
            myTransform.position += GetFloatMidPoint();
        }

        private Vector3 GetFloatMidPoint()
        {
            Vector3 startPosition = Vector3.zero;
            Vector2 size = grid.GetSize();
            Vector2 position = grid.GetPosition();
            var GridElements = _cellChildren.Where(p => p.IsActive)
                                              .Select(p => p.myTransform.localPosition);
            Vector2 result;
            var allUniqye = GridElements.Select(p => (p.x)).Distinct();
            result.x = allUniqye.Sum() / allUniqye.Count();
            allUniqye = GridElements.Select(p => (p.y)).Distinct();
            result.y = allUniqye.Sum() / allUniqye.Count();
            result = _gridParent.position - grid.transform.TransformPoint(result);
            return new Vector3((float)Math.Round(result.x, 3), (float)Math.Round(result.y, 3), myTransform.position.z);
        }
    }
}