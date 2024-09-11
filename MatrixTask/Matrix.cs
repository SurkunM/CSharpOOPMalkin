using System.Text;
using VectorTask;

namespace MatrixTask;

internal class Matrix
{
    public Vector[] VectorsMatrix { get; set; }

    public Matrix(int row, int column)
    {
        if (row <= 0 || column <= 0)
        {
            throw new ArgumentException("Размерность или количество векторов не может быть меньше или равной нулю");
        }

        VectorsMatrix = new Vector[row];

        for (int i = 0; i < row; i++)
        {
            VectorsMatrix[i] = new Vector(column);
        }
    }

    public Matrix(Matrix matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        VectorsMatrix = new Vector[matrix.VectorsMatrix.Length];

        matrix.VectorsMatrix.CopyTo(VectorsMatrix, 0);
    }

    public Matrix(double[,] matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        VectorsMatrix = new Vector[matrix.GetLength(0)];

        for (int i = 0; i < matrix.GetLength(0); i++)
        {
            double[] newMatrix = new double[matrix.GetLength(1)];

            for (int j = 0; j < newMatrix.Length; j++)
            {
                newMatrix[j] = matrix[i, j];
            }

            VectorsMatrix[i] = new Vector(newMatrix);
        }
    }

    public Matrix(Vector[] vectors)
    {
        if (vectors is null)
        {
            throw new ArgumentNullException(nameof(vectors));
        }

        VectorsMatrix = new Vector[vectors.Length];

        vectors.CopyTo(VectorsMatrix, 0);
    }

    public override string ToString()
    {
        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('{');
        string separator = ", ";

        foreach (Vector vector in VectorsMatrix)
        {
            stringBuilder.Append(vector).Append(separator);
        }

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
        stringBuilder.Append('}');

        return stringBuilder.ToString();
    }

    public int GetRowSize()
    {
        return VectorsMatrix.Length;
    }

    public int GetColumnSize()
    {
        if (VectorsMatrix is null)
        {
            throw new ArgumentNullException();
        }

        return VectorsMatrix[0].GetSize();
    }

    public Vector GetRow(int rowIndex)
    {
        if (rowIndex < 0 || rowIndex > VectorsMatrix.GetLength(1))
        {
            throw new IndexOutOfRangeException(nameof(rowIndex));
        }

        return VectorsMatrix[rowIndex];
    }

    public void SetRow(Vector vector, int rowIndex)
    {
        if (vector.GetSize() != VectorsMatrix.GetLength(1))
        {
            throw new IndexOutOfRangeException(nameof(rowIndex));
        }

        VectorsMatrix[rowIndex] = new Vector(vector);
    }

    public Vector GetColumn(int columnIndex)
    {
        if (columnIndex < 0 || columnIndex > VectorsMatrix.GetLength(1))
        {
            throw new IndexOutOfRangeException(nameof(columnIndex));
        }

        double[] newColumn = new double[VectorsMatrix.GetLength(0)];

        for (int i = 0; i < newColumn.Length; i++)
        {
            newColumn[i] = VectorsMatrix[i].GetComponent(columnIndex);
        }

        return new Vector(newColumn);
    }

    public void PerformTransposition()
    {
        Vector[] vectors = new Vector[VectorsMatrix.GetLength(0)];

        for (int i = 0; i < VectorsMatrix.GetLength(0); i++)
        {
            double[] tempMatrix = new double[VectorsMatrix.GetLength(1)];

            for (int j = 0; j < VectorsMatrix.GetLength(1); j++)
            {
                tempMatrix[j] = VectorsMatrix[j].GetComponent(i);
            }

            vectors[i] = new Vector(tempMatrix);
        }

        vectors.CopyTo(VectorsMatrix, 0);
    }

    public void MultiplyByScalar(double scalar)
    {
        for (int i = 0; i < VectorsMatrix.GetLength(0); i++)
        {
            VectorsMatrix[i].MultiplyByScalar(scalar);
        }
    }

    public double GetDeterminant()
    {
        if (GetRowSize() != GetColumnSize())
        {
            throw new ArgumentException("Данная матрица не является квадратной", nameof(VectorsMatrix));
        }

        if (VectorsMatrix.GetLength(0) == 1)
        {
            return VectorsMatrix[0].GetComponent(0);
        }

        if (VectorsMatrix.GetLength(0) == 2)
        {
            return VectorsMatrix[0].GetComponent(0) * VectorsMatrix[1].GetComponent(1) -
                   VectorsMatrix[0].GetComponent(1) * VectorsMatrix[1].GetComponent(0);
        }

        double determinant = 0;
        int row = 0;

        double[,] newVectorsMatrix = new double[VectorsMatrix.Length, VectorsMatrix.Length];

        for (int i = 0; i < newVectorsMatrix.GetLength(0); i++)
        {
            for (int j = 0; j < newVectorsMatrix.GetLength(1); j++)
            {
                newVectorsMatrix[i, j] = VectorsMatrix[i].GetComponent(j);
            }
        }

        for (int i = 0; i < VectorsMatrix.GetLength(0); i++)
        {
            determinant += Math.Pow(-1, i) * VectorsMatrix[row].GetComponent(i) * GetColumnDecomposition(newVectorsMatrix, row, i);
        }

        return determinant;
    }

