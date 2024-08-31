namespace GraphTask;

internal class GraphMain
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        graph.RecursionDepthFirstSearch();
        graph.BreadthFirstSearch();
        graph.DepthFirstSearch();
    }
}