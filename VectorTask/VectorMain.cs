namespace VectorTask;

internal class VectorMain
{
    static void Main(string[] args)
    {
        double[] array1 = { 3, -3, 2, 0 };
        double[] array2 = { 3, 3, 1 };

        Vector vector1 = new Vector(1, array1);
        Vector vector2 = new Vector(array2);

        Console.WriteLine("Вектор 1: {0}", vector1);
        Console.WriteLine("Вектор 2: {0}", vector2);

        vector1.Sum(vector2);
        Console.WriteLine("Сумма векторов = {0}", vector1);

        vector1.Difference(vector2);
        Console.WriteLine("Разность векторов = {0}", vector1);

        vector1.MultiplicationInScalar(2);
        Console.WriteLine("Умножение вектора на скаляр = {0}", vector1);

        vector1.ReverseVector();
        Console.WriteLine("Разворот {0} мерного вектора = {1}", vector1.GetSize(), vector1);

        Console.WriteLine("Длинна вектора = {0}", vector1.GetVectorModulus());
        Console.WriteLine("Первый компонент вектора {0} = {1}", vector1, vector1.GetComponent(0));

        Vector vectorsSum = Vector.GetVectorsSum(vector1, vector2);
        Console.WriteLine("Сумма векторов = {0}", vectorsSum);

        Vector vectorsDifference = Vector.GetVectorsDifference(vector1, vector2);
        Console.WriteLine("Разность векторов = {0}", vectorsDifference);

        Console.WriteLine("Скалярное произведение векторов = {0}", Vector.GetVectorsScalarProduct(vector1, vector2));
    }
}