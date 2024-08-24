namespace ListTask;

internal class SinglyLinkedList<T>
{
    private ListItem<T>? _head;

    private int _count;

    public SinglyLinkedList() { }

    public int GetSize()
    {
        return _count;
    }

    public T? Get()
    {
        if (_head is null)
        {
            throw new ArgumentNullException(nameof(_head));
        }

        return _head.Data;
    }

    public T? Set(T item, int index)
    {
        if (_head is null)
        {
            throw new ArgumentNullException(nameof(_head));
        }

        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        int currentIndex = 0;
        T? currentData = _head.Data;

        for (ListItem<T>? currentItem = _head, previousItem = null;
            currentItem != null;
            previousItem = currentItem, currentItem = currentItem.Next, currentIndex++)
        {
            if (index == currentIndex)
            {
                if (previousItem is null)
                {
                    _head = new ListItem<T>(item);

                    break;
                }

                previousItem.Next = new ListItem<T>(item, currentItem.Next);
                currentData = currentItem.Data;
            }
        }

        return currentData;
    }

    public T? Get(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        ListItem<T>? currentItem = _head;

        for (int currentIndex = 0; currentItem != null; currentItem = currentItem.Next, currentIndex++)
        {
            if (index == currentIndex)
            {
                break;
            }
        }

        return currentItem!.Data;
    }

    public T? RemoveAt(int index)
    {
        if (index < 0 || index >= _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        int currentIndex = 0;
        T? currentData = default;

        for (ListItem<T>? currentItem = _head, previousItem = null;
            currentItem != null;
            previousItem = currentItem, currentItem = currentItem.Next, currentIndex++)
        {
            if (index == currentIndex)
            {
                if (previousItem is null)
                {
                    _head = null;
                    break;
                }

                previousItem.Next = currentItem.Next;
                currentData = currentItem.Data;
            }
        }

        return currentData;
    }

    public void Add(T item)
    {
        if (_head is null)
        {
            _head = new ListItem<T>(item);
        }
        else
        {
            _head = new ListItem<T>(item, _head);
        }

        _count++;
    }

    public void Add(T item, int index)
    {
        if (index < 0 || index > _count)
        {
            throw new ArgumentOutOfRangeException(nameof(index));
        }

        int currentIndex = 0;

        for (ListItem<T>? currentItem = _head, previousItem = null;
            currentItem != null || currentIndex < _count;
            previousItem = currentItem, currentItem = currentItem!.Next, currentIndex++)
        {
            if (index == currentIndex)
            {
                previousItem!.Next = new ListItem<T>(item, currentItem);

                _count++;

                break;
            }
        }
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

                _count--;

                return true;
            }
        }

        return false;
    }

    public T? Remove()
    {
        if (_head is null)
        {
            throw new ArgumentNullException(nameof(_head));
        }

        T? oldItem = _head.Data;

        if (_head.Next is null)
        {
            _head = null;
        }
        else
        {
            _head = _head.Next;
        }

        _count--;

        return oldItem;
    }

    public void Revers()
    {
        SinglyLinkedList<T> newLinkedList = new SinglyLinkedList<T>();

        for (ListItem<T>? currentItem = _head; currentItem != null; currentItem = currentItem.Next)
        {
            newLinkedList.Add(currentItem.Data!);
        }

        _head = newLinkedList._head;
    }

    public void Copy(SinglyLinkedList<T> newLinkedList)
    {
        for (int i = _count - 1; i >= 0; i--)
        {
            newLinkedList.Add(Get(i)!);
        }
    }
}