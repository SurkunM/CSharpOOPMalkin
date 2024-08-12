using ShapesTask.ShapesClasses;

namespace ShapesTask.Comparators;

internal class ShapesAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 is null)
        {
            return -1;
        }

        if (shape2 is null)
        {
            return 1;
        }

        if (ReferenceEquals(shape1, shape2))
        {
            return 0;
        }

        return shape1.GetArea().CompareTo(shape2.GetArea());
    }
}