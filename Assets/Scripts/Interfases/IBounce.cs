using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DG.Tweening;

namespace QuizGame
{
    interface IBounce
    {
        void VoidBouncing();
        Sequence Bouncing();
        void SetDefault();
    }
}
