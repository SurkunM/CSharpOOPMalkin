using ShapesTask.ShapesInterface;

namespace ShapesTask.Comparators;

internal class ShapesAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (ReferenceEquals(shape1, null) || ReferenceEquals(shape2, null))
        {
            if (ReferenceEquals(shape1, shape2))
            {
                return 0;
            }

            return ReferenceEquals(shape1, null) ? -1 : 1;
        }

        return shape1.GetArea().CompareTo(shape2.GetArea());
    }
}