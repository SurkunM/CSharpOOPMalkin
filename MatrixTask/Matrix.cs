using System.Xml;
using VectorTask;

namespace MatrixTask;

internal class Matrix
{
    //private double[,]? _vectorsMatrix;

    //public double[,] VectorsMatrix // Vectors[]?
    //{
    //    get
    //    {
    //        return _vectorsMatrix;
    //    }
    //    set
    //    {
    //        if (value is null)
    //        {
    //            throw new ArgumentNullException();
    //        }

    //        _vectorsMatrix = value;
    //    }
    //}

    public Vector[] VectorsM { get; set; }

    public int RowSize { get; set; }

    public int ColumnSize { get; set; }

    public Matrix(int row, int column)
    {
        if (row <= 0 || column <= 0)
        {
            throw new ArgumentException("Размеры матрицы должны быть больше нуля");
        }

        VectorsM = new Vector[row];
        Vector temp = new Vector(column);

        for (int i = 0; i < row; i++)
        {
            VectorsM[i] = new Vector(temp);
        }
    }

    public Matrix(Matrix matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException();
        }

        RowSize = matrix.RowSize;
        ColumnSize = matrix.ColumnSize;
        VectorsM = new Vector[matrix.VectorsM.Length];


        for (int i = 0; i < matrix.VectorsM.GetLength(0); i++)
        {
            VectorsM[i] = new Vector(matrix.VectorsM[i]);
        }

    }

    public Matrix(double[,] matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException();
        }

        RowSize = matrix.GetLength(0);
        ColumnSize = matrix.GetLength(1);

        VectorsM = new Vector[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            double[] temp = new double[matrix.GetLength(1)];

            for (int j = 0; j < temp.Length; j++)
            {
                temp[j] = matrix[i, j];
            }

            VectorsM[i] = new Vector(temp);
        }
    }

    public Matrix(Vector[] vectors)
    {
        if (vectors is null)
        {
            throw new ArgumentNullException();
        }

        RowSize = vectors.GetLength(0);
        ColumnSize = GetMaxDimension(vectors);
        VectorsM = new Vector[vectors.Length];

        for (int i = 0; i < vectors.Length; i++)
        {
            VectorsM[i] = new Vector(vectors[i]);
        }
    }

    private static int GetMaxDimension(Vector[] vector)
    {
        int maxDimension = 0;

        for (int i = 0; i < vector.Length; i++)
        {
            maxDimension = Math.Max(vector[i].Dimension, maxDimension);
        }

        return maxDimension;
    }

    private double[] GetCopy(double[] matrix)
    {
        double[] newArray = new double[RowSize];

        for (int i = 0; i < RowSize; i++)
        {

            newArray[i] = matrix[i];

        }

        return newArray;
    }
    private double[,] GetCopy(Vector[] vectors)
    {
        double[,] newArray = new double[RowSize, ColumnSize];

        for (int i = 0; i < RowSize; i++)
        {
            double[] temp;

            if (vectors[i].Dimension < ColumnSize)
            {
                temp = GetEqualsSize(vectors[i].VectorComponents);
            }
            else
            {
                temp = vectors[i].VectorComponents;
            }

            for (int j = 0; j < ColumnSize; j++)
            {
                newArray[i, j] = temp[j];
            }
        }

        return newArray;
    }

    private double[] GetEqualsSize(double[] vectors)
    {
        double[] temp = new double[ColumnSize];

        for (int j = 0; j < vectors.Length; j++)
        {
            temp[j] = vectors[j];
        }

        return temp;
    }

    public override string ToString()// Временная
    {
        string s = "";

        foreach (Vector vectors in VectorsM)
        {
            s += vectors.ToString() + ", ";
        }

        return s;
    }

    public override bool Equals(object? obj)
    {
        return base.Equals(obj);
    }

    public override int GetHashCode()
    {
        return base.GetHashCode();
    }

    public int GetRowSize()
    {
        return RowSize;
    }

    public int GetColumnSize()
    {
        return ColumnSize;
    }

    public Vector GetVectorRow(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex > ColumnSize)
        {
            throw new ArgumentException(nameof(rowIndex));
        }

        return VectorsM[rowIndex];
    }

    public void SetVectorRow(Vector vector, int rowIndex)
    {
        if (vector.GetSize() != ColumnSize)
        {
            throw new ArgumentException(nameof(vector));
        }

        VectorsM[rowIndex] = new Vector(vector);
    }

    public Vector GetVectorColumn(int indexColumn)
    {
        if (indexColumn < 0 || indexColumn > ColumnSize)
        {
            throw new ArgumentException(nameof(indexColumn));
        }

        double[] temp = new double[VectorsM.Length];

        for (int i = 0; i < temp.Length; i++)
        {
            temp[i] = VectorsM[i].VectorComponents[indexColumn];
        }

        return new Vector(temp);
    }

    public void GetMatrixTransposition()
    {
        double[,] tempMatrix = new double[RowSize, ColumnSize];

        for (int i = 0; i < RowSize; i++)
        {
            for (int j = 0; j < ColumnSize; j++)
            {
                tempMatrix[i, j] = VectorsM[j].VectorComponents[i];
            }
        }

        VectorsM = new Matrix(tempMatrix).VectorsM;
    }

    public void GetScalarMultiplication(int scalar)
    {
        for (int i = 0; i < RowSize; i++)
        {
            for (int j = 0; j < ColumnSize; j++)
            {
                VectorsM[i].VectorComponents[j] *= scalar;
            }
        }
    }

    public double GetMatrixDeterminant()
    {
        if (RowSize != ColumnSize)
        {
            throw new ArgumentException();
        }


        if (RowSize == 1)
        {
            return VectorsM[0].VectorComponents[0];
        }

        if (RowSize == 2)
        {
            return VectorsM[0].VectorComponents[0] * VectorsM[1].VectorComponents[1] - VectorsM[0].VectorComponents[1] * VectorsM[1].VectorComponents[0];
        }

        double determinant = 0;
        int row = 0;

        double[,] VectorsMatrix = new double[VectorsM.Length, VectorsM[0].Dimension];

        for (int i = 0; i < VectorsMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < VectorsMatrix.GetLength(1); j++)
            {
                VectorsMatrix[i, j] = VectorsM[i].VectorComponents[j];
            }
        }

        for (int i = 0; i < RowSize; i++)
        {
            determinant += Math.Pow(-1, i) * VectorsM[row].VectorComponents[i] * GetColumnDecomposition(VectorsMatrix, row, i);
        }

        return determinant;
    }

    private double GetColumnDecomposition(double[,] matrix, int row, int column)
    {
        double[,] minor = GetMinor(matrix, row, column);

        if (minor.GetLength(0) == 2)
        {
            return minor[0, 0] * minor[1, 1] - minor[0, 1] * minor[1, 0];
        }

        double determinant = 0;

        for (int i = 0; i < minor.GetLength(0); i++)
        {
            determinant += Math.Pow(-1, i) * minor[row, i] * GetColumnDecomposition(minor, row, i);
        }

        return determinant;
    }

    private double[,] GetMinor(double[,] matrix, int row, int column)
    {
        double[,] temp = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

        for (int i = 0, j = 0; i < matrix.GetLength(0); i++)
        {
            if (i != row)
            {
                for (int k = 0, l = 0; k < matrix.GetLength(1); k++)
                {
                    if (k != column)
                    {
                        temp[j, l] = matrix[i, k];

                        l++;
                    }
                }

                j++;
            }
        }

        return temp;
    }

    public double[,] GetVectorMultiplication(double[,] vector)
    {
        if (vector.GetLength(0) != RowSize || vector.GetLength(1) != 1)
        {
            throw new ArgumentException(nameof(vector));
        }

        double[,] temp = new double[RowSize, 1];

        for (int i = 0; i < ColumnSize; i++)
        {
            for (int j = 0; j < RowSize; j++)
            {
                temp[i, 0] += VectorsM[i].VectorComponents[j] * vector[i, 0];
            }
        }

        return temp;
    }

    public void GetMatrixSum(Matrix matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        if (RowSize != matrix.RowSize || ColumnSize != matrix.ColumnSize)
        {
            throw new ArgumentException();
        }

        for (int i = 0; i < RowSize; i++)
        {
            for (int j = 0; j < ColumnSize; j++)
            {
                VectorsM[i].VectorComponents[j] += matrix.VectorsM[i].VectorComponents[j];
            }
        }
    }

    public void GetMatrixDifference(Matrix matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        if (RowSize != matrix.RowSize || ColumnSize != matrix.ColumnSize)
        {
            throw new ArgumentException();
        }

        for (int i = 0; i < RowSize; i++)
        {
            for (int j = 0; j < ColumnSize; j++)
            {
                VectorsM[i].VectorComponents[j] -= matrix.VectorsM[i].VectorComponents[j];
            }
        }
    }

    public static Matrix GetMatrixSum(Matrix matrix1, Matrix matrix2)
    {
        double[,] temp = new double[matrix1.RowSize, matrix1.ColumnSize];

        for (int i = 0; i < matrix1.RowSize; i++)
        {
            for (int j = 0; j < matrix1.ColumnSize; j++)
            {
                temp[i, j] = matrix1.VectorsM[i].VectorComponents[j] + matrix2.VectorsM[i].VectorComponents[j];
            }
        }

        return new Matrix(temp);
    }

    public static Matrix GetMatrixDifference(Matrix matrix1, Matrix matrix2)
    {
        double[,] temp = new double[matrix1.RowSize, matrix1.ColumnSize];

        for (int i = 0; i < matrix1.RowSize; i++)
        {
            for (int j = 0; j < matrix1.ColumnSize; j++)
            {
                temp[i, j] = matrix1.VectorsM[i].VectorComponents[j] - matrix2.VectorsM[i].VectorComponents[j];
            }
        }

        return new Matrix(temp);
    }

    public static Matrix GetMatrixMultiplication(Matrix matrix1, Matrix matrix2)
    {
        double[,] temp = new double[matrix1.RowSize, matrix1.ColumnSize];

        for (int i = 0; i < matrix1.RowSize; i++)
        {
            for (int j = 0; j < matrix1.ColumnSize; j++)
            {
                for (int k = 0; k < matrix1.ColumnSize; k++)
                {
                    temp[i, j] += matrix1.VectorsM[i].VectorComponents[k] * matrix2.VectorsM[k].VectorComponents[j];
                }
            }
        }

        return new Matrix(temp);
    }
}