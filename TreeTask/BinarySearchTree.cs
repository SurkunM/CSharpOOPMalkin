using System.Text;

namespace TreeTask;

internal class BinarySearchTree<T>
{
    private TreeNode<T>? _root;

    private readonly IComparer<T>? _comparable;

    public int Count { get; private set; }

    public BinarySearchTree() { }

    public BinarySearchTree(IComparer<T> comparer)
    {
        if (comparer is null)
        {
            throw new ArgumentNullException(nameof(comparer));
        }

        _comparable = comparer;
    }

    public void Add(T data)
    {
        if (_root is null)
        {
            _root = new TreeNode<T>(data);
            Count++;

            return;
        }

        TreeNode<T> currentNode = _root;

        while (true)
        {
            if (Comparer(currentNode.Data, data) > 0)
            {
                if (currentNode.Left is not null)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    currentNode.Left = new TreeNode<T>(data);

                    break;
                }
            }
            else
            {
                if (currentNode.Right is not null)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    currentNode.Right = new TreeNode<T>(data);

                    break;
                }
            }
        }

        Count++;
    }

    public bool Contains(T data)
    {
        if (_root is null)
        {
            return false;
        }

        TreeNode<T> currentNode = _root;
        int i = Comparer(currentNode.Data, data);

        while (i != 0)
        {
            if (i > 0)
            {
                if (currentNode.Left is not null)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                if (currentNode.Right is not null)
                {
                    currentNode = currentNode.Right;
                }
                else
                {
                    return false;
                }
            }

            i = Comparer(currentNode.Data, data);
        }

        return true;
    }

    public void Remove(T data)
    {
        if (_root is null)
        {
            return;
        }

        TreeNode<T> currentNode = _root;
        TreeNode<T>? parentNode = null;

        bool isLeftNode = false;
        int i = Comparer(currentNode.Data, data);

        while (i != 0)
        {
            parentNode = currentNode;

            if (i > 0)
            {
                if (currentNode.Left is not null)
                {
                    currentNode = currentNode.Left;
                    isLeftNode = true;
                }
                else
                {
                    return;
                }
            }
            else if (i < 0)
            {
                if (currentNode.Right is not null)
                {
                    currentNode = currentNode.Right;
                    isLeftNode = false;
                }
                else
                {
                    return;
                }
            }

            i = Comparer(currentNode.Data, data);
        }

        if (currentNode.Left is null && currentNode.Right is null)
        {
            if (parentNode is null)
            {
                _root = null;
            }
            else if (isLeftNode)
            {
                parentNode.Left = null;
            }
            else
            {
                parentNode.Right = null;
            }
        }
        else if (currentNode.Left is null || currentNode.Right is null)
        {
            if (parentNode is null)
            {
                _root = currentNode.Left is not null ? currentNode.Left : currentNode.Right;
            }
            else if (isLeftNode)
            {
                if (currentNode.Left is null)
                {
                    parentNode.Left = currentNode.Right;
                }
                else
                {
                    parentNode.Left = currentNode.Left;
                }
            }
            else
            {
                if (currentNode.Left is null)
                {
                    parentNode.Right = currentNode.Right;
                }
                else
                {
                    parentNode.Right = currentNode.Left;
                }
            }
        }
        else
        {
            TreeNode<T> minLeftNode = currentNode.Right;
            TreeNode<T> minLeftNodeParent = currentNode;

            while (minLeftNode.Left != null)
            {
                minLeftNodeParent = minLeftNode;
                minLeftNode = minLeftNode.Left!;
            }

            if (minLeftNodeParent != currentNode)
            {
                if (minLeftNode.Right is null)
                {
                    minLeftNodeParent.Left = null;
                }
                else
                {
                    minLeftNodeParent.Left = minLeftNode.Right;
                }

                minLeftNode.Right = currentNode.Right;
            }

            minLeftNode.Left = currentNode.Left;

            if (parentNode is null)
            {
                _root = minLeftNode;
            }
            else
            {
                if (isLeftNode)
                {
                    parentNode.Left = minLeftNode;
                }
                else
                {
                    parentNode.Right = minLeftNode;
                }
            }
        }

        Count--;
    }

    public void BreadthFirstSearch(Action<T> action)
    {
        if (_root is null)
        {
            return;
        }

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

        queue.Enqueue(_root);

        while (queue.Count > 0)
        {
            TreeNode<T> currentNode = queue.Dequeue();

            action(currentNode.Data);

            if (currentNode.Left is not null)
            {
                queue.Enqueue(currentNode.Left);
            }

            if (currentNode.Right is not null)
            {
                queue.Enqueue(currentNode.Right);
            }
        }
    }

    public void DepthFirstSearch(Action<T> action)
    {
        if (_root is null)
        {
            return;
        }

        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        stack.Push(_root);

        while (stack.Count > 0)
        {
            TreeNode<T> currentNode = stack.Pop();

            action(currentNode.Data);

            if (currentNode.Right is not null)
            {
                stack.Push(currentNode.Right);
            }

            if (currentNode.Left is not null)
            {
                stack.Push(currentNode.Left);
            }
        }
    }

    public void Visit(Action<T> action)
    {
        VisitRecursion(_root, action);
    }

    private static void VisitRecursion(TreeNode<T>? node, Action<T> action)
    {
        if (node is null)
        {
            return;
        }

        action(node.Data);

        VisitRecursion(node.Left, action);
        VisitRecursion(node.Right, action);
    }

    private int Comparer(T data1, T data2)
    {
        if (_comparable is not null)
        {
            return _comparable.Compare(data1, data2);
        }

        if (data1 is null && data2 is not null)
        {
            return -1;
        }

        if (data1 is not null && data2 is null)
        {
            return 1;
        }

        if (data1 is null && data2 is null)
        {
            return 0;
        }

        return ((IComparable<T>)data1!).CompareTo(data2);
    }

    public override string ToString()
    {
        if (Count <= 0)
        {
            return "";
        }

        StringBuilder stringBuilder = new StringBuilder();

        string separator = ", ";

        BreadthFirstSearch(node => stringBuilder.Append(node).Append(separator));

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);

        return stringBuilder.ToString();
    }
}