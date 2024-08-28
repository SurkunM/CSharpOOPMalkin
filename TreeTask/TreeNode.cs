namespace TreeTask;

internal class TreeNode<T> : IComparable<T>
{
    public TreeNode<T>? Left { get; set; }

    public TreeNode<T>? Right { get; set; }

    public T Data { get; }

    public TreeNode(T value)
    {
        Data = value;
    }

    public int CompareTo(T? data)
    {
        return ((IComparable<T>)Data!).CompareTo(data);
    }
}