using System.Collections;
using System.Text;

namespace HashTableTask;

internal class HashTable<T> : ICollection<T>
{
    private readonly List<T>[] _lists;

    private int _modCount;

    public int Count { get; private set; }

    public bool IsReadOnly => false;

    public HashTable(int capacity)
    {
        if (capacity <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(capacity), "Вместимость хэш-таблицы не должна быть меньше или равно нулю");
        }

        _lists = new List<T>[capacity];
    }

    public void Add(T item)
    {
        int index = GetListIndex(item);

        if (_lists[index] is null)
        {
            _lists[index] = [item];
        }
        else
        {
            _lists[index].Add(item);
        }

        Count++;
        _modCount++;
    }

    private int GetListIndex(T item)
    {
        return item is null ? 0 : Math.Abs(item.GetHashCode() % _lists.Length);
    }

    public void Clear()
    {
        if (Count <= 0)
        {
            return;
        }

        foreach (List<T> list in _lists)
        {
            list?.Clear();
        }

        Count = 0;
        _modCount++;
    }

    public bool Contains(T item)
    {
        int index = GetListIndex(item);

        return _lists[index] is not null && _lists[index].Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0)
        {
            throw new ArgumentOutOfRangeException(nameof(arrayIndex), $"Значение параметра {nameof(arrayIndex)} меньше нуля");
        }

        if (array.Length - arrayIndex < Count)
        {
            throw new ArgumentException($"Недостаточно места в переданном массиве от текущего положения {nameof(arrayIndex)} до конца длины массива {nameof(array)}", nameof(array));
        }

        int i = arrayIndex;

        foreach (List<T> list in _lists)
        {
            if (list is not null)
            {
                list.CopyTo(array, i);
                i += list.Count;
            }
        }
    }

    public bool Remove(T item)
    {
        if (Count <= 0)
        {
            return false;
        }

        int index = GetListIndex(item);

        if (_lists[index] is not null && _lists[index].Remove(item))
        {
            Count--;
            _modCount++;

            return true;
        }

        return false;
    }

    public override string ToString()
    {
        if (Count <= 0)
        {
            return "()";
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('(');
        string separator = ", ";

        foreach (List<T> list in _lists)
        {
            if (list is not null)
            {
                foreach (T item in list)
                {
                    stringBuilder.Append(item).Append(separator);
                }
            }
        }

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
        stringBuilder.Append(')');

        return stringBuilder.ToString();
    }

    public IEnumerator<T> GetEnumerator()
    {
        int startModCount = _modCount;

        foreach (List<T> list in _lists)
        {
            if (list is null)
            {
                continue;
            }

            foreach (T item in list)
            {
                if (startModCount != _modCount)
                {
                    throw new InvalidOperationException("Произошло изменение в элементах коллекции за время обхода");
                }

                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return ((IEnumerable)this).GetEnumerator();
    }
}