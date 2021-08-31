using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace QuizGame
{
    public interface IRectable
    {
        Vector2 GetPosition();
        Vector2Int GetSize();
    }
}
