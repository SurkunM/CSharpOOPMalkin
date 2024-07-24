namespace VectorTask;

internal class VectorMine
{
    static void Main(string[] args)
    {
        double[] array = { 0, 3, 1.1, 4.4, 0.4 };

        Vector vector4 = new Vector(8, array);

       string s = vector4.ToString();


        Console.WriteLine(s);

    }
}
