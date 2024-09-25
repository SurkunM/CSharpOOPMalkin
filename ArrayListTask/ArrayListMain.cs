namespace ArrayListTask;

internal class ArrayListMain
{
    static void Main(string[] args)
    {
        ArrayList<string> list1 = new ArrayList<string>(3) { "a", "bc", "cd" };
        ArrayList<string> list2 = new ArrayList<string>(1);

        list2.Add("f");
        list2[0] = "a";
        list2.Add("bc");
        list2.Insert(2, "cd");

        list1.Equals(list2);

        string[] stringsArray = new string[list2.Count * 2];
        list2.CopyTo(stringsArray, 3);

        list1.IndexOf("b");
        list1.Contains("a");

        list1.Remove("a");
        list1.RemoveAt(0);

        list1.Clear();
        list1.TrimExcess();

        Console.WriteLine(list1);
        Console.WriteLine(list2);
    }
}