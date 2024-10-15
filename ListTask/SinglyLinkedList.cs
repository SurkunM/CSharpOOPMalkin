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
            CheckIndex(index);

            return GetListItem(index).Data;
        }

        set
        {
            CheckIndex(index);

            GetListItem(index).Data = value;
        }
    }

    private void CheckIndex(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" находится за пределами границ списка от 0 до {Count - 1}.");
        }
    }

    public T GetFirstData()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Данный список пуст.");
        }

        return _head.Data;
    }

    public T? RemoveAt(int index)
    {
        CheckIndex(index);

        if (index == 0)
        {
            return RemoveFirst();
        }

        ListItem<T> previousItem = GetListItem(index - 1);
        ListItem<T> currentItem = previousItem.Next!;

        T currentData = currentItem.Data;
        previousItem.Next = currentItem.Next;

        Count--;

        return currentData;
    }

    public void AddFirst(T item)
    {
        _head = new ListItem<T>(item, _head);
        Count++;
    }

    private ListItem<T> GetListItem(int index)
    {
        ListItem<T>? currentItem = _head;

        for (int i = 0; currentItem != null; currentItem = currentItem.Next, i++)
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
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" находится за пределами границ списка от 0 до {Count - 1}.");
        }

        if (index == 0)
        {
            AddFirst(item);

            return;
        }

        ListItem<T> previousItem = GetListItem(index - 1);
        ListItem<T> currentItem = previousItem.Next!;

        currentItem = new ListItem<T>(item, currentItem);
        previousItem.Next = currentItem;

        Count++;
    }

    public bool Remove(T? item)
    {
        for (ListItem<T>? currentItem = _head, previousItem = null;
            currentItem != null;
            previousItem = currentItem, currentItem = currentItem.Next)
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
            throw new InvalidOperationException($"Данный список пуст.");
        }

        T removedData = _head.Data;
        _head = _head.Next;

        Count--;

        return removedData;
    }

    public void Reverse()
    {
        if (_head is null)
        {
            return;
        }

        ListItem<T>? previousItem = null;
        ListItem<T> currentItem = _head;

        for (ListItem<T>? nextItem = currentItem.Next; nextItem != null; nextItem = currentItem.Next)
        {
            currentItem.Next = previousItem;
            previousItem = currentItem;
            currentItem = nextItem;
        }

        currentItem.Next = previousItem;
        _head = currentItem;
    }

    public SinglyLinkedList<T> Copy()
    {
        SinglyLinkedList<T> resultSinglyLinkedList = new SinglyLinkedList<T>();

        if (_head is null)
        {
            return resultSinglyLinkedList;
        }

        resultSinglyLinkedList.AddFirst(_head.Data);

        for (ListItem<T>? currentItem = _head.Next, resultListItem, previousResultListItem = resultSinglyLinkedList._head;
            currentItem != null;
            currentItem = currentItem.Next, previousResultListItem!.Next = resultListItem, previousResultListItem = resultListItem)
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

        for (ListItem<T>? currentItem = _head; currentItem != null; currentItem = currentItem.Next)
        {
            stringBuilder.Append(currentItem.Data).Append(separator);
        }

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);
        stringBuilder.Append(']');

        return stringBuilder.ToString();
    }
}