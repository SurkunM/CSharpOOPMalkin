namespace Range_L1;

internal class RangeMain
{
    static void Main(string[] args)
    {
        double firstFrom = 0;
        double firstTo = 15;

        double secondFrom = 10;
        double secondTo = 20;

        Range firstRange = new Range(firstFrom, firstTo);

        double number = 5;

        if (firstRange.IsInside(number))
        {
            Console.WriteLine("Число принадлежит диапазону длинна которой {0}", firstRange.GetLength());
        }
        else
        {
            Console.WriteLine("Число не принадлежит диапазону длинна которой {0}", firstRange.GetLength());

        }

        Range secondRange = new Range(secondFrom, secondTo);

        Range rangeInterval = new Range(firstRange, secondRange).GetIntersectionRange();

        if (rangeInterval == null)
        {
            Console.WriteLine("Интервалы не пересекаются");
        }
        else
        {
            rangeInterval.PrintRangeInterval();
        }

        Range[] rangeCombining = new Range(firstRange, secondRange).CombiningRange();
        Range.PrintRangeArray(rangeCombining);

        Range[] rangeSubtraction = new Range(firstRange, secondRange).SubtractionRange();
        Range.PrintRangeArray(rangeSubtraction);
    }
}