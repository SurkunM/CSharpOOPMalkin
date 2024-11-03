namespace GraphTask;

internal class Graph
{
    private readonly int[,] _adjacencyMatrix;

    public Graph(int[,] adjacencyMatrix)
    {
        if (adjacencyMatrix is null)
        {
            throw new ArgumentNullException(nameof(adjacencyMatrix));
        }

        if (adjacencyMatrix.GetLength(0) != adjacencyMatrix.GetLength(1))
        {
            throw new ArgumentException("Матрица смежности должна быть квадратной.", nameof(adjacencyMatrix));
        }

        _adjacencyMatrix = new int[adjacencyMatrix.GetLength(0), adjacencyMatrix.GetLength(0)];

        Array.Copy(adjacencyMatrix, _adjacencyMatrix, adjacencyMatrix.Length);
    }

    public void BreadthFirstSearch(Action<int> action)
    {
        if (_adjacencyMatrix.GetLength(0) == 0)
        {
            return;
        }

        Queue<int> queue = new Queue<int>();
        bool[] visited = new bool[_adjacencyMatrix.GetLength(0)];

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

                for (int j = 0; j < _adjacencyMatrix.GetLength(1); j++)
                {
                    if (_adjacencyMatrix[vertex, j] != 0 && !visited[j])
                    {
                        queue.Enqueue(j);
                    }
                }
            }
        }
    }

    public void DepthFirstSearch(Action<int> action)
    {
        if (_adjacencyMatrix.GetLength(0) == 0)
        {
            return;
        }

        Stack<int> stack = new Stack<int>();
        bool[] visited = new bool[_adjacencyMatrix.GetLength(0)];

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

                for (int j = _adjacencyMatrix.GetLength(0) - 1; j >= 0; j--)
                {
                    if (_adjacencyMatrix[vertex, j] != 0 && !visited[j])
                    {
                        stack.Push(j);
                    }
                }
            }
        }
    }

    public void DepthFirstSearchRecursive(Action<int> action)
    {
        if (_adjacencyMatrix.GetLength(0) == 0)
        {
            return;
        }

        bool[] visited = new bool[_adjacencyMatrix.GetLength(0)];

        for (int i = 0; i < visited.Length; i++)
        {
            if (visited[i])
            {
                continue;
            }

            DepthFirstSearchRecursive(i, visited, action);
        }
    }

    private void DepthFirstSearchRecursive(int vertex, bool[] visited, Action<int> action)
    {
        visited[vertex] = true;
        action(vertex);

        for (int i = 0; i < _adjacencyMatrix.GetLength(0); i++)
        {
            if (_adjacencyMatrix[vertex, i] != 0 && !visited[i])
            {
                DepthFirstSearchRecursive(i, visited, action);
            }
        }
    }
}