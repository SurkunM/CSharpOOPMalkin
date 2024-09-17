namespace TreeTask;

internal class TreeMain
{
    static void Main(string[] args)
    {
        BinarySearchTree<int> binaryTree = new BinarySearchTree<int>();

        binaryTree.Add(8);
        binaryTree.Add(3);
        binaryTree.Add(10);
        binaryTree.Add(1);
        binaryTree.Add(6);
        binaryTree.Add(14);
        binaryTree.Add(4);
        binaryTree.Add(7);
        binaryTree.Add(13);
        Console.WriteLine(binaryTree);

        binaryTree.Remove(8);
        binaryTree.Contains(12);
        Console.WriteLine(binaryTree);
    }
}