using System.Collections;

namespace ArrayListTask;

internal class ArrayList<T> : IList<T>
{
    private T[] _items = [];

    private int _modCount;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс находится за пределами границ списка от 0 до {Count}");
            }

            return _items[index];
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс находится за пределами границ списка от 0 до {Count}");
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
                throw new ArgumentOutOfRangeException(nameof(value), $"Входящее значение: {value} не может быть меньше текущего размера списка: {Count}");
            }

            Array.Resize(ref _items, value);
        }
    }

    public bool IsReadOnly => false;

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
        else
        {
            Array.Resize(ref _items, _items.Length * 2);
        }
    }

    public void Clear()
    {
        if (Count > 0)
        {
            Array.Clear(_items, 0, Count);

            Count = 0;
            _modCount++;
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

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Значение параметра {nameof(index)} меньше нуля");
        }

        if (array.Length - index < Count)
        {
            throw new ArgumentException($"Недостаточно места в переданном массиве от текущего положения {nameof(index)} до конца длины массива {nameof(array)} ", nameof(array));
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
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс находится за пределами границ списка от 0 до {Count}");
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
        int removedItemIndex = IndexOf(item);

        if (removedItemIndex >= 0)
        {
            RemoveAt(removedItemIndex);

            return true;
        }

        return false;
    }

    public void RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс находится за пределами границ списка от 0 до {Count}");
        }

        Array.Copy(_items, index + 1, _items, index, Count - index - 1);

        _items[Count - 1] = default!;

        Count--;
        _modCount++;
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
        int startModCount = _modCount;

        for (int i = 0; i < Count; i++)
        {
            if (startModCount != _modCount)
            {
                throw new InvalidOperationException("Произошло изменение в элементах коллекции за время обхода");
            }

            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }

    public override string ToString()
    {
        return $"[{string.Join(", ", _items)}]";
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

        if (Count != list.Count)
        {
            return false;
        }

        for (int i = 0; i < Count; i++)
        {
            if (_items[i] is null)
            {
                if (!Equals(_items[i], list[i]))
                {
                    return false;
                }
            }
            else
            {
                if (!Equals(_items[i], list[i]))
                {
                    return false;
                }
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        const int Prime = 37;
        int hash = 1;

        foreach (T item in _items)
        {
            if (item is not null)
            {
                hash = Prime * hash + item.GetHashCode();
            }
        }

        return hash;
    }
}