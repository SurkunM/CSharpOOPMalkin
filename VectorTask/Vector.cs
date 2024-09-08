using System.Text;

namespace VectorTask;

public class Vector
{
    private double[] _components;

    public Vector(int dimension)
    {
        if (dimension <= 0)
        {
            throw new ArgumentException("Размерность вектора не может быть меньше или равной нулю.", nameof(dimension));
        }

        _components = new double[dimension];
    }

    public Vector(Vector vector)
    {
        if (vector is null)
        {
            throw new ArgumentNullException(nameof(vector));
        }

        _components = new double[vector._components.Length];

        vector._components.CopyTo(_components, 0);
    }

    public Vector(double[] components)
    {
        if (components is null)
        {
            throw new ArgumentNullException(nameof(components));
        }

        if (components.Length == 0)
        {
            throw new ArgumentException("Размерность вектора не может быть меньше или равной нулю.", nameof(components.Length));
        }

        _components = new double[components.Length];

        components.CopyTo(_components, 0);
    }

    public Vector(int dimension, double[] components)
    {
        if (dimension <= 0)
        {
            throw new ArgumentException("Размерность вектора не может быть меньше или равной нулю.", nameof(dimension));
        }

        if (components is null)
        {
            throw new ArgumentNullException(nameof(components));
        }

        _components = new double[dimension];

        Array.Copy(components, 0, _components, 0, dimension);
    }

    public override string? ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('{');
        string separator = ", ";

        foreach (double component in _components)
        {
            stringBuilder.Append(component).Append(separator);
        }

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;

        foreach (double component in _components)
        {
            hash = prime * hash + component.GetHashCode();
        }

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

        Vector vector = (Vector)obj;

        if (_components.Length != vector._components.Length)
        {
            return false;
        }
        else
        {
            for (int i = 0; i < _components.Length; i++)
            {
                if (_components[i] != vector._components[i])
                {
                    return false;
                }
            }
        }

        return true;
    }

    public int GetSize()
    {
        return _components.Length;
    }

    public void Adding(Vector vector)
    {
        if (vector is null)
        {
            throw new ArgumentNullException(nameof(vector));
        }

        if (_components.Length < vector._components.Length)
        {
            Array.Resize(ref _components, vector._components.Length);
        }

        for (int i = 0; i < vector._components.Length; i++)
        {
            _components[i] += vector._components[i];
        }
    }

    public void Subtraction(Vector vector)
    {
        if (vector is null)
        {
            throw new ArgumentNullException(nameof(vector));
        }

        if (_components.Length < vector._components.Length)
        {
            Array.Resize(ref _components, vector._components.Length);
        }

        for (int i = 0; i < vector._components.Length; i++)
        {
            _components[i] -= vector._components[i];
        }
    }

    public void MultiplyByScalar(double scalar)
    {
        for (int i = 0; i < _components.Length; i++)
        {
            _components[i] *= scalar;
        }
    }

    public void Reverse()
    {
        MultiplyByScalar(-1);
    }

    public double GetLength()
    {
        double vectorModulus = 0;

        foreach (double component in _components)
        {
            vectorModulus += component * component;
        }

        return Math.Sqrt(vectorModulus);
    }

    public double GetComponent(int index)
    {
        if (index < 0 || index >= _components.Length)
        {
            throw new IndexOutOfRangeException(nameof(index));
        }

        return _components[index];
    }

    public void SetComponent(int index, double component)
    {
        if (index < 0 || index >= _components.Length)
        {
            throw new IndexOutOfRangeException(nameof(index));
        }

        _components[index] = component;
    }

    public static Vector GetSum(Vector vector1, Vector vector2)
    {
        if (vector1 is null)
        {
            throw new ArgumentNullException(nameof(vector1));
        }

        if (vector2 is null)
        {
            throw new ArgumentNullException(nameof(vector2));
        }

        Vector newVector = new Vector(vector1);

        newVector.Adding(vector2);

        return newVector;
    }

    public static Vector GetDifference(Vector vector1, Vector vector2)
    {
        if (vector1 is null)
        {
            throw new ArgumentNullException(nameof(vector1));
        }

        if (vector2 is null)
        {
            throw new ArgumentNullException(nameof(vector2));
        }

        Vector newVector = new Vector(vector1);

        newVector.Subtraction(vector2);

        return newVector;
    }

    public static double GetScalarProduct(Vector vector1, Vector vector2)
    {
        if (vector1 is null)
        {
            throw new ArgumentNullException(nameof(vector1));
        }

        if (vector2 is null)
        {
            throw new ArgumentNullException(nameof(vector2));
        }

        double scalarProduct = 0;

        int minSize = Math.Min(vector1._components.Length, vector2._components.Length);

        for (int i = 0; i < minSize; i++)
        {
            scalarProduct += vector1._components[i] * vector2._components[i];
        }

        return scalarProduct;
    }
}