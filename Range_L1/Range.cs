using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Range_L1;

internal class Range
{
    public Range? FirstRange { get; set; }

    public double FirstFrom { get; set; }

    public double FirstTo { get; set; }

    public Range? SecondRange { get; set; }

    public double SecondFrom { get; set; }

    public double SecondTo { get; set; }

    public Range(double from, double to)
    {
        FirstFrom = from;
        FirstTo = to;
    }

    public Range(Range firstRange, Range secondRange)
    {
        FirstRange = firstRange;

        FirstFrom = FirstRange.FirstFrom;
        FirstTo = FirstRange.FirstTo;

        SecondRange = secondRange;

        SecondFrom = SecondRange.FirstFrom;
        SecondTo = SecondRange.FirstTo;
    }

    public Range GetIntersectionRange()
    {
        if (FirstTo > SecondFrom && SecondTo > FirstFrom)
        {
            if (FirstFrom < SecondFrom)
            {
                if (FirstTo < SecondTo)
                {
                    return new Range(SecondFrom, FirstTo);
                }
                else
                {
                    return new Range(SecondFrom, SecondTo);
                }
            }
            else
            {
                if (FirstTo < SecondTo)
                {
                    return new Range(FirstFrom, FirstTo);
                }
                else
                {
                    return new Range(FirstFrom, SecondTo);
                }
            }
        }

        return null;
    }

    public Range[] CombiningRange()
    {
        if (FirstTo > SecondFrom && SecondTo > FirstFrom)
        {
            if (FirstFrom < SecondFrom)
            {
                if (FirstTo > SecondTo)
                {
                    return [new Range(FirstFrom, FirstTo)];
                }
                else
                {
                    return [new Range(FirstFrom, SecondTo)];
                }
            }
            else
            {
                if (FirstTo > SecondTo)
                {
                    return [new Range(SecondFrom, FirstTo)];
                }
                else
                {
                    return [new Range(SecondFrom, SecondTo)];
                }
            }
        }

        return [FirstRange, SecondRange];
    }

    public Range[] SubtractionRange()
    {
        if (FirstTo > SecondFrom && SecondTo > FirstFrom)
        {
            if (FirstFrom < SecondFrom)
            {
                if (FirstTo > SecondTo)
                {
                    return [new Range(FirstFrom, SecondFrom), new Range(SecondTo, FirstTo)];
                }
                else
                {
                    return [new Range(FirstFrom, SecondFrom)];
                }
            }
            else
            {
                if (FirstTo > SecondTo)
                {
                    return [new Range(SecondTo, FirstTo)];
                }
                else
                {
                    return [];
                }
            }
        }

        return [FirstRange];
    }

    public double GetLength()
    {
        return FirstTo - FirstFrom;
    }

    public bool IsInside(double number)
    {
        return number > FirstFrom && number < FirstTo ? true : false;
    }

    public void PrintRangeLength()
    {
        Console.WriteLine("Range length = {0}", GetLength());
    }

    public void PrintRangeInterval()
    {
        Console.WriteLine("{0} - {1}", FirstFrom, FirstTo);
    }

    public static void PrintRangeArray(Range[] rangeArray)
    {
        if (rangeArray.Length == 0)
        {
            Console.WriteLine("Интервалов нет");
        }
        else if (rangeArray.Length == 1)
        {
            rangeArray[0].PrintRangeInterval();
        }
        else
        {
            rangeArray[0].PrintRangeInterval();
            rangeArray[1].PrintRangeInterval();
        }
    }
}