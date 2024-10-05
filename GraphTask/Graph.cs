namespace GraphTask;

internal class Graph
{
    private readonly int[,] _items;

    public Graph(int[,] items)
    {
        _items = items;
    }

    public void BreadthFirstSearch(Action<int> action)
    {
        if (_items is null || _items.GetLength(1) == 0)
        {
            return;
        }

        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[_items.GetLength(0)];

        while (Array.IndexOf(visited, false) >= 0)
        {
            queue.Enqueue(Array.IndexOf(visited, false));

            while (queue.Count > 0)
            {
                int vertex = queue.Dequeue();

                if (visited[vertex])
                {
                    continue;
                }

                action(vertex);
                visited[vertex] = true;

                for (int i = 0; i < _items.GetLength(1); i++)
                {
                    if (_items[vertex, i] != 0 && !visited[i])
                    {
                        queue.Enqueue(i);
                    }
                }
            }
        }
    }

    public void DepthFirstSearch(Action<int> action)
    {
        if (_items is null || _items.GetLength(1) == 0)
        {
            return;
        }

        Stack<int> stack = new Stack<int>();
        bool[] visited = new bool[_items.GetLength(0)];

        while (Array.IndexOf(visited, false) >= 0)
        {
            stack.Push(Array.IndexOf(visited, false));

            while (stack.Count > 0)
            {
                int vertex = stack.Pop();

                if (visited[vertex])
                {
                    continue;
                }

                action(vertex);
                visited[vertex] = true;

                for (int i = _items.GetLength(1) - 1; i >= 0; i--)
                {
                    if (_items[vertex, i] != 0 && !visited[i])
                    {
                        stack.Push(i);
                    }
                }
            }
        }
    }

    public void DepthFirstSearchRecursive(Action<int> action)
    {
        if (_items is null || _items.GetLength(1) == 0)
        {
            return;
        }

        bool[] visited = new bool[_items.GetLength(0)];

        while (Array.IndexOf(visited, false) >= 0)
        {
            VisitingDepthFirstSearchRecursive(Array.IndexOf(visited, false), visited, action);
        }
    }

    private void VisitingDepthFirstSearchRecursive(int vertex, bool[] visited, Action<int> action)
    {
        visited[vertex] = true;
        action(vertex);

        for (int i = 0; i < _items.GetLength(1); i++)
        {
            if (_items[vertex, i] != 0 && !visited[i])
            {
                VisitingDepthFirstSearchRecursive(i, visited, action);
            }
        }
    }
}