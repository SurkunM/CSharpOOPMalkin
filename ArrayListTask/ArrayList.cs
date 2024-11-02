using System.Collections;
using System.Text;

namespace ArrayListTask;

internal class ArrayList<T> : IList<T>
{
    private T[] _items;

    private int _modCount;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            CheckIndex(index);

            return _items[index];
        }

        set
        {
            CheckIndex(index);

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
                throw new ArgumentOutOfRangeException(nameof(value), $"Входящее значение вместимости списка \"{value}\" не может быть меньше текущего размера списка \"{Count}\".");
            }

            Array.Resize(ref _items, value);
        }
    }

    public bool IsReadOnly => false;

    public ArrayList()
    {
        _items = new T[2];
    }

    public ArrayList(int capacity)
    {
        if (capacity < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), $"Значение вместимости списка \"{capacity}\" не может быть меньше нуля.");
        }

        _items = new T[capacity];
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" находится за пределами границ списка от 0 до {Count - 1}.");
        }
    }

    public void Add(T item)
    {
        if (Count >= Capacity)
        {
            IncreaseCapacity();
        }

        _items[Count] = item;

        Count++;
        _modCount++;
    }

    private void IncreaseCapacity()
    {
        if (Capacity == 0)
        {
            _items = new T[1];
        }
        else
        {
            Capacity *= 2;
        }
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        Array.Clear(_items, 0, Count);

        _modCount++;
        Count = 0;
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
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" не может быть меньше нуля.");
        }

        if (array.Length - index < Count)
        {
            throw new ArgumentException($"Недостаточно места в переданном массиве от текущего индекса \"{index}\" до конца длины массива.", nameof(array));
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
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" находится за пределами границ списка от 0 до {Count}.");
        }

        if (Count >= Capacity)
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
        CheckIndex(index);

        Array.Copy(_items, index + 1, _items, index, Count - index - 1);

        _items[Count - 1] = default!;

        Count--;
        _modCount++;
    }

    public void TrimExcess()
    {
        if (Count < Capacity * 0.9)
        {
            Capacity = Count;
        }
    }

    public IEnumerator<T> GetEnumerator()
    {
        int initialModCount = _modCount;

        for (int i = 0; i < Count; i++)
        {
            if (initialModCount != _modCount)
            {
                throw new InvalidOperationException($"Произошло изменение в элементах текущего списка за время обхода итератора.");
            }

            yield return _items[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public override string ToString()
    {
        if (Count == 0)
        {
            return "[]";
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');
        const string separator = ", ";

        for (int i = 0; i < Count; i++)
        {
            stringBuilder.Append(_items[i]).Append(separator);
        }

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
        stringBuilder.Append(']');

        return stringBuilder.ToString();
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
            if (!Equals(_items[i], list._items[i]))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        const int prime = 37;
        int hash = 1;

        for (int i = 0; i < Count; i++)
        {
            if (_items[i] is null)
            {
                hash = prime * hash;
            }
            else
            {
                hash = prime * hash + _items[i]!.GetHashCode();
            }
        }

        return hash;
    }
}