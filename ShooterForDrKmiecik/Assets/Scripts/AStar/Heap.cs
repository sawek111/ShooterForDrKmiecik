using UnityEngine;
using System.Collections;
using System;

public class Heap<T> where T : IHeapItem<T>
{
    private readonly T[] _items;
    private int _currItemsCount;

    #region Constructor

    public Heap(int maxHeapSize)
    {
        _items = new T[maxHeapSize];
    }

    #endregion Constructor

    #region Interface

    public int Count
    {
        get { return _currItemsCount; }
    }

    public void Add(T item)
    {
        item.HeapIndex = _currItemsCount;
        _items[_currItemsCount] = item;
        SortUp(item);
        _currItemsCount++;
    }

    public T RemoveFirst()
    {
        T firstItem = _items[0];
        _currItemsCount--;
        _items[0] = _items[_currItemsCount];
        _items[0].HeapIndex = 0;
        SortDown(_items[0]);

        return firstItem;
    }

    public void UpdateItem(T item)
    {
        SortUp(item);
    }

    public bool Contains(T item)
    {
        return Equals(_items[item.HeapIndex], item);
    }

    #endregion Interface

    #region Logic

    private void SortDown(T item)
    {
        while (true)
        {
            int childIndexLeft = item.HeapIndex * 2 + 1;
            int childIndexRight = item.HeapIndex * 2 + 2;
            int swapIndex = 0;

            if (childIndexLeft < _currItemsCount)
            {
                swapIndex = childIndexLeft;

                if (childIndexRight < _currItemsCount && _items[childIndexLeft].CompareTo(_items[childIndexRight]) < 0)
                {
                    swapIndex = childIndexRight;
                }
                if (item.CompareTo(_items[swapIndex]) < 0)
                {
                    Swap(item, _items[swapIndex]);
                }

                return;

            }
            else
            {
                return;
            }
        }
    }

    private void SortUp(T item)
    {
        int parentIndex = (item.HeapIndex - 1) / 2;

        while (true)
        {
            T parentItem = _items[parentIndex];
            if (item.CompareTo(parentItem) > 0)
            {
                Swap(item, parentItem);
            }
            else
            {
                break;
            }

            parentIndex = (item.HeapIndex - 1) / 2;
        }
    }

    private void Swap(T itemA, T itemB)
    {
        _items[itemA.HeapIndex] = itemB;
        _items[itemB.HeapIndex] = itemA;
        int itemAIndex = itemA.HeapIndex;
        itemA.HeapIndex = itemB.HeapIndex;
        itemB.HeapIndex = itemAIndex;
    }

    #endregion Logic
}

public interface IHeapItem<T> : IComparable<T>
{
    int HeapIndex
    {
        get;
        set;
    }
}