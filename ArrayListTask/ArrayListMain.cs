namespace ArrayListTask;

internal class ArrayListMain
{
    static void Main(string[] args)
    {
        ArrayList<string> list = new ArrayList<string>(4) { "a", "bc", "cd" };

        string[] stringsArray = new string[list.Count * 2];

        list[0] = "q";

        list.CopyTo(stringsArray, 0);

        list.Clear();

        list.Add("a");
        list.Insert(0, "b");

        list.Contains("a");
        list.IndexOf("b");

        list.Remove("a");
        list.RemoveAt(0);
        list.TrimExcess();
    }
}