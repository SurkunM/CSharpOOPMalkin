namespace TreeTask;

internal class TreeMain
{
    static void Main(string[] args)
    {
        BinaryTree<int> binaryTree = new BinaryTree<int>();

        binaryTree.Add(10);
        binaryTree.Add(11);
        binaryTree.Add(1);
        binaryTree.Add(5);
        binaryTree.Add(0);
        binaryTree.Add(4);
        binaryTree.Add(6);
        binaryTree.Add(7);
        binaryTree.Add(15);
        binaryTree.Add(12);
        binaryTree.Add(18);
        binaryTree.Add(4);
        binaryTree.Add(16);

        binaryTree.BreadthFirstSearch();
        binaryTree.Visit(binaryTree.GetRoot());
        binaryTree.DepthFirstSearch();
    }
}