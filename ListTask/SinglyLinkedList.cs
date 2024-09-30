using System.Text;

namespace ListTask;

internal class SinglyLinkedList<T>
{
    private ListItem<T>? _head;

    public int Count { get; private set; }

    public T this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Параметр {nameof(index)} находится за пределами границ списка от 0 до {Count}");
            }

            if (index == 0)
            {
                return GetFirstData();
            }

            return GetListItem(index).Data;
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new ArgumentOutOfRangeException(nameof(index), $"Параметр {nameof(index)} находится за пределами границ списка от 0 до {Count}");
            }

            GetListItem(index).Data = value!;
        }
    }

    public T GetFirstData()
    {
        if (_head is null)
        {
            throw new InvalidOperationException($"Данный список пуст и значение {nameof(_head)} ничего не содержит.");
        }

        return _head.Data;
    }

    public T? RemoveAt(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Параметр {nameof(index)} находится за пределами границ списка от 0 до {Count}");
        }

        if (index == 0)
        {
            return RemoveFirst();
        }

        int i = 1;
        T? currentData = default;

        for (ListItem<T> currentItem = _head!.Next!, previousItem = _head;
            currentItem != null;
            previousItem = currentItem, currentItem = currentItem.Next!, i++)
        {
            if (index == i)
            {
                currentData = currentItem.Data;
                previousItem.Next = currentItem.Next!;

                Count--;
                break;
            }
        }

        return currentData;
    }

    public void AddFirst(T item)
    {
        _head = new ListItem<T>(item, _head!);
        Count++;
    }

    private ListItem<T> GetListItem(int index)
    {
        ListItem<T> currentItem = _head!;

        for (int i = 0; currentItem != null; currentItem = currentItem.Next!, i++)
        {
            if (index == i)
            {
                break;
            }
        }

        return currentItem!;
    }

    public void Add(T item, int index)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Параметр {nameof(index)} находится за пределами границ списка от 0 до {Count - 1}");
        }

        if (index == 0)
        {
            AddFirst(item);
        }
        else
        {
            int i = 1;

            for (ListItem<T> currentItem = _head!.Next!, previousItem = _head!;
                currentItem != null;
                previousItem = currentItem, currentItem = currentItem.Next!, i++)
            {
                if (index == i)
                {
                    currentItem = new ListItem<T>(item, currentItem);
                    previousItem.Next = currentItem;

                    Count++;

                    return;
                }
            }
        }
    }

    public bool Remove(T item)
    {
        for (ListItem<T> currentItem = _head!, previousItem = null!;
            currentItem != null;
            previousItem = currentItem, currentItem = currentItem.Next!)
        {
            if (Equals(currentItem.Data, item))
            {
                if (previousItem is null)
                {
                    _head = _head!.Next;
                }
                else
                {
                    previousItem.Next = currentItem.Next;
                }

                Count--;

                return true;
            }
        }

        return false;
    }

    public T RemoveFirst()
    {
        if (_head is null)
        {
            throw new InvalidOperationException($"Данный список пуст и значение {nameof(_head)} ничего не содержит.");
        }

        T oldItem = _head.Data;
        _head = _head.Next;

        Count--;

        return oldItem;
    }

    public void Reverse()
    {
        if (_head is null)
        {
            return;
        }

        ListItem<T>? previousItem = null;
        ListItem<T> currentItem = _head;

        for (ListItem<T> nextItem = currentItem.Next!; nextItem != null; nextItem = currentItem.Next!)
        {
            currentItem.Next = previousItem;
            previousItem = currentItem;
            currentItem = nextItem;
        }

        currentItem.Next = previousItem;
        _head = currentItem;

        return;
    }

    public SinglyLinkedList<T> Copy()
    {
        if (_head is null)
        {
            throw new InvalidOperationException($"Данный список пуст и значение {nameof(_head)} ничего не содержит.");
        }

        SinglyLinkedList<T> resultSinglyLinkedList = new SinglyLinkedList<T>();
        resultSinglyLinkedList.AddFirst(_head.Data);

        ListItem<T> resultListHead = resultSinglyLinkedList.GetListItem(0);

        for (ListItem<T> currentItem = _head.Next!, resultListItem, previousResultListItem = resultListHead;
            currentItem != null;
            currentItem = currentItem.Next!, previousResultListItem.Next = resultListItem, previousResultListItem = resultListItem)
        {
            resultListItem = new ListItem<T>(currentItem.Data);
        }

        return resultSinglyLinkedList;
    }

    public override string ToString()
    {
        if (_head is null)
        {
            return "[]";
        }

        StringBuilder stringBuilder = new StringBuilder();

        stringBuilder.Append('[');
        const string separator = ", ";

        for (ListItem<T> currentItem = _head; currentItem != null; currentItem = currentItem.Next!)
        {
            stringBuilder.Append(currentItem.Data).Append(separator);
        }

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }
}