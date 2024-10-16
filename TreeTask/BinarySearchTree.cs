using System.Text;

namespace TreeTask;

internal class BinarySearchTree<T>
{
    private TreeNode<T>? _root;

    private readonly IComparer<T>? _comparer;

    public int Count { get; private set; }

    public BinarySearchTree()
    {
        _comparer = Comparer<T>.Default;
    }

    public BinarySearchTree(IComparer<T> comparer)
    {
        if (comparer is null)
        {
            _comparer = Comparer<T>.Default;
        }

        _comparer = comparer;
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
            if (_comparer!.Compare(currentNode.Data, data) > 0)
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
        int comparisonResult = _comparer!.Compare(currentNode.Data, data);

        while (comparisonResult != 0)
        {
            if (comparisonResult > 0)
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

            comparisonResult = _comparer.Compare(currentNode.Data, data);
        }

        return true;
    }

    public bool Remove(T data)
    {
        if (_root is null)
        {
            return false;
        }

        TreeNode<T> currentNode = _root;
        TreeNode<T>? parentNode = null;

        bool isLeftNode = false;
        int comparerResult = _comparer!.Compare(currentNode.Data, data);

        while (comparerResult != 0)
        {
            parentNode = currentNode;

            if (comparerResult > 0)
            {
                if (currentNode.Left is not null)
                {
                    currentNode = currentNode.Left;
                    isLeftNode = true;
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
                    isLeftNode = false;
                }
                else
                {
                    return false;
                }
            }

            comparerResult = _comparer.Compare(currentNode.Data, data);
        }

        if (currentNode.Left is null && currentNode.Right is null)
        {
            InsertNode(parentNode, null, isLeftNode);
        }
        else if (currentNode.Left is null || currentNode.Right is null)
        {
            if (currentNode.Left is null)
            {
                InsertNode(parentNode, currentNode.Right, isLeftNode);
            }
            else
            {
                InsertNode(parentNode, currentNode.Left, isLeftNode);
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
                minLeftNodeParent.Left = minLeftNode.Right;
                minLeftNode.Right = currentNode.Right;
            }

            minLeftNode.Left = currentNode.Left;

            InsertNode(parentNode, minLeftNode, isLeftNode);
        }

        Count--;

        return true;
    }

    private void InsertNode(TreeNode<T>? parentNode, TreeNode<T>? currentNode, bool isLeftNode)
    {
        if (parentNode is null)
        {
            _root = currentNode;
        }
        else if (isLeftNode)
        {
            parentNode.Left = currentNode;
        }
        else
        {
            parentNode.Right = currentNode;
        }
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

    public void DepthFirstSearchRecursive(Action<T> action)
    {
        DepthFirstSearchRecursiveVisit(_root, action);
    }

    private static void DepthFirstSearchRecursiveVisit(TreeNode<T>? node, Action<T> action)
    {
        if (node is null)
        {
            return;
        }

        action(node.Data);

        DepthFirstSearchRecursiveVisit(node.Left, action);
        DepthFirstSearchRecursiveVisit(node.Right, action);
    }

    public override string ToString()
    {
        if (_root is null)
        {
            return "[]";
        }

        StringBuilder stringBuilder = new StringBuilder();

        const string separator = ", ";
        stringBuilder.Append('[');

        BreadthFirstSearch(node => stringBuilder.Append(node).Append(separator));

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }
}