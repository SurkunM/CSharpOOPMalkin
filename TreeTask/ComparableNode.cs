using System.Collections;

namespace TreeTask;

internal class ComparableNode : IComparer<int>
{
    public int Compare(int x, int y)
    {
        return x.CompareTo(y);
    }
}