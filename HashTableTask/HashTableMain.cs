namespace HashTableTask;

internal class HashTableMain
{
    static void Main(string[] args)
    {
        HashTable<int> hashTable = new HashTable<int>(10) { 0, 1, 2, 3, 4, 5 };

        hashTable.Add(21);
        hashTable.Add(22);
        Console.WriteLine(hashTable);

        hashTable.Contains(21);
        hashTable.Remove(22);
        Console.WriteLine(hashTable);

        hashTable.Clear();
        Console.WriteLine(hashTable);
    }
}