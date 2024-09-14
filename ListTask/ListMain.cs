namespace ListTask;

internal class ListMain
{
    static void Main(string[] args)
    {
        SinglyLinkedList<string> singlyList = new SinglyLinkedList<string>();

        singlyList.AddFirst("FourthItem");
        singlyList.AddFirst("ThirdItem");
        singlyList.AddFirst("SecondItem");
        singlyList.AddFirst("FirstItem");

        Console.WriteLine(singlyList);

        SinglyLinkedList<string> list = singlyList.Copy();
        Console.WriteLine(list);

        singlyList.Remove("FourthItem");
        singlyList.Reverse();
    }
}