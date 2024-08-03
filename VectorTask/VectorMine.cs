namespace VectorTask;

internal class VectorMine
{
    static void Main(string[] args)
    {
        double[] array1 = { -2, 4, 3 };
        double[] array2 = { 3, 3, 1, 2 };

        Vector vector1 = new Vector(array1);
        Vector vector2 = new Vector(array2);
       
        vector1.GetVectorsSum(vector2);
        vector1.GetVectorsDifference(vector2);

        Console.WriteLine("Координаты {0} мерного вектора: {1}", vector1.GetSize(), vector1);

        vector1.GetScalarMultiplication(2);
        vector1.ReverseVector();

        double vectorLength = vector1.GetVectorLength();
        double vectorComponent = vector1.GetVectorComponent(0);

        Console.WriteLine("Длинна вектора {0} равна {1}", vector1, vectorLength);
        Console.WriteLine("Первый компонент вектора {0} равен {1}", vector1, vectorComponent);

        vector1.SetVectorComponent(0, vectorComponent);

        Vector vectorsSum = Vector.GetVectorsSum(vector1, vector2);
        Vector vectorsDifference = Vector.GetVectorsDifference(vector1, vector2);

        double vectorsScalarProduct = Vector.GetVectorsScalarProduct(vector1, vector2);        
    }
}