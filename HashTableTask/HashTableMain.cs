namespace HashTableTask;

internal class HashTableMain
{
    static void Main(string[] args)
    {
        List<int> list1 = new List<int> { 13, 44 };
        List<int> list2 = list1;

        HashTable<List<int>> hashTable = new HashTable<List<int>>
        {
            new List<int> { 3, 4, 2, 4 },
            new List<int>(9)
        };

        hashTable.Add(list1);
        hashTable.Add(list2);

        hashTable.Contains(list1);
        hashTable.Remove(list1);
    }
}