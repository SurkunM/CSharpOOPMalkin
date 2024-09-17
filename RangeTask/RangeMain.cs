namespace RangeTask;

internal class RangeMain
{
    public static void PrintIsInside(bool isInside, double rangeLength)
    {
        if (isInside)
        {
            Console.WriteLine("Число принадлежит диапазону длина которого {0}", rangeLength);
        }
        else
        {
            Console.WriteLine("Число не принадлежит диапазону длина которого {0}", rangeLength);
        }
    }

    public static void PrintIntersection(Range? range)
    {
        if (range is null)
        {
            Console.WriteLine("Диапазоны не пересекаются");
        }
        else
        {
            Console.WriteLine("Пересечение диапазонов:");
            Console.WriteLine(range);
        }
    }

    public static void PrintRangesArray(Range[] rangesArray)
    {
        if (rangesArray.Length == 0)
        {
            Console.WriteLine("(0)");
        }
        else
        {
            foreach (Range range in rangesArray)
            {
                Console.WriteLine(range);
            }
        }
    }

    static void Main(string[] args)
    {
        Range range1 = new Range(5, 15);

        PrintIsInside(range1.IsInside(5), range1.GetLength());

        Range range2 = new Range(5, 20);

        PrintIntersection(range1.GetIntersection(range2));

        Range[] rangesUnion = range1.GetUnion(range2);

        Console.WriteLine("Объединение диапазонов:");
        PrintRangesArray(rangesUnion);

        Range[] rangesDifference = range1.GetDifference(range2);

        Console.WriteLine("Разность диапазонов:");
        PrintRangesArray(rangesDifference);
    }
}