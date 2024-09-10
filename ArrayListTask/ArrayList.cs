using System.Collections;

namespace ArrayListTask;

internal class ArrayList<T> : IList<T>
{
    private T[] _items = [];

    public int Count { get; private set; }

    private int _modCount;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ коллекции");
            }

            return _items[index];
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ коллекции");
            }

            _items[index] = value;

            _modCount++;
        }
    }

    public int Capacity
    {
        get => _items.Length;

        set
        {
            if (value < Count)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "Вместимость списка не может быть меньше количества существующих элементов");
            }

            Array.Resize(ref _items, value);
        }
    }

    public bool IsReadOnly
    {
        get => false;
    }

    public ArrayList() { }

    public ArrayList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Вместимость списка не может быть меньше нуля");
        }

        _items = new T[capacity];
    }

    public void Add(T item)
    {
        if (Count >= _items.Length)
        {
            IncreaseCapacity();
        }

        _items[Count] = item;

        Count++;
        _modCount++;
    }

    private void IncreaseCapacity()
    {
        if (_items.Length == 0)
        {
            _items = new T[1];
        }

        Array.Resize(ref _items, _items.Length * 2);
    }

    public void Clear()
    {
        if (Count > 0)
        {
            Array.Clear(_items, 0, Count);

            Count = 0;
            _modCount = 0;
        }
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
            throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ коллекции");
        }

        Array.Copy(_items, 0, array, index, Count);
    }

    public int IndexOf(T item)
    {
        return Array.IndexOf(_items, item, 0, Count);
    }

    public void Insert(int index, T item)
    {
        if (index < 0 || index > Count)
        {
            throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ коллекции");
        }

        if (Count >= _items.Length)
        {
            IncreaseCapacity();
        }

        Array.Copy(_items, index, _items, index + 1, Count - index);

        _items[index] = item;

        Count++;
        _modCount++;
    }

    public bool Remove(T item)
    {
        int removeItemIndex = IndexOf(item);

        if (removeItemIndex >= 0)
        {
            RemoveAt(removeItemIndex);

            return true;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ коллекции");
        }

        Array.Copy(_items, index + 1, _items, index, Count - index - 1);

        _items[Count - 1] = default!;

        Count--;
        _modCount--;
    }

    public void TrimExcess()
    {
        if (Count < _items.Length * 0.9)
        {
            Capacity = Count;
        }
    }


    public IEnumerator<T> GetEnumerator()
    {
        int mod = _modCount;

        for (int i = 0; i < Count; i++)
        {
            if (mod != _modCount)
            {
                throw new InvalidCastException("Произошло изменение в элементах коллекции за время обхода");
            }

            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _items.GetEnumerator();
    }

    public override string ToString()
    {
        return string.Join(", ", _items);
    }

    public override bool Equals(object? obj)
    {
        if (ReferenceEquals(this, obj))
        {
            return true;
        }

        if (obj is null || obj.GetType() != GetType())
        {
            return false;
        }

        ArrayList<T> list = (ArrayList<T>)obj;

        for (int i = 0; i < Count; i++)
        {
            if (_items[i] is null)
            {
                if (!ReferenceEquals(_items[i], list[i]))
                {
                    return false;
                }
            }
            else
            {
                if (!_items[i]!.Equals(list[i]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        int prime = 37;
        int hash = 1;

        foreach (T item in _items)
        {
            if (item is null)
            {
                hash = prime * hash + 0;
            }
            else
            {
                hash = prime * hash + item.GetHashCode();
            }
        }

        return hash;
    }
}