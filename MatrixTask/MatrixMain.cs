using VectorTask;

namespace MatrixTask;

internal class MatrixMain
{
    static void Main(string[] args)
    {         
        double[,] array =
        {
            { 2, 4, 1 },
            { 0, 2, 1 },
            { 2, 1, 1 },
        };

        Matrix matrix = new Matrix(array); 
        
        double det = matrix.GetDeterminant();
        Console.WriteLine( det);    

        double[] vectorArray1 = { 1, 4, 3 };
        double[] vectorArray2 = { 2, 1, 5 };
        double[] vectorArray3 = { 3, 2, 1 };

        Vector[] vectors = { new Vector(vectorArray1), new Vector(vectorArray2), new Vector(vectorArray3) };
        Matrix vectorMatrix = new Matrix(vectors);

        Matrix productM = Matrix.GetMatrixMultiplication(vectorMatrix, matrix);
        Matrix productVector = vectorMatrix.MultiplyByVector(new Vector(vectorArray1));  

        Console.WriteLine(productM);        
        Console.WriteLine(matrix);
        Console.WriteLine(vectorMatrix);
    }
}