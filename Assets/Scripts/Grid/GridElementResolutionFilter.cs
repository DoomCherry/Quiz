using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QuizGame.Grid
{
    class GridElementResolutionFilter : ResolutionFilter<GridChildrenControl>
    {
        [SerializeField] private GridChildrenControl dependencyObject;

        public override void Initialize()
        {
            base.Initialize(dependencyObject);
            dependencyObject.OnAction(AutoResolute);
        }
    }
}
