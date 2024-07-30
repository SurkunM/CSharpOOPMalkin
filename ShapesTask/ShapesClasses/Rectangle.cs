using ShapesTask.ShapesInterface;

namespace ShapesTask.ShapesClasses;

internal class Rectangle : IShape
{
    private const int identicalSidesCount = 2;

    public double Width { get; set; }

    public double Height { get; set; }

    public Rectangle(double width, double height)
    {
        Width = width;
        Height = height;
    }

    public double GetWidth()
    {
        return Width;
    }

    public double GetHeight()
    {
        return Height;
    }

    public double GetArea()
    {
        return Width * Height;
    }

    public double GetPerimeter()
    {
        return (Width + Height) * identicalSidesCount;
    }
    public override string ToString()
    {
        return $"{Width.GetType()}: Width {{{Width}}}; {Height.GetType()}: Height {{{Height}}}";
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;

        hash = prime * hash + Width.GetHashCode();
        hash = prime * hash + Height.GetHashCode();

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

        Rectangle rectangleObj = (Rectangle)obj;

        return Width == rectangleObj.Width && Height == rectangleObj.Height;
    }
}