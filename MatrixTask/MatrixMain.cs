using System.Text.RegularExpressions;
using VectorTask;

namespace MatrixTask;

internal class MatrixMain
{
    static void Main(string[] args)
    {     
        double[,] array2 =
        {
            {-12, 3,1},
            {5, 4, 1 }

        };

        int[] s1 = { 0, 1, 2, 3 };

        int[] q1 = s1;
        int[] s2 = q1;
        s2[1] = 123;

        Matrix matrix1 = new Matrix(3, 4);

        double[] doubles = { 0, 1, 0 };

        matrix1.VectorsM[1].VectorComponents[1] = 3;

        double[,] array =
        {
            { -2, 1, 3, 2 },
            { 3, 0, -1, 2 },
            { -5, 2, 3, 0 },
            { 4, -1, 2, -3 }            

        };

        double[,] array33 =
        {
            { 2, 4, 1 },
            { 0, 2, 1 },
            { 2, 1, 1 },
        };

        double[,] array122 =
{
            { 1, 2, 3 },
            { 4, 5, 6 },
            { 7, 8, 9 },
        };

        double[,] array123 =
        {
            { 2, 3, 0, 4, 5 },
            { 0, 1, 0, -1, 2 },
            { 3, 2, 1, 0, 1 },
            { 0, 4, 0, -5, 0 },
            { 1, 1, 2 ,-2, 1 }

        };
    
        Matrix matrix = new Matrix(array);                

        string s = matrix.ToString();
        double det = matrix.GetMatrixDeterminant();
         
        

        double[] vectorArray1 = { 1, 4, 3 };
        double[] vectorArray2 = { 2, 1, 5 };
        double[] vectorArray3 = { 3, 2, 1 };

        double[,] vectorMulti =
        {
            { 1 },
            { 2 },
            { 3 }
        };




        Vector vector1 = new Vector(vectorArray1);
        Vector vector2 = new Vector(vectorArray2);
        Vector vector3 = new Vector(vectorArray3);

        Vector[] vectors = { vector1, vector2, vector3 };

        Matrix vectorMatrix = new Matrix(vectors);

        Matrix productM = Matrix.GetMatrixMultiplication(vectorMatrix, matrix);


        Console.WriteLine(matrix);
        Console.WriteLine(matrix1);
        Console.WriteLine(matrix);
        Console.WriteLine(vectorMatrix);
    }
}
