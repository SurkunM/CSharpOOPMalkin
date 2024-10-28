namespace LambdasTask;

internal class LambdasMain
{
    public static IEnumerable<double> GetSquareRoots()
    {
        int i = 0;

        while (true)
        {
            yield return Math.Sqrt(i);
            i++;
        }
    }

    static void Main(string[] args)
    {
        List<Person> personsList = new List<Person>
        {
            new("Ivan", 34),
            new("Sergey", 28),
            new("Alexander", 17),
            new("Alina", 16),
            new("Natalya", 29),
            new("Ivan", 22)
        };

        List<string> uniqueNamesList = personsList
            .Select(p => p.Name)
            .Distinct()
            .ToList();

        Console.WriteLine("Имена: {0}.", string.Join(", ", uniqueNamesList));

        List<Person> under18PersonsList = personsList
            .Where(p => p.Age < 18)
            .ToList();

        if (under18PersonsList.Count == 0)
        {
            Console.WriteLine("В данном списке нет людей младше 18");
        }
        else
        {
            Console.WriteLine("Средний возраст людей младше 18: {0}", under18PersonsList.Average(p => p.Age));
        }

        Dictionary<string, double> averageAgesByNames = personsList
            .GroupBy(p => p.Name)
            .ToDictionary(p => p.Key, p => p.Average(p => p.Age));

        Console.WriteLine("Сгруппированный список сотрудников по именам и их средний возраст: {0}", string.Join(", ", averageAgesByNames));

        IEnumerable<Person> from18To45AgePersons = personsList
            .Where(p => p.Age >= 20 && p.Age <= 45)
            .OrderByDescending(p => p.Age);

        Console.WriteLine("Список сотрудников возраст которых от 20 до 45: {0}", string.Join(", ", from18To45AgePersons.Select(p => p.Name)));

        Console.WriteLine();
        Console.Write("Введите количество элементов для которых нужно вычислить квадратные корни: ");
        int squareRootsCount = Convert.ToInt32(Console.ReadLine());

        IEnumerable<double> squareRoots = GetSquareRoots().Take(squareRootsCount);

        Console.WriteLine("Результат вычисления {0}", string.Join(", ", squareRoots));
    }
}