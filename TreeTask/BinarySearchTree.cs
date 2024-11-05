using System.Text;

namespace TreeTask;

internal class BinarySearchTree<T>
{
    private TreeNode<T>? _root;

    private readonly IComparer<T> _comparer;

    public int Count { get; private set; }

    public BinarySearchTree()
    {
        _comparer = Comparer<T>.Default;
    }

    public BinarySearchTree(IComparer<T>? comparer)
    {
        _comparer = comparer ?? Comparer<T>.Default;
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
            if (_comparer.Compare(currentNode.Data, data) > 0)
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
        int comparisonResult = _comparer.Compare(currentNode.Data, data);

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
        int comparisonResult = _comparer.Compare(currentNode.Data, data);

        while (comparisonResult != 0)
        {
            parentNode = currentNode;

            if (comparisonResult > 0)
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

            comparisonResult = _comparer.Compare(currentNode.Data, data);
        }

        if (currentNode.Left is null || currentNode.Right is null)
        {
            TreeNode<T>? childNode = currentNode.Left is null ? currentNode.Right : currentNode.Left;

            ReplaceNode(parentNode, childNode, isLeftNode);
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

            ReplaceNode(parentNode, minLeftNode, isLeftNode);
        }

        Count--;

        return true;
    }

    private void ReplaceNode(TreeNode<T>? parentNode, TreeNode<T>? insertNode, bool isLeftNode)
    {
        if (parentNode is null)
        {
            _root = insertNode;
        }
        else if (isLeftNode)
        {
            parentNode.Left = insertNode;
        }
        else
        {
            parentNode.Right = insertNode;
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
        DepthFirstSearchRecursive(_root, action);
    }

    private static void DepthFirstSearchRecursive(TreeNode<T>? node, Action<T> action)
    {
        if (node is null)
        {
            return;
        }

        action(node.Data);

        DepthFirstSearchRecursive(node.Left, action);
        DepthFirstSearchRecursive(node.Right, action);
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