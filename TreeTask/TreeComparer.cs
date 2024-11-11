namespace TreeTask
{
    internal class TreeComparer : IComparer<int>
    {
        public int Compare(int data1, int data2)
        {

            return data1.CompareTo(data2);
        }
    }
}
