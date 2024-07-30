using ShapesTask.ShapesInterface;
using System.Runtime.Remoting;

namespace ShapesTask.ShapesClasses;

internal class Square : IShape
{
    private const int sidesCount = 4;

    public double SideLength { get; set; }

    public Square(double sideLength)
    {
        SideLength = sideLength;
    }

    public double GetWidth()
    {
        return SideLength;
    }

    public double GetHeight()
    {
        return SideLength;
    }

    public double GetArea()
    {
        return SideLength * SideLength;
    }

    public double GetPerimeter()
    {
        return SideLength * sidesCount;
    }

    public override string ToString()
    {
        return $"{SideLength.GetType()}: SideLength {{{SideLength}}}";
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;

        hash = prime * hash + SideLength.GetHashCode();

        return hash;
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(obj, this))
        {
            return true;
        }

        if (ReferenceEquals(obj, null) || obj.GetType() != GetType())
        {
            return false;
        }

        Square squareObj = (Square)obj;

        return SideLength == squareObj.SideLength;
    }
}