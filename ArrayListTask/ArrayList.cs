using System.Collections;

namespace ArrayListTask;

internal class ArrayList<T> : IList<T>
{
    private T[] _items = [];

    private int _count;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            return _items[index];
        }

        set
        {
            if (index < 0 || index >= _count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            _items[index] = value;
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
            if (value < _count)
            {
                throw new ArgumentOutOfRangeException(nameof(value));
            }

            T[] newItems = new T[value];

            if (_count > 0)
            {
                Array.Copy(_items, newItems, _count);
            }

            _items = newItems;
        }
    }

    public bool IsReadOnly
    {
        get
        {
            return ((ICollection<T>)_items).IsReadOnly;
        }
    }

    public ArrayList() { }

    public ArrayList(int capacity)
    {
        if (capacity < _count)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity));
        }

        _items = new T[capacity];
    }

    public void Add(T item)
    {
        if (_count >= _items.Length)
        {
            IncreaseCapacity();
        }

        _items[_count] = item;
        _count++;
    }

    private void IncreaseCapacity()
    {
        Array.Resize(ref _items, _items.Length * 2);
    }

    public void Clear()
    {
        Array.Clear(_items, 0, _count);
        _count = 0;
    }

    public bool Contains(T item)
    {
        return IndexOf(item) >= 0;
    }

    public void CopyTo(T[] array, int index)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (index < 0 || index >= array.Length)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Array.Copy(_items, 0, array, index, array.Length - index);
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_items, item);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        if (_count >= _items.Length)
        {
            IncreaseCapacity();
        }

        Array.Copy(_items, index, _items, index + 1, _count - index);

        _items[index] = item;
        _count++;
    }

    public bool Remove(T item)
    {
        int removeItemIndex = IndexOf(item);

        if (removeItemIndex >= 0)
        {
            Array.Copy(_items, removeItemIndex + 1, _items, removeItemIndex, _count - removeItemIndex - 1);

            _items[_count - 1] = default!;
            _count--;
        }

        return removeItemIndex >= 0;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        Array.Copy(_items, index + 1, _items, index, _count - index - 1);

        _items[_count - 1] = default!;
        _count--;
    }

    public void TrimExcess()
    {
        if (_count < _items.Length * 0.9)
        {
            Capacity = _count;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        return (IEnumerator<T>)_items.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }
}