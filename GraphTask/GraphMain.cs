namespace GraphTask;

internal class GraphMain
{
    static void Main(string[] args)
    {
        int[,] matrix =
        {
            { 0, 1, 0, 0, 0, 0, 0},
            { 1, 0, 1, 1, 1, 1, 0},
            { 0, 1, 0, 0, 0, 0, 1},
            { 0, 1, 0, 0, 0, 0, 0},
            { 0, 1, 0, 0, 0, 1, 0},
            { 0, 1, 0, 0, 1, 0, 1},
            { 0, 0, 1, 0, 0, 1, 0}
        };

        Graph graph = new Graph(matrix);

        graph.BreadthFirstSearch(Console.Write);
        Console.WriteLine();

        graph.DepthFirstSearch(Console.Write);
        Console.WriteLine();

        graph.DepthFirstSearchRecursive(Console.Write);
    }
}