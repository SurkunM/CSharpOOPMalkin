using System.Numerics;
using System.Runtime.Intrinsics;
using System.Text;

namespace VectorTask;

internal class Vector
{
    private int _dimension;

    private double[]? _vectorComponents;

    public double[]? VectorComponents
    {
        get
        {
            return _vectorComponents;
        }
        set
        {
            if (value is null)
            {
                throw new ArgumentNullException(nameof(value));
            }

            _vectorComponents = value;
        }
    }

    public int Dimension
    {
        get
        {
            return _dimension;
        }
        set
        {
            if (value <= 0)
            {
                throw new ArgumentException(nameof(value));
            }
            else
            {
                _dimension = value;
            }
        }
    }

    public Vector(int dimension)
    {
        Dimension = dimension;

        if (dimension <= 0)
        {
            throw new ArgumentException(nameof(dimension));
        }
        else
        {
            Dimension = dimension;
        }

        VectorComponents = new double[dimension];
    }

    public Vector(Vector vector)
    {
        if (vector is null)
        {
            throw new ArgumentException(nameof(vector));
        }

        Dimension = vector.Dimension;

        VectorComponents = GetComponentsCopy(vector.VectorComponents);
    }

    public Vector(double[] components)
    {
        VectorComponents = GetComponentsCopy(components);
    }

    public Vector(int dimension, double[] components)
    {
        if (dimension <= 0)
        {
            throw new ArgumentException(nameof(dimension));
        }
        else
        {
            Dimension = dimension;
        }

        VectorComponents = GetComponentsCopy(components);
    }

    private double[] GetComponentsCopy(double[]? components)
    {
        if (components is null)
        {
            throw new ArgumentNullException(nameof(components));
        }

        double[] vectorComponents = new double[components!.Length];

        for (int i = 0; i < vectorComponents.Length; i++)
        {
            vectorComponents[i] = components[i];
        }

        return vectorComponents;
    }

    public override string? ToString()
    {
        if (VectorComponents!.Length == 0)
        {
            return "";
        }

        StringBuilder stringBuilder = new StringBuilder();

        string comma = ", ";

        foreach (double components in VectorComponents)
        {
            stringBuilder.Append(components).Append(comma);
        }

        stringBuilder.Remove(stringBuilder.Length - comma.Length, comma.Length);

        return $"{{{stringBuilder.ToString()}}}";
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;

        hash = prime * hash + Dimension;
        hash = prime * hash + GetComponentsArrayHashCode(VectorComponents);

        return hash;
    }

    private int GetComponentsArrayHashCode(double[]? componentsArray)
    {
        if (componentsArray is null)
        {
            throw new ArgumentException(nameof(componentsArray));
        }

        if (componentsArray.Length == 0)
        {
            return 0;
        }

        int hash = 0;

        for (int i = 0; i < componentsArray.Length; i++)
        {
            hash += componentsArray[i].GetHashCode();
        }

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

        Vector vector = (Vector)obj;

        return EqualsVectorComponents(VectorComponents, vector.VectorComponents) && Dimension == vector.Dimension;
    }

    private bool EqualsVectorComponents(double[]? array, double[]? array2)
    {
        if (array is null || array2 is null)
        {
            throw new ArgumentNullException();
        }

        if (array.Length != array2.Length)
        {
            return false;
        }

        for (int i = 0; i < array.Length; i++)
        {
            if (array[i] != array2[i])
            {
                return false;
            }
        }

        return true;
    }

    public int GetSize()
    {
        return Dimension;
    }

    public void GetVectorsSum(Vector vector)
    {
        if (vector.VectorComponents is null)
        {
            throw new ArgumentException(nameof(vector.VectorComponents));
        }

        int maxSize = Math.Max(VectorComponents!.Length, vector.VectorComponents.Length);

        VectorComponents = GetComponentsCopy(VectorComponents, maxSize);
        double[] components2 = GetComponentsCopy(vector.VectorComponents, maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            VectorComponents[i] += components2[i];
        }
    }

    public void GetVectorsDifference(Vector vector)
    {
        if (vector.VectorComponents is null)
        {
            throw new ArgumentException(nameof(vector.VectorComponents));
        }

        int minSize = VectorComponents!.Length;

        if (VectorComponents.Length < vector.VectorComponents.Length)
        {
            double[] temp = new double[vector.VectorComponents.Length];

            for (int i = 0; i < VectorComponents.Length; i++)
            {
                temp[i] = VectorComponents[i];
            }

            VectorComponents = temp;
        }
        else
        {
            minSize = vector.VectorComponents.Length;
        }

        for (int i = 0; i < minSize; i++)
        {
            VectorComponents[i] -= vector.VectorComponents[i];
        }
    }

    public void GetScalarMultiplication(int scalar)
    {
        for (int i = 0; i < VectorComponents!.Length; i++)
        {
            VectorComponents[i] = Math.Abs(VectorComponents[i]) * Math.Abs(scalar);
        }
    }

    public void ReverseVector()
    {
        int sOne = -1;

        for (int i = 0; i < VectorComponents!.Length; i++)
        {
            VectorComponents[i] *= sOne;
        }
    }

    public int GetVectorLength()
    {
        return VectorComponents!.Length;
    }

    public double GetVectorComponent(int index)
    {
        if (index < 0 || index >= VectorComponents!.Length)
        {
            return -1;
        }

        return VectorComponents[index];
    }

    public void SetVectorComponent(int index, double component)
    {
        if (index < 0 || index >= VectorComponents!.Length)
        {
            throw new ArgumentException();
        }

        VectorComponents[index] = component;
    }

    public static Vector GetVectorsSum(Vector vector1, Vector vector2)
    {
        if (vector1.VectorComponents is null || vector2.VectorComponents is null)
        {
            throw new ArgumentException();
        }

        int maxSize = Math.Max(vector1.VectorComponents.Length, vector2.VectorComponents.Length);

        double[] components1 = GetComponentsCopy(vector1.VectorComponents, maxSize);
        double[] components2 = GetComponentsCopy(vector2.VectorComponents, maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            components1[i] += components2[i];
        }

        return new Vector(components1);
    }

    public static Vector GetVectorsDifference(Vector vector1, Vector vector2)
    {
        if (vector1.VectorComponents is null || vector2.VectorComponents is null)
        {
            throw new ArgumentException();
        }

        int maxSize = Math.Max(vector1.VectorComponents.Length, vector2.VectorComponents.Length);

        double[] components1 = GetComponentsCopy(vector1.VectorComponents, maxSize);
        double[] components2 = GetComponentsCopy(vector2.VectorComponents, maxSize);

        for (int i = 0; i < maxSize; i++)
        {
            components1[i] -= components2[i];
        }

        return new Vector(components1);
    }

    private static double[] GetComponentsCopy(double[] components, int size)
    {
        double[] newComponentsArray = new double[size];

        for (int i = 0; i < size; i++)
        {
            newComponentsArray[i] = components[i];
        }

        return newComponentsArray;
    }

    public static double GetVectorsScalarProduct(Vector vector1, Vector vector2)
    {
        if (vector1.VectorComponents is null || vector2.VectorComponents is null)
        {
            throw new ArgumentException();
        }

        double scalarProduct = 0;

        int minSize = Math.Min(vector1.VectorComponents.Length, vector2.VectorComponents.Length);

        double[] temp = new double[Math.Max(vector1.VectorComponents.Length, vector2.VectorComponents.Length)];

        if (vector1.VectorComponents.Length == temp.Length)
        {
            temp = vector1.VectorComponents;
        }
        else
        {
            temp = vector2.VectorComponents;
        }

        for (int i = 0; i < minSize; i++)
        {
            temp[i] = vector1.VectorComponents[i] * vector2.VectorComponents[i];
            scalarProduct += temp[i];
        }

        return scalarProduct;
    }
}