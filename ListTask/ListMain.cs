namespace ListTask;

internal class ListMain
{
    static void Main(string[] args)
    {
        SinglyLinkedList<string> singlyList = new SinglyLinkedList<string>();

        singlyList.Add("FourthItem");
        singlyList.Add("SecondItem");
        singlyList.Add("FirstItem");

        singlyList.Revers();

        singlyList.Remove("FirstItem");
        singlyList.RemoveAt(0);
    }
}