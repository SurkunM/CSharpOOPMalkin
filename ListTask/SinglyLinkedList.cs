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

    public T GetFirst()
    {
        if (_head is null)
        {
            throw new InvalidOperationException("Данный список пуст.");
        }

        return _head.Data;
    }

    public T RemoveAt(int index)
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
        ListItem<T> currentItem = _head!;

        for (int i = 0; i != index; i++)
        {
            currentItem = currentItem.Next!;
        }

        return currentItem;
    }

    public void Add(int index, T item)
    {
        if (index < 0 || index > Count)
        {
            throw new ArgumentOutOfRangeException(nameof(index), $"Индекс \"{index}\" находится за пределами границ списка от 0 до {Count}.");
        }

        if (index == 0)
        {
            AddFirst(item);

            return;
        }

        ListItem<T> previousItem = GetListItem(index - 1);
        ListItem<T> addedItem = new ListItem<T>(item, previousItem.Next!);

        previousItem.Next = addedItem;

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
            throw new InvalidOperationException("Данный список пуст.");
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

        for (ListItem<T> currentItem = _head, nextItem = currentItem; currentItem != null; currentItem = nextItem)
        {
            nextItem = nextItem.Next!;
            currentItem.Next = previousItem;
            previousItem = currentItem;
        }

        _head = previousItem;
    }

    public SinglyLinkedList<T> Copy()
    {
        SinglyLinkedList<T> copySinglyLinkedList = new SinglyLinkedList<T>();

        if (_head is null)
        {
            return copySinglyLinkedList;
        }

        copySinglyLinkedList.AddFirst(_head.Data);

        for (ListItem<T>? currentItem = _head.Next, copyListItem, previousCopyListItem = copySinglyLinkedList._head;
            currentItem != null; currentItem = currentItem.Next)
        {
            copyListItem = new ListItem<T>(currentItem.Data);

            previousCopyListItem!.Next = copyListItem;
            previousCopyListItem = copyListItem;
        }

        return copySinglyLinkedList;
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