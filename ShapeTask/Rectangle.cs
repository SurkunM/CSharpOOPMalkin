using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask;

internal class Rectangle : IShape
{
    private const int identicalSidesCount = 2;
    public double HorizontalSideLength { get; set; }
    public double VerticalSideLength { get; set; }

    public Rectangle(double horizontalSideLength, double verticalSideLength)
    {
        HorizontalSideLength = horizontalSideLength;
        VerticalSideLength = verticalSideLength;
    }
    public double GetWidth()
    {
        return HorizontalSideLength;
    }

    public double GetHeight()
    {
        return VerticalSideLength;
    }

    public double GetArea()
    {
        return HorizontalSideLength * VerticalSideLength;
    }

    public double GetPerimeter()
    {
        return (HorizontalSideLength + VerticalSideLength) * identicalSidesCount;
    }
    public override string ToString()
    {
        return GetArea().ToString();
    }
}