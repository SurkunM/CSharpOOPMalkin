namespace RangeTask;

internal class Range
{
    public double From { get; set; }

    public double To { get; set; }

    public Range(double from, double to)
    {
        From = from;
        To = to;
    }

    public Range? GetIntersection(Range range2)
    {
        if (Math.Max(From, range2.From) < Math.Min(To, range2.To))
        {
            return new Range(Math.Max(From, range2.From), Math.Min(To, range2.To));
        }

        return null;
    }

    public Range[] GetUnion(Range range2)
    {
        if (Math.Max(From, range2.From) <= Math.Min(To, range2.To))
        {
            return [new Range(Math.Min(From, range2.From), Math.Max(To, range2.To))];
        }

        return [new Range(From, To), new Range(range2.From, range2.To)];
    }

    public Range[] GetDifference(Range range2)
    {
        if (Math.Max(From, range2.From) < Math.Min(To, range2.To))
        {
            if (From < range2.From)
            {
                if (To > range2.To)
                {
                    return [new Range(From, range2.From), new Range(range2.To, To)];
                }

                if (To <= range2.To)
                {
                    return [new Range(From, range2.From)];
                }
            }

            if (From >= range2.From)
            {
                if (To > range2.To)
                {
                    return [new Range(range2.To, To)];
                }

                if (To <= range2.To)
                {
                    return [];
                }
            }
        }

        return [new Range(From, To)];
    }

    public double GetLength()
    {
        return To - From;
    }

    public bool IsInside(double number)
    {
        return number >= From && number <= To;
    }

    public override string? ToString()
    {
        return $"({From}; {To})".ToString();
    }
}