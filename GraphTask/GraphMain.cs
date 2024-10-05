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

        graph.BreadthFirstSearch(x => Console.WriteLine(x));

        graph.DepthFirstSearch(x => Console.WriteLine(x));
        graph.DepthFirstSearchRecursive(x => Console.WriteLine(x));
    }
}