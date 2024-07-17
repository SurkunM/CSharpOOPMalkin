using static System.Runtime.InteropServices.JavaScript.JSType;
using System;

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

    public static void PrintIntersection(Range range)
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

    public static void PrintRangesArray(Range[] rangeArray)
    {
        if (rangeArray.Length == 0)
        {
            Console.WriteLine("Диапазонов нет");
        }
        else if (rangeArray.Length == 1)
        {
            Console.WriteLine(rangeArray[0].ToString());
        }
        else
        {
            Console.WriteLine(rangeArray[0].ToString());
            Console.WriteLine(rangeArray[1].ToString());
        }
    }

    static void Main(string[] args)
    {
        double from1 = 0;
        double to1 = 15;
        double number = 5;

        Range range1 = new Range(from1, to1);

        PrintIsInside(range1.IsInside(number), range1.GetLength());

        double from2 = 10;
        double to2 = 20;

        Range range2 = new Range(from2, to2);

        PrintIntersection(range1.GetIntersection(range2)!);

        Range[] rangeCombining = new Range(from1, to1).GetCombining(range2);

        PrintRangesArray(rangeCombining);

        Range[] rangeSubtraction = new Range(from1, to1).GetSubtraction(range2);

        PrintRangesArray(rangeSubtraction);
    }
}