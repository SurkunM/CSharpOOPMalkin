using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShapeTask;

internal class Triangle : IShape
{
    private const double oneHalf = 1.0 / 2;
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
        return oneHalf * Math.Abs((X2 - X1) * (Y3 - Y1) - (X3 - X1) * (Y2 - Y1));
    }

    public double GetPerimeter()
    {
        if ((X1 - X3) * (Y2 - Y3) == (X2 - X3) * (Y1 - Y3))
        {
            return 0;
        }

        double side1Length = Math.Sqrt(Math.Pow(X2 - X1, 2) + Math.Pow(Y2 - Y1, 2));
        double side2Length = Math.Sqrt(Math.Pow(X3 - X2, 2) + Math.Pow(Y3 - Y2, 2));
        double side3Length = Math.Sqrt(Math.Pow(X3 - X1, 2) + Math.Pow(Y3 - Y1, 2));

        return side1Length + side2Length + side3Length;
    }

    public override string? ToString()
    {
        return GetArea().ToString();
    }
}