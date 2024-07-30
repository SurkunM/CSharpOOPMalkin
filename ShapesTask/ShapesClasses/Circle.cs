using ShapesTask.ShapesInterface;

namespace ShapesTask.ShapesClasses;

internal class Circle : IShape
{
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }

    public double GetWidth()
    {
        return Radius * 2;
    }

    public double GetHeight()
    {
        return Radius * 2;
    }

    public double GetArea()
    {
        return Math.PI * (Radius * Radius);
    }

    public double GetPerimeter()
    {
        return Math.PI * Radius * 2;
    }

    public override string ToString()
    {
        return $"{Radius.GetType()}: Radius {{{Radius}}}";
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;

        hash = prime * hash + Radius.GetHashCode();

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

        Circle circleObj = (Circle)obj;

        return Radius == circleObj.Radius;
    }
}