namespace ArrayListHomeTask;

internal class ArrayListHomeMain
{
    public static List<string> GetListFromFile(string inputFile)
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

    public static void RemovedEvenNumbers(List<int> list)
    {
        for (int i = 0; i < list.Count; i++)
        {
            if (list[i] % 2 == 0)
            {
                list.RemoveAt(i);
                i--;
            }
        }
    }

    public static List<T> GetDuplicatesRemoved<T>(List<T> list)
    {
        List<T> result = new List<T>(list.Count);

        foreach (T element in list)
        {
            if (!result.Contains(element))
            {
                result.Add(element);
            }
        }

        return result;
    }

    static void Main(string[] args)
    {
        try
        {
            List<string> stringsList = GetListFromFile("..\\..\\..\\TextFile\\Text.txt");

            Console.WriteLine(string.Join(Environment.NewLine, stringsList));
        }
        catch (FileNotFoundException)
        {
            Console.WriteLine("Файл не найден");
        }
        catch (ArgumentNullException)
        {
            Console.WriteLine("Не найден путь к файлу");
        }

        List<int> numbers = new List<int> { 1, 1, 2, 3, 4, 5, 6, 7, 8, 9, 0, 1 };
        RemovedEvenNumbers(numbers);

        Console.WriteLine(string.Join(", ", numbers));

        List<int> uniqueNumbers = GetDuplicatesRemoved(numbers);
        Console.WriteLine(string.Join(", ", uniqueNumbers));
    }
}