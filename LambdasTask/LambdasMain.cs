namespace LambdasTask;

internal class LambdasMain
{
    public static IEnumerable<double> GetSquareRoot()
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
            new ("Ivan", 34),
            new("Sergey", 28),
            new("Alexander", 17),
            new ("Alina", 16),
            new ("Natalya", 29),
            new ("Ivan", 22)
        };

        List<string> uniqueNamesList = personsList
            .Select(person => person.Name)
            .Distinct()
            .ToList();

        Console.WriteLine("Имена: {0}", string.Join(", ", uniqueNamesList));

        List<Person> under18PersonsList = personsList
            .Where(person => person.Age < 18)
            .ToList();

        double under18PersonsAverageAge = under18PersonsList.Count == 0 ? 0 : under18PersonsList.Average(person => person.Age);

        Console.WriteLine("Средний возраст: {0}", under18PersonsAverageAge);

        Dictionary<string, double> personsByGroupNameAndAverageAge = personsList
            .GroupBy(person => person.Name)
            .ToDictionary(personsName => personsName.Key, personsAge => personsAge.Average(p => p.Age));

        Console.WriteLine("Сгруппированный список сотрудников по именам и их средний возраст: {0}", string.Join(", ", personsByGroupNameAndAverageAge));

        IEnumerable<Person> between18And45AgePersons = personsList
            .Where(person => person.Age >= 20 && person.Age <= 45)
            .OrderByDescending(persons => persons.Age);

        Console.WriteLine("Список сотрудников возраст которых от 20 до 45: {0}", string.Join(", ", between18And45AgePersons.Select(p => p.Name)));

        Console.Write("Введите количество элементов для которых нужно вычислить квадратные корни: ");
        int elementsCount = Convert.ToInt32(Console.ReadLine());

        IEnumerable<double> elements = GetSquareRoot().Take(elementsCount);

        Console.WriteLine("Результат вычисления {0}", string.Join(", ", elements.ToList()));
    }
}