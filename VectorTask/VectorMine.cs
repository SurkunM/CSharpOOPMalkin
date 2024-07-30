namespace VectorTask;

internal class VectorMine
{
    static void Main(string[] args)
    {
        double[] array = null;

        double[] array2 = { 0, 3, -2, 4, 3 };

        Vector vector = null;     

        //Vector vector2 = new Vector();

        Vector sum = Vector.GetVectorsSum(vector, vector2);

        double s =  Vector.GetVectorsScalarProduct(vector, vector2);

        Console.WriteLine(s);
        Console.WriteLine(vector);
    }
}
