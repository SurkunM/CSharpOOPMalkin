namespace ArrayListHomeTask;

internal class ArrayListMain
{
    public static List<string> GetListFromFile(string inputFile)
    {
        try
        {
            using StreamReader reader = new StreamReader(inputFile);

            List<string> list = new List<string>();

            string? currentLine;

            while ((currentLine = reader.ReadLine()) != null)
            {
                list.Add(currentLine);
            }

            return list;
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден");

            return [];
        }
    }

    public static void RemovingEvenElements(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] % 2 == 0)
            {
                list.RemoveAt(i);
            }
        }
    }

    public static List<T> RemovingDuplicates<T>(List<T> numbers)
    {
        List<T> result = new List<T>(numbers.Count);

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
        List<string> list = GetListFromFile("..\\..\\..\\TextFile\\Text.txt");

        Console.WriteLine(string.Join(Environment.NewLine, list));

        List<int> numbers = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 };
        RemovingEvenElements(numbers);

        Console.WriteLine(string.Join(", ", numbers));

        List<int> uniqueNumbers = RemovingDuplicates(numbers);
        Console.WriteLine(string.Join(", ", uniqueNumbers));
    }
}