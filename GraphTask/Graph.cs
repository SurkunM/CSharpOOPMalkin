namespace GraphTask;

internal class Graph
{
    private readonly int[,] _items =
        {
            {0 ,1 ,0 ,0 ,0 ,0 , 0},
            {1 ,0 ,1 ,1 ,1 ,1 , 0},
            {0 ,1 ,0 ,0 ,0 ,0 , 1},
            {0 ,1 ,0 ,0 ,0 ,0 , 0},
            {0 ,1 ,0 ,0 ,0 ,1 , 0},
            {0 ,1 ,0 ,0 ,1 ,0 , 1},
            {0 ,0 ,1 ,0 ,0 ,1 , 0}
        };

    public Graph() { }

    public void BreadthFirstSearch()
    {
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(0);

        bool[] visited = new bool[_items.GetLength(0)];

        while (queue.Count > 0)
        {
            int currentItem = queue.Dequeue();

            if (!visited[currentItem])
            {
                Console.WriteLine(currentItem);
                visited[currentItem] = true;

                for (int j = 0; j < _items.GetLength(1); j++)
                {
                    if (_items[currentItem, j] > 0)
                    {
                        queue.Enqueue(j);
                    }
                }
            }

            if (queue.Count == 0 && Array.IndexOf(visited, false) >= 0)
            {
                queue.Enqueue(Array.IndexOf(visited, false));
            }
        }
    }

    public void DepthFirstSearch()
    {
        Stack<int> stack = new Stack<int>();
        stack.Push(0);

        bool[] visited = new bool[_items.GetLength(0)];

        while (stack.Count > 0)
        {
            int currentItem = stack.Pop();

            if (!visited[currentItem])
            {
                Console.WriteLine(currentItem);
                visited[currentItem] = true;

                for (int j = _items.GetLength(1) - 1; j >= 0; j--)
                {
                    if (_items[currentItem, j] > 0)
                    {
                        stack.Push(j);
                    }
                }
            }

            if (stack.Count == 0 && Array.IndexOf(visited, false) >= 0)
            {
                stack.Push(Array.IndexOf(visited, false));
            }
        }
    }
}