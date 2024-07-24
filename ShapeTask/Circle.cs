namespace ShapeTask;

internal class Circle : IShape
{
    private const int two = 2;
    public double Radius { get; set; }

    public Circle(double radius)
    {
        Radius = radius;
    }
    public double GetWidth()
    {
        return Radius * two;
    }

    public double GetHeight()
    {
        return Radius * two;
    }

    public double GetArea()
    {
        return Math.PI * Math.Pow(Radius, two);
    }

    public double GetPerimeter()
    {
        return Math.PI * Radius * two;
    }

    public override string ToString()
    {
        return GetArea().ToString();
    }
}
