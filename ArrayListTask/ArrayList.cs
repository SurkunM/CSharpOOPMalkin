using System.Collections;
using System.Text;

namespace ArrayListTask;

internal class ArrayList<T> : IList<T>
{
    private T[]? _items;

    private int _modCount;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" находится за пределами границ списка от 0 до {Count - 1}.");
            }

            return _items![index];
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" находится за пределами границ списка от 0 до {Count - 1}.");
            }

            _items![index] = value;

            _modCount++;
        }
    }

    public int Capacity
    {
        get
        {
            if (_items is null)
            {
                return 0;
            }

            return _items.Length;
        }

        set
        {
            if (value < Count)
            {
                throw new ArgumentOutOfRangeException(nameof(value), $"Входящее значение вместимости списка \"{value}\"  не может быть меньше текущего размера списка \"{Count}\".");
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
            throw new ArgumentOutOfRangeException(nameof(capacity), $"Значение вместимости списка \"{capacity}\" не может быть меньше нуля.");
        }

        _items = new T[capacity];
    }

    public void Add(T item)
    {
        if (Count >= Capacity)
        {
            IncreaseCapacity();
        }

        _items![Count] = item;

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
            Array.Resize(ref _items, Capacity * 2);
        }
    }

    public void Clear()
    {
        if (Count == 0)
        {
            return;
        }

        Array.Clear(_items!, 0, Count);

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

        if (_items is null)
        {
            throw new ArgumentNullException(nameof(_items));
        }

        if (index < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" не может быть меньше нуля.");
        }

        if (array.Length - index < Count)
        {
            throw new ArgumentException($"Недостаточно места в переданном массиве от текущего положения \"{index}\" до конца длины массива \"{array.Length}\".", nameof(array));
        }

        Array.Copy(_items, 0, array, index, Count);
    }

    public int IndexOf(T item)
    {
        if (_items is null)
        {
            throw new ArgumentNullException(nameof(_items));
        }

        return Array.IndexOf(_items, item, 0, Count);
    }

    public void Insert(int index, T item)
    {
        if (_items is null)
        {
            throw new ArgumentNullException(nameof(_items));
        }

        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" находится за пределами границ списка от 0 до {Count - 1}");
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
        if (_items is null)
        {
            throw new ArgumentNullException(nameof(_items));
        }

        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" находится за пределами границ списка от 0 до {Count - 1}");
        }

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
        if (_items is null)
        {
            throw new ArgumentNullException(nameof(_items));
        }

        int initialModCount = _modCount;

        for (int i = 0; i < Count; i++)
        {
            if (initialModCount != _modCount)
            {
                throw new InvalidOperationException($"Произошло изменение в элементах текущего списка \"{nameof(_items)}\" за время обхода итератора");
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
        if (_items is null)
        {
            throw new ArgumentNullException(nameof(_items));
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');
        const string separator = ", ";

        for (int i = 0; i < Count; i++)
        {
            stringBuilder.Append(_items[i]).Append(separator);
        }

        if (Count > 0)
        {
            stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
        }

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
            if (!Equals(_items![i], list[i]))
            {
                return false;
            }
        }

        return true;
    }

    public override int GetHashCode()
    {
        if (_items is null)
        {
            throw new ArgumentNullException(nameof(_items));
        }

        const int prime = 37;
        int hash = 1;

        for (int i = 0; i < Count; i++)
        {
            if (_items[i] is not null)
            {
                hash = prime * hash + _items[i]!.GetHashCode();
            }
        }

        return hash;
    }
}