    private static double GetColumnDecomposition(double[,] matrix, int row, int column)
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

    private static double[,] GetMinor(double[,] matrix, int row, int column)
    {
        double[,] newMatrix = new double[matrix.GetLength(0) - 1, matrix.GetLength(1) - 1];

        for (int i = 0, j = 0; i < matrix.GetLength(0); i++)
        {
            if (i != row)
            {
                for (int k = 0, l = 0; k < matrix.GetLength(1); k++)
                {
                    if (k != column)
                    {
                        newMatrix[j, l] = matrix[i, k];

                        l++;
                    }
                }

                j++;
            }
        }

        return newMatrix;
    }

    public Matrix MultiplyByVector(Vector columnVector)
    {
        if (columnVector.GetSize() != VectorsMatrix.Length)
        {
            throw new ArgumentException("Размер вектора не совпадает с размерами матрицы", nameof(columnVector));
        }

        double[,] newMatrix = new double[VectorsMatrix.Length, 1];

        for (int i = 0; i < VectorsMatrix.Length; i++)
        {
            for (int j = 0; j < VectorsMatrix.Length; j++)
            {
                newMatrix[i, 0] += VectorsMatrix[i].GetComponent(j) * columnVector.GetComponent(j);
            }
        }

        return new Matrix(newMatrix);
    }

    public void Adding(Matrix matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        if (VectorsMatrix.Length != matrix.VectorsMatrix.Length || GetColumnSize() != matrix.GetColumnSize())
        {
            throw new ArgumentException("Размерность матриц не свопадают");
        }

        for (int i = 0; i < VectorsMatrix.Length; i++)
        {
            VectorsMatrix[i].Adding(matrix.VectorsMatrix[i]);
        }
    }

    public void Subtraction(Matrix matrix)
    {
        if (matrix is null)
        {
            throw new ArgumentNullException(nameof(matrix));
        }

        if (VectorsMatrix.Length != matrix.VectorsMatrix.Length || GetColumnSize() != matrix.GetColumnSize())
        {
            throw new ArgumentException("Размерность матриц не свопадают");
        }

        for (int i = 0; i < VectorsMatrix.Length; i++)
        {
            VectorsMatrix[i].Subtraction(matrix.VectorsMatrix[i]);
        }
    }

    public static Matrix GetMatrixSum(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1 is null)
        {
            throw new ArgumentNullException(nameof(matrix1));
        }

        if (matrix2 is null)
        {
            throw new ArgumentNullException(nameof(matrix2));
        }

        if (matrix1.VectorsMatrix.Length != matrix2.VectorsMatrix.Length || matrix1.GetColumnSize() != matrix2.GetColumnSize())
        {
            throw new ArgumentException("Размерность матриц не свопадают");
        }

        Matrix newMatrix = new Matrix(matrix1.GetRowSize(), matrix1.GetColumnSize());

        for (int i = 0; i < matrix1.VectorsMatrix.Length; i++)
        {
            newMatrix.VectorsMatrix[i] = Vector.GetSum(matrix1.VectorsMatrix[i], matrix2.VectorsMatrix[i]);
        }

        return newMatrix;
    }

    public static Matrix GetMatrixDifference(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1 is null)
        {
            throw new ArgumentNullException(nameof(matrix1));
        }

        if (matrix2 is null)
        {
            throw new ArgumentNullException(nameof(matrix2));
        }

        if (matrix1.VectorsMatrix.Length != matrix2.VectorsMatrix.Length || matrix1.GetColumnSize() != matrix2.GetColumnSize())
        {
            throw new ArgumentException("Размерность матриц не свопадают");
        }

        Matrix newMatrix = new Matrix(matrix1.GetRowSize(), matrix1.GetColumnSize());

        for (int i = 0; i < matrix1.VectorsMatrix.Length; i++)
        {
            newMatrix.VectorsMatrix[i] = Vector.GetDifference(matrix1.VectorsMatrix[i], matrix2.VectorsMatrix[i]);
        }

        return new Matrix(newMatrix);
    }

    public static Matrix GetMatrixMultiplication(Matrix matrix1, Matrix matrix2)
    {
        if (matrix1 is null)
        {
            throw new ArgumentNullException(nameof(matrix1));
        }

        if (matrix2 is null)
        {
            throw new ArgumentNullException(nameof(matrix2));
        }

        if (matrix1.VectorsMatrix.Length != matrix2.VectorsMatrix.Length || matrix1.GetColumnSize() != matrix2.GetColumnSize())
        {
            throw new ArgumentException("Размерность матриц не свопадают");
        }

        double[,] newMatrix = new double[matrix1.VectorsMatrix.Length, matrix1.GetColumnSize()];

        for (int i = 0; i < matrix1.VectorsMatrix.Length; i++)
        {
            for (int j = 0; j < matrix1.VectorsMatrix.Length; j++)
            {
                for (int k = 0; k < matrix1.GetColumnSize(); k++)
                {
                    newMatrix[i, j] += matrix1.VectorsMatrix[i].GetComponent(k) * matrix2.VectorsMatrix[k].GetComponent(j);
                }
            }
        }

        return new Matrix(newMatrix);
    }
}