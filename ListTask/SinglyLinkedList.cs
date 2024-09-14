using System.Text;

namespace ListTask;

internal class SinglyLinkedList<T>
{
    private ListItem<T>? _head;

    public int Count { get; private set; }

    public T? this[int index]
    {
        get
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ коллекции");
            }

            ListItem<T>? currentItem = _head;

            for (int i = 0; currentItem != null; currentItem = currentItem.Next, i++)
            {
                if (index == i)
                {
                    break;
                }
            }

            return currentItem is null ? default : currentItem.Data;
        }

        set
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ коллекции");
            }

            int i = 0;

            for (ListItem<T>? currentItem = _head; currentItem != null; currentItem = currentItem.Next, i++)
            {
                if (index == i)
                {
                    currentItem.Data = value!;

                    return;
                }
            }
        }
    }

    public int GetSize() => Count;

    public T? GetFirstData()
    {
        return this[0];
    }

    public T? RemoveAt(int index)
    {
        ListItem<T>? previousItem = GetPreviousListItem(index);

        T? currentListData;

        if (previousItem is null)
        {
            currentListData = _head!.Data;
            _head = _head.Next;
        }
        else
        {
            currentListData = previousItem.Next!.Data;
            previousItem.Next = previousItem.Next!.Next;
        }

        Count--;

        return currentListData;
    }

    public void AddFirst(T item)
    {
        _head = new ListItem<T>(item, _head!);
        Count++;
    }

    private ListItem<T>? GetPreviousListItem(int index)
    {
        if (index < 0 || index >= Count)
        {
            throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ коллекции");
        }

        int i = 0;

        for (ListItem<T>? currentItem = _head, previousItem = null;
            currentItem != null;
            previousItem = currentItem, currentItem = currentItem!.Next, i++)
        {
            if (index == i)
            {
                return previousItem;
            }
        }

        return null;
    }

    public void Add(T item, int index)
    {
        if (index < 0 || index > Count)
        {
            throw new IndexOutOfRangeException($"Индекс {nameof(index)} находится за пределами границ коллекции");
        }

        if (_head is null)
        {
            _head = new ListItem<T>(item);
        }
        else
        {
            ListItem<T>? previousItem = GetPreviousListItem(index);


            if (previousItem is null)
            {
                _head = _head!.Next;
            }
            else
            {
                previousItem!.Next = new ListItem<T>(item, previousItem.Next!);
            }
        }

        Count++;
    }

    public bool Remove(T item)
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

    public T? RemoveFirst()
    {
        if (_head is null)
        {
            throw new ArgumentNullException(nameof(_head));
        }

        T? oldItem = _head.Data;
        _head = _head.Next;

        Count--;

        return oldItem;
    }

    public void Reverse()
    {
        if (Count <= 1)
        {
            return;
        }

        for (ListItem<T>? previousItem = null, currentItem = _head, nextItem = currentItem!.Next;
            currentItem != null;
            previousItem = currentItem, currentItem = nextItem, nextItem = currentItem!.Next)
        {
            currentItem.Next = previousItem;

            if (nextItem is null)
            {
                currentItem.Next = previousItem;
                _head = currentItem;

                return;
            }
        }
    }

    public SinglyLinkedList<T> Copy()
    {
        SinglyLinkedList<T> newLinkedList = new SinglyLinkedList<T>();

        for (ListItem<T>? currentItem = _head; currentItem != null; currentItem = currentItem.Next)
        {
            newLinkedList.AddFirst(currentItem.Data);
        }

        newLinkedList.Reverse();

        return newLinkedList;
    }

    public override string ToString()
    {
        if (Count <= 0)
        {
            return "";
        }

        StringBuilder stringBuilder = new StringBuilder();
        string separator = ", ";

        for (int i = 0; i < Count; i++)
        {
            stringBuilder.Append(this[i]).Append(separator);
        }

        stringBuilder.Remove(stringBuilder.Length - separator.Length, separator.Length);

        return stringBuilder.ToString();
    }
}