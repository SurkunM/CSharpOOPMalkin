using System.Text;

namespace VectorTask;

internal class Vector
{
    private const int pointsCount = 2;

    public double[] VectorComponents {  get; set; }

    private int dimension  = 1;

    public int Dimension
    {
        get
        {
            return dimension;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException();
            }
            else
            {
                dimension = value;
            }
        }
    }

    public Vector(int dimension)
    {
        Dimension = dimension;   
        
        VectorComponents = new double[dimension * pointsCount];
    }

    public Vector(Vector vector)
    {
        VectorComponents = vector.VectorComponents;
    }

    public Vector(double[] components)
    {
        VectorComponents = components;
    }

    public Vector(int dimension, double[] components)
    {
        Dimension = dimension;
        VectorComponents = GetComponentsCopy(components);
    }

    private double[] GetComponentsCopy(double[] components)
    {
        double[] array = new double[Dimension];

        if (Dimension > components.Length)
        {
            for (int i = 0; i < components.Length; i++)
            {
                array[i] = components[i];
            }
        }
        else
        {
            array = components;
        }

        return array;
    }

    public int GetSize()
    {
        return VectorComponents.Length;
    }

    public override string? ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        string semicolon = "; ";

        foreach (double components in VectorComponents)
        {
            stringBuilder.Append(components).Append(semicolon);
        }

        stringBuilder.Remove(stringBuilder.Length - semicolon.Length, semicolon.Length);

        return $"{{{stringBuilder.ToString()}}}";
    }
}