namespace RangeTask;

internal class RangeMain
{
    public static void PrintIsInside(bool isInside, double rangeLength)
    {
        if (isInside)
        {
            Console.WriteLine("Число принадлежит диапазону длинна которой {0}", rangeLength);
        }
        else
        {
            Console.WriteLine("Число не принадлежит диапазону длинна которой {0}", rangeLength);
        }
    }

    public static void PrintIntersection(Range? range)
    {
        if (range == null)
        {
            Console.WriteLine("Диапазоны не пересекаются");
        }
        else
        {
            Console.WriteLine("Диапазон пересечения {0}", range.ToString());
        }
    }

    public static void PrintRangesArray(Range[] rangesArray)
    {
        int i = 1;

        foreach (Range range in rangesArray)
        {
            Console.WriteLine("Диапазон {0} = {1}", i, range.ToString());

            i++;
        }
    }

    static void Main(string[] args)
    {
        Range range1 = new Range(0, 20);

        PrintIsInside(range1.IsInside(5), range1.GetLength());

        Range range = new Range(10, 15);

        PrintIntersection(range1.GetIntersection(range));

        Range[] rangesUnification = range1.GetUnion(range);
        PrintRangesArray(rangesUnification);

        Range[] rangesDifference = range1.GetDifference(range);
        PrintRangesArray(rangesDifference);
    }
}