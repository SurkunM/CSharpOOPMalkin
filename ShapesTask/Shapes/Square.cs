﻿namespace ShapesTask.Shapes;

internal class Square : IShape
{
    private const int SidesCount = 4;

    private const double epsilon = 1.0e-10;

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
        return SideLength * SidesCount;
    }

    public override string ToString()
    {
        return $"Square: SideLength = {SideLength}";
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

        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        Square square = (Square)obj;

        return Math.Abs(SideLength - square.SideLength) <= epsilon;
    }
}