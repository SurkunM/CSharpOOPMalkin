using System.Collections;

namespace HashTableTask;

internal class HashTable<T> : ICollection<T>
{
    private List<T>[] _items = new List<T>[3];

    private int _count;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _items.Length)
            {
                throw new ArgumentOutOfRangeException(nameof(index));
            }

            return _items[index].Last();
        }

        set
        {
            _items[index].Add(value);
        }
    }

    public int Count
    {
        get { return _count; }
    }

    public int Capacity
    {
        get { return _items.Length; }

        set
        {
            if (value < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            List<T>[] newItem = new List<T>[value];

            if (_count > 0)
            {
                Array.Copy(_items, newItem, _count);
                _items = newItem;
            }

            _count = value;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            throw new NotImplementedException();
        }
    }

    public HashTable() { }

    public HashTable(int size)
    {
        if (size < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(size));
        }

        List<T>[] newItems = new List<T>[size];

        if (_count > 0)
        {
            Array.Copy(_items, newItems, _count);
            _items = newItems;
        }

        _items = new List<T>[size];
    }

    public void Add(T item)
    {
        if (_count >= _items.Length)
        {
            List<T>[] newItems = new List<T>[_count * 2];

            foreach (List<T> element in _items)
            {
                if (element is not null)
                {
                    for (int i = 0; i < element.Count; i++)
                    {
                        newItems[GetItemHashCode(element[i], newItems)] = [element[i]];
                    }
                }
            }

            _items = newItems;
        }

        int hash = GetItemHashCode(item, _items);

        if (_items[hash] is null)
        {
            _items[hash] = [item];
        }
        else
        {
            _items[hash].Add(item);
        }

        _count++;
    }

    private static int GetItemHashCode(T item, List<T>[] items)
    {
        return item is null ? 0 : Math.Abs(item.GetHashCode() % items.Length);
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _items.Length);
    }

    public bool Contains(T item)
    {
        if (item is null)
        {
            return _items[0].Contains(item);
        }

        return _items[GetItemHashCode(item, _items)].Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0 || array.Length - (arrayIndex + _count) < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex));
        }

        int currentIndex = arrayIndex;

        foreach (List<T> item in _items)
        {
            if (item is not null)
            {
                item.CopyTo(array, currentIndex);
                currentIndex += item.Count;
            }
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return new List<T>().GetEnumerator();
    }

    public bool Remove(T item)
    {
        return _items[GetItemHashCode(item, _items)].Remove(item);
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}