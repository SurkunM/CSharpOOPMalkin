namespace ShapesTask.Shapes;

internal class Triangle : IShape
{
    private const double Epsilon = 1.0e-10;

    public double X1 { get; set; }

    public double Y1 { get; set; }

    public double X2 { get; set; }

    public double Y2 { get; set; }

    public double X3 { get; set; }

    public double Y3 { get; set; }

    public Triangle(double x1, double y1, double x2, double y2, double x3, double y3)
    {
        X1 = x1;
        Y1 = y1;
        X2 = x2;
        Y2 = y2;
        X3 = x3;
        Y3 = y3;
    }

    public double GetWidth()
    {
        return Math.Max(X1, Math.Max(X2, X3)) - Math.Min(X1, Math.Min(X2, X3));
    }

    public double GetHeight()
    {
        return Math.Max(Y1, Math.Max(Y2, Y3)) - Math.Min(Y1, Math.Min(Y2, Y3));
    }

    public double GetArea()
    {
        return 0.5 * Math.Abs((X2 - X1) * (Y3 - Y1) - (X3 - X1) * (Y2 - Y1));
    }

    public double GetPerimeter()
    {
        if (Math.Abs((X1 - X3) * (Y2 - Y3) - (X2 - X3) * (Y1 - Y3)) <= Epsilon)
        {
            return 0;
        }

        double side1Length = GetSideLength(X1, X2, Y1, Y2);
        double side2Length = GetSideLength(X2, X3, Y2, Y3);
        double side3Length = GetSideLength(X1, X3, Y1, Y3);

        return side1Length + side2Length + side3Length;
    }

    private static double GetSideLength(double x1, double y1, double x2, double y2)
    {
        return Math.Sqrt(Math.Pow(x2 - x1, 2) + Math.Pow(y2 - y1, 2));
    }

    public override string ToString()
    {
        return $"Triangle: X1Y1({X1}; {Y1}), X2Y2({X2}; {Y2}), X3Y3({X3}; {Y3})";
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        hash = prime * hash + X1.GetHashCode();
        hash = prime * hash + Y1.GetHashCode();

        hash = prime * hash + X2.GetHashCode();
        hash = prime * hash + Y2.GetHashCode();

        hash = prime * hash + X3.GetHashCode();
        hash = prime * hash + Y3.GetHashCode();

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

        Triangle triangle = (Triangle)obj;

        return X1 == triangle.X1 && Y1 == triangle.Y1 &&
               X2 == triangle.X2 && Y2 == triangle.Y2 &&
               X3 == triangle.X3 && Y3 == triangle.Y3;
    }
}