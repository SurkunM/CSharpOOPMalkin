using System.Collections;
using System.Text;

namespace HashTableTask;

internal class HashTable<T> : ICollection<T>
{
    private List<T>[] _lists;

    public int Count { get; private set; }

    private int _modCount;

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= _lists.Length)
            {
                throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ хэш-таблицы");
            }

            return _lists[index].Last();
        }

        set
        {
            _lists[index].Add(value);

            _modCount++;
        }
    }

    public bool IsReadOnly
    {
        get => false;
    }

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
        if (Count > 0)
        {
            foreach (List<T> list in _lists)
            {
                if (list is not null)
                {
                    list.Clear();
                }
            }

            Count = 0;
            _modCount = 0;
        }
    }

    public bool Contains(T item)
    {
        int i = GetListIndex(item);

        return _lists[i] is not null && _lists[i].Contains(item);
    }

    public void CopyTo(T[] array, int arrayIndex)
    {
        if (array is null)
        {
            throw new ArgumentNullException(nameof(array));
        }

        if (arrayIndex < 0 || array.Length < (arrayIndex + Count))
        {
            throw new IndexOutOfRangeException($"Число копируемых элементов начиная с индекса {nameof(arrayIndex)} больше чем длина массива {nameof(array)}");
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
        if (Count > 0)
        {
            int i = GetListIndex(item);

            if (_lists[i] is not null && _lists[i].Remove(item))
            {
                Count--;
                _modCount--;

                return true;
            }
        }

        return false;
    }

    public override string ToString()
    {
        if (Count <= 0)
        {
            return "";
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
        int modCount = _modCount;

        foreach (List<T> list in _lists)
        {
            if (list is null)
            {
                continue;
            }

            foreach (T item in list)
            {
                if (modCount != _modCount)
                {
                    throw new InvalidCastException("Произошло изменение в элементах коллекции за время обхода");
                }

                yield return item;
            }
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return _lists.GetEnumerator();
    }
}