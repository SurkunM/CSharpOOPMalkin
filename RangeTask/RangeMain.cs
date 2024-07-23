namespace Range_L1;

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
            Console.WriteLine("Диапазон пересечения {0}", range);
        }
    }

    public static void PrintRangesArray(Range[] rangesArray)
    {
        int i = 1;

        foreach (Range range in rangesArray)
        {
            Console.WriteLine("Диапазон {0} = {1}", i, range);

            i++;
        }
    }

    static void Main(string[] args)
    {
        double from1 = 0;
        double to1 = 20;
        double number = 5;

        Range range1 = new Range(from1, to1);

        PrintIsInside(range1.IsInside(number), range1.GetLength());

        double from2 = 10;
        double to2 = 15;

        Range range2 = new Range(from2, to2);

        PrintIntersection(range1.GetIntersection(range2));

        Range[] rangesUnification = new Range(from1, to1).GetUnification(range2);

        PrintRangesArray(rangesUnification);

        Range[] rangesDifference = new Range(from1, to1).GetDifference(range2);

        PrintRangesArray(rangesDifference);
    }
}