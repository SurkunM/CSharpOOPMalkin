namespace GraphTask;

internal class Graph
{
    private readonly int[,] _items;

    public Graph(int[,] items)
    {
        if (items is null)
        {
            throw new ArgumentNullException(nameof(items));
        }

        if (items.GetLength(0) != items.GetLength(1))
        {
            throw new ArgumentException("Матрица смежности должна быть квадратной.", nameof(items));
        }

        _items = new int[items.GetLength(0), items.GetLength(0)];

        for (int i = 0; i < items.GetLength(0); i++)
        {
            for (int j = 0; j < items.GetLength(0); j++)
            {
                _items[i, j] = items[i, j];
            }
        }
    }

    public void BreadthFirstSearch(Action<int> action)
    {
        if (_items.GetLength(0) == 0)
        {
            return;
        }

        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[_items.GetLength(0)];

        for (int i = 0; i < visited.Length; i++)
        {
            if (visited[i])
            {
                continue;
            }

            queue.Enqueue(i);

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();

                if (visited[vertex])
                {
                    continue;
                }

                action(vertex);
                visited[vertex] = true;

                for (int j = 0; j < _items.GetLength(1); j++)
                {
                    if (_items[vertex, j] != 0 && !visited[j])
                    {
                        queue.Enqueue(j);
                    }
                }
            }
        }
    }

    public void DepthFirstSearch(Action<int> action)
    {
        if (_items.GetLength(0) == 0)
        {
            return;
        }

        Stack<int> stack = new Stack<int>();
        bool[] visited = new bool[_items.GetLength(0)];

        for (int i = 0; i < visited.Length; i++)
        {
            if (visited[i])
            {
                continue;
            }

            stack.Push(i);

            while (stack.Count > 0)
            {
                int vertex = stack.Pop();

                if (visited[vertex])
                {
                    continue;
                }

                action(vertex);
                visited[vertex] = true;

                for (int j = _items.GetLength(0) - 1; j >= 0; j--)
                {
                    if (_items[vertex, j] != 0 && !visited[j])
                    {
                        stack.Push(j);
                    }
                }
            }
        }
    }

    public void DepthFirstSearchRecursive(Action<int> action)
    {
        if (_items.GetLength(0) == 0)
        {
            return;
        }

        bool[] visited = new bool[_items.GetLength(0)];

        while (Array.IndexOf(visited, false) >= 0)
        {
            DepthFirstSearchRecursiveVisit(Array.IndexOf(visited, false), visited, action);
        }
    }

    private void DepthFirstSearchRecursiveVisit(int vertex, bool[] visited, Action<int> action)
    {
        visited[vertex] = true;
        action(vertex);

        for (int i = 0; i < _items.GetLength(0); i++)
        {
            if (_items[vertex, i] != 0 && !visited[i])
            {
                DepthFirstSearchRecursiveVisit(i, visited, action);
            }
        }
    }
}