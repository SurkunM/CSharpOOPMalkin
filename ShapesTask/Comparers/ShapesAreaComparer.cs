using ShapesTask.Shapes;

namespace ShapesTask.Compares;

internal class ShapesAreaComparer : IComparer<IShape>
{
    public int Compare(IShape? shape1, IShape? shape2)
    {
        if (shape1 is null && shape2 is not null)
        {
            return -1;
        }

        if (shape1 is not null && shape2 is null)
        {
            return 1;
        }

        if (ReferenceEquals(shape1, shape2))
        {
            return 0;
        }

        return shape1!.GetArea().CompareTo(shape2!.GetArea());
    }
}