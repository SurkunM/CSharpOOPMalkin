namespace LambdasTask;

internal class LambdasMain
{
    public static IEnumerable<double> GetSqrt()
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

        List<string> uniquePerson = personsList
                                        .Select(person => person.Name)
                                        .Distinct()
                                        .ToList();

        uniquePerson.ForEach(person =>
        {
            if (person.Equals(uniquePerson.First()))
            {
                Console.Write("Имена: ");
            }
            else if (person.Equals(uniquePerson.Last()))
            {
                Console.WriteLine($"{person}.");
            }
            else
            {
                Console.Write($"{person}, ");
            }
        });

        double personsAgeAverage = personsList
                                        .Where(person => person.Age < 18)
                                        .Average(person => person.Age);

        Dictionary<string, double> personsDictionary = personsList
                                                            .GroupBy(person => person.Name)
                                                            .ToDictionary(person => person.Key,
                                                             person => person.Average(p => p.Age));

        IEnumerable<Person> persons = personsList
                                            .Where(person => person.Age >= 20 && person.Age < 45)
                                            .OrderByDescending(persons => persons.Age);

        int count = Convert.ToInt32(Console.ReadLine());
        int i = 0;

        foreach (double number in GetSqrt())
        {
            Console.WriteLine(number);

            if (i == count)
            {
                break;
            }

            i++;
        }
    }
}