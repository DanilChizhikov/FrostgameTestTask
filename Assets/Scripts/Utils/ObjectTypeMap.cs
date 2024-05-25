using System;
using System.Collections;
using System.Collections.Generic;

namespace TestTask.Utils
{
    public class ObjectTypeMap<T> : IEnumerable<T>
    {
        private readonly List<T> _items;
        private readonly Dictionary<Type, int> _itemsMap;

        public int Count => _items.Count;

        public T this[Type type] => GetItem(type);

        public ObjectTypeMap() : this(0)
        {
        }

        public ObjectTypeMap(IEnumerable<T> collection)
        {
            _items = new List<T>(collection);
            _itemsMap = new Dictionary<Type, int>(_items.Count);
            for (int i = 0; i < _items.Count; i++)
            {
                _itemsMap.Add(_items[i].GetType(), i);
            }
        }

        public ObjectTypeMap(int capacity)
        {
            _items = new List<T>(capacity);
            _itemsMap = new Dictionary<Type, int>(capacity);
        }
        
        public bool TryGetItem(Type type, out T item)
        {
            bool hasItem = _itemsMap.TryGetValue(type, out int itemIndex);
            if (!hasItem)
            {
                itemIndex = GetItemIndexAndAdd(type);
                hasItem = itemIndex >= 0;
            }
            
            item = hasItem ? _items[itemIndex] : default;
            return hasItem;
        }
        
        public T GetItem(Type type)
        {
            if (!TryGetItem(type, out T item))
            {
                throw new KeyNotFoundException();
            }
            
            return item;
        }

        private int GetItemIndexAndAdd(Type type)
        {
            int itemIndex = GetItemIndex(type);
            if (itemIndex >= 0)
            {
                _itemsMap.Add(type, itemIndex);
            }
            
            return itemIndex;
        }

        private int GetItemIndex(Type type)
        {
            int index = -1;
            for (int i = 0; i < _items.Count; i++)
            {
                T item = _items[i];
                if (item.GetType().IsAssignableFrom(type))
                {
                    index = i;
                    break;
                }
            }
            
            return index;
        }

        public IEnumerator<T> GetEnumerator()
        {
            return _items.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}