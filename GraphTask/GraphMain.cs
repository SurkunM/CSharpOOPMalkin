namespace GraphTask;

internal class GraphMain
{
    static void Main(string[] args)
    {
        Graph graph = new Graph();

        graph.BreadthFirstSearch();
        graph.DepthFirstSearch();
    }
}