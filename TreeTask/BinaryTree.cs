namespace TreeTask;

internal class BinaryTree<T>
{
    private TreeNode<T>? _rootNode;

    private int _count;

    public BinaryTree() { }

    public TreeNode<T>? GetRoot()
    {
        return _rootNode;
    }

    public void Add(T data)
    {
        if (_rootNode is null)
        {
            _rootNode = new TreeNode<T>(data);
            _count++;

            return;
        }

        TreeNode<T> currentNode = _rootNode;

        while (true)
        {
            if (currentNode.CompareTo(data) > 0)
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

        _count++;
    }

    public TreeNode<T>? Search(T data)
    {
        if (_rootNode is null)
        {
            throw new ArgumentNullException(nameof(_rootNode));
        }

        TreeNode<T> currentNode = _rootNode;

        while (currentNode.CompareTo(data) != 0)
        {
            if (currentNode.CompareTo(data) > 0)
            {
                if (currentNode.Left is not null)
                {
                    currentNode = currentNode.Left;
                }
                else
                {
                    throw new ArgumentOutOfRangeException(nameof(data));
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
                    throw new ArgumentOutOfRangeException(nameof(data));
                }
            }
        }

        return currentNode;
    }

    public void Remove(T data)
    {
        if (_rootNode is null)
        {
            throw new ArgumentNullException(nameof(_rootNode));
        }

        TreeNode<T> currentNode = _rootNode;
        bool isLeftNode = false;

        while (true)
        {
            TreeNode<T> parentNode = currentNode;

            if (currentNode.CompareTo(data) > 0)
            {
                if (currentNode.Left is not null)
                {
                    currentNode = currentNode.Left;
                    isLeftNode = true;
                }
            }
            else if (currentNode.CompareTo(data) < 0)
            {
                if (currentNode.Right is not null)
                {
                    currentNode = currentNode.Right;
                    isLeftNode = false;
                }
            }

            if (currentNode.CompareTo(data) == 0)
            {
                if (currentNode.Left is null && currentNode.Right is null)
                {
                    if (isLeftNode)
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
                    if (isLeftNode)
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
                    TreeNode<T>? parentMinLeftNode = null;

                    while (minLeftNode.Left != null)
                    {
                        parentMinLeftNode = minLeftNode;
                        minLeftNode = minLeftNode.Left;
                    }

                    if (parentMinLeftNode is not null)
                    {
                        parentMinLeftNode.Left = minLeftNode.Right is null ? null : minLeftNode.Right;

                        minLeftNode.Right = currentNode.Right;
                    }

                    minLeftNode.Left = currentNode.Left;

                    if (ReferenceEquals(currentNode, parentNode))
                    {
                        _rootNode = minLeftNode;
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

                break;
            }
        }
    }

    public void BreadthFirstSearch()
    {
        if (_rootNode is null)
        {
            throw new ArgumentNullException(nameof(_rootNode));
        }

        Queue<TreeNode<T>> queue = new Queue<TreeNode<T>>();

        queue.Enqueue(_rootNode);

        while (queue.Count > 0)
        {
            TreeNode<T> currentNode = queue.Dequeue();

            Console.WriteLine(currentNode.Data);

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

    public void DepthFirstSearch()
    {
        if (_rootNode is null)
        {
            throw new ArgumentNullException(nameof(_rootNode));
        }

        Stack<TreeNode<T>> stack = new Stack<TreeNode<T>>();
        stack.Push(_rootNode);

        while (stack.Count > 0)
        {
            TreeNode<T> currentNode = stack.Pop();

            Console.WriteLine(currentNode.Data);

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

    public void Visit(TreeNode<T>? node)
    {
        if (node is null)
        {
            return;
        }

        Console.WriteLine(node.Data);

        Visit(node.Left);
        Visit(node.Right);
    }
}