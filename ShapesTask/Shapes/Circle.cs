namespace ShapesTask.Shapes;

internal class Circle : IShape
{
    private const double epsilon = 1.0e-10;

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
        return $"Circle: Radius = {Radius}";
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

        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        Circle circle = (Circle)obj;

        return Math.Abs(Radius - circle.Radius) <= epsilon;
    }
}