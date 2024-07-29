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

    public Range? GetIntersection(Range range)
    {
        if (Math.Max(From, range.From) < Math.Min(To, range.To))
        {
            return new Range(Math.Max(From, range.From), Math.Min(To, range.To));
        }

        return null;
    }

    public Range[] GetUnion(Range range)
    {
        if (Math.Max(From, range.From) <= Math.Min(To, range.To))
        {
            return [new Range(Math.Min(From, range.From), Math.Max(To, range.To))];
        }

        return [new Range(From, To), new Range(range.From, range.To)];
    }

    public Range[] GetDifference(Range range)
    {
        if (Math.Max(From, range.From) < Math.Min(To, range.To))
        {
            if (From < range.From)
            {
                if (To > range.To)
                {
                    return [new Range(From, range.From), new Range(range.To, To)];
                }

                if (To <= range.To)
                {
                    return [new Range(From, range.From)];
                }
            }

            if (From >= range.From)
            {
                if (To > range.To)
                {
                    return [new Range(range.To, To)];
                }

                if (To <= range.To)
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