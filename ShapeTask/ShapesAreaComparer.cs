using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask;

internal class ShapesAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 is not null && shape2 is not null)
        {
            if (shape1.GetArea() > shape2.GetArea())
            {
                return -1;
            }

            if (shape1.GetArea() < shape2.GetArea())
            {
                return 1;
            }
        }

        return 0;
    }
}