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

                for (int i = 0; i < _items.GetLength(1); i++)
                {
                    if (_items[currentItem, i] > 0)
                    {
                        queue.Enqueue(i);
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

                for (int i = _items.GetLength(1) - 1; i >= 0; i--)
                {
                    if (_items[currentItem, i] > 0)
                    {
                        stack.Push(i);
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