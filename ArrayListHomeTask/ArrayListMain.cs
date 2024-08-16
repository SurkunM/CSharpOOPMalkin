namespace ArrayListHomeTask;

internal class ArrayListMain
{
    public static void Reader(List<string> list, string patch)
    {
        using StreamReader reader = new StreamReader(patch);

        string? current = "";

        while ((current = reader.ReadLine()) != null)
        {
            list.Add(current);
        }
    }

    public static void RemoveEvenElements(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }

        list.TrimExcess();
    }

    public static List<int> GetRemoveDuplicates(List<int> numbers)
    {
        List<int> result = new List<int>();

        for (int i = 0; i < numbers.Count; i++)
        {
            if (!result.Contains(numbers[i]))
            {
                result.Add(numbers[i]);
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        List<string> list = new List<string>();
        Reader(list, "..\\..\\..\\TextFile\\Text.txt");

        Console.WriteLine(string.Join(Environment.NewLine, list));

        List<int> numbers1 = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 };
        RemoveEvenElements(numbers1);

        Console.WriteLine(string.Join(", ", numbers1));

        List<int> number2 = GetRemoveDuplicates(numbers1);

        Console.WriteLine(string.Join(", ", number2));
    }
}