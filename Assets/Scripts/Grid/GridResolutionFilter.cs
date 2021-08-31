using UnityEngine;
using System.Collections;
using System.Linq;

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
            Vector3 startPosition = Vector3.zero;
            Vector2 size = grid.GetSize();
            Vector2 position = grid.GetPosition();
            var GridElements = _cellChildren.Where(p => p.IsActive)
                                              .Select(p => (_gridParent.InverseTransformVector(p.myTransform.position) - (Vector3)position));
            var xGridElement = GridElements.Select(p => (p.x)).Distinct().Sum();
            var yGridElement = GridElements.Select(p => (p.y)).Distinct().Sum();
            startPosition.x = xGridElement / size.x;
            startPosition.y = yGridElement / size.y;
            myTransform.localPosition = new Vector3(startPosition.x, startPosition.y, myTransform.position.y) * -1;
        }
    }
}