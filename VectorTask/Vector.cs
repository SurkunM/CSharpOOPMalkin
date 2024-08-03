using System.Text;

namespace VectorTask;

internal class Vector
{
    private int _dimension;

    private double[]? _vectorComponents;

    public double[] VectorComponents
    {
        get
        {
            return _vectorComponents!;
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
            throw new ArgumentNullException(nameof(vector));
        }

        Dimension = vector.Dimension;

        VectorComponents = GetComponentsCopy(vector.VectorComponents, Dimension);
    }

    public Vector(double[] components)
    {
        if (components is null)
        {
            throw new ArgumentNullException(nameof(components));
        }

        Dimension = components.Length;

        VectorComponents = GetComponentsCopy(components, Dimension);
    }

    public Vector(int dimension, double[] components)
    {
        if (dimension <= 0)
        {
            throw new ArgumentException(nameof(dimension));
        }

        if (components is null)
        {
            throw new ArgumentNullException(nameof(components));
        }

        Dimension = dimension;

        VectorComponents = GetComponentsCopy(components, Dimension);
    }

    private static double[] GetComponentsCopy(double[] components, int dimension)
    {
        double[] newComponentsArray = new double[dimension];

        for (int i = 0; i < components.Length; i++)
        {
            newComponentsArray[i] = components[i];
        }

        return newComponentsArray;
    }

    public override string? ToString()
    {
        if (VectorComponents.Length == 0)
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

    private int GetComponentsArrayHashCode(double[] componentsArray)
    {
        if (componentsArray.Length == 0)
        {
            return 0;
        }

        int prime = 37;
        int hash = 1;

        for (int i = 0; i < componentsArray.Length; i++)
        {
            hash = prime * hash + componentsArray[i].GetHashCode();
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

    private bool EqualsVectorComponents(double[] array1, double[] array2)
    {
        if (array1.Length != array2.Length)
        {
            return false;
        }

        for (int i = 0; i < array1.Length; i++)
        {
            if (array1[i] != array2[i])
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
        if (vector is null)
        {
            throw new ArgumentNullException(nameof(vector));
        }

        Dimension = Math.Max(Dimension, vector.Dimension);

        if (VectorComponents.Length < Dimension)
        {
            VectorComponents = GetArraysSum(GetComponentsCopy(VectorComponents, Dimension), vector.VectorComponents, Dimension);
        }
        else
        {
            VectorComponents = GetArraysSum(VectorComponents, vector.VectorComponents, vector.Dimension);
        }
    }

    private static double[] GetArraysSum(double[] array1, double[] array2, int length)
    {
        for (int i = 0; i < length; i++)
        {
            array1[i] += array2[i];
        }

        return array1;
    }

    public void GetVectorsDifference(Vector vector)
    {
        if (vector is null)
        {
            throw new ArgumentNullException(nameof(vector));
        }

        Dimension = Math.Max(Dimension, vector.Dimension);

        VectorComponents = GetComponentsCopy(VectorComponents, Dimension);
        VectorComponents = GetArraysDifference(VectorComponents, vector.VectorComponents, vector.Dimension);
    }

    private static double[] GetArraysDifference(double[] minuendArray, double[] subtrahendArray, int length)
    {
        for (int i = 0; i < length; i++)
        {
            minuendArray[i] -= subtrahendArray[i];
        }

        return minuendArray;
    }

    public void GetScalarMultiplication(int scalar)
    {
        for (int i = 0; i < Dimension; i++)
        {
            VectorComponents[i] *= scalar;
        }
    }

    public void ReverseVector()
    {
        int sOne = -1;

        for (int i = 0; i < Dimension; i++)
        {
            VectorComponents[i] *= sOne;
        }
    }

    public double GetVectorLength()
    {
        double vectorLength = 0;

        for (int i = 0; i < Dimension; i++)
        {
            vectorLength += Math.Pow(VectorComponents[i], 2);
        }

        return Math.Sqrt(vectorLength);
    }

    public double GetVectorComponent(int index)
    {
        if (index < 0 || index >= Dimension)
        {
            throw new ArgumentException(nameof(index));
        }

        return VectorComponents[index];
    }

    public void SetVectorComponent(int index, double component)
    {
        if (index < 0 || index >= Dimension)
        {
            throw new ArgumentException(nameof(index));
        }

        VectorComponents[index] = component;
    }

    public static Vector GetVectorsSum(Vector vector1, Vector vector2)
    {
        if (vector1 is null || vector2 is null)
        {
            throw new ArgumentNullException();
        }

        int maxDimension = Math.Max(vector1.Dimension, vector2.Dimension);

        double[] components1 = GetComponentsCopy(vector1.VectorComponents, maxDimension);

        if (vector1.Dimension < maxDimension)
        {
            return new Vector(GetArraysSum(components1, vector2.VectorComponents, maxDimension));
        }

        return new Vector(GetArraysSum(components1, vector2.VectorComponents, vector2.Dimension));
    }

    public static Vector GetVectorsDifference(Vector minuendVector, Vector subtrahendVector)
    {
        if (minuendVector is null || subtrahendVector is null)
        {
            throw new ArgumentNullException();
        }

        int maxDimension = Math.Max(minuendVector.Dimension, subtrahendVector.Dimension);

        double[] components1 = GetComponentsCopy(minuendVector.VectorComponents, maxDimension);

        if (minuendVector.Dimension < maxDimension)
        {
            return new Vector(GetArraysDifference(components1, subtrahendVector.VectorComponents, maxDimension));
        }

        return new Vector(GetArraysDifference(components1, subtrahendVector.VectorComponents, subtrahendVector.Dimension));
    }

    public static double GetVectorsScalarProduct(Vector vector1, Vector vector2)
    {
        if (vector1 is null || vector2 is null)
        {
            throw new ArgumentNullException();
        }

        double scalarProduct = 0;

        int minDimension = Math.Min(vector1.Dimension, vector2.Dimension);

        double[] temp = new double[Math.Max(vector1.Dimension, vector2.Dimension)];

        for (int i = 0; i < minDimension; i++)
        {
            temp[i] = vector1.VectorComponents[i] * vector2.VectorComponents[i];
            scalarProduct += temp[i];
        }

        return scalarProduct;
    }
}