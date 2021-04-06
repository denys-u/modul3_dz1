namespace Modul3_dz1
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class MyList<T> : IReadOnlyCollection<T>
    {
        private const int DefaultCount = 4;
        private const int RateFactor = 2;

        private T[] _array;
        private int _capacity;

        public MyList(int capacity)
        {
            _capacity = capacity;
            _array = new T[_capacity];
        }

        public MyList()
            : this(DefaultCount)
        {
        }

        public int Capacity
        {
            get
            {
                return _capacity;
            }
            set
            {
                if (!ValidateSetCapacity(value))
                {
                    return;
                }

                _capacity = value;
            }
        }

        public int Count { get; private set; }

        public void Add(T item)
        {
            if (Count == Capacity)
            {
                var isSuccess = IncreaseArray();
                if (!isSuccess)
                {
                    return;
                }
            }

            AddItem(item);
        }

        public void AddRange(IReadOnlyCollection<T> array)
        {
            var capacity = Count + array.Count;

            if (capacity >= Capacity)
            {
                var isSuccess = IncreaseArray(capacity);
                if (!isSuccess)
                {
                    return;
                }

                foreach (T item in array)
                {
                    AddItem(item);
                }
            }
        }

        public bool RemoveAt(int index)
        {
            if (index >= Count || index < 0)
            {
                return false;
            }

            var lastIndex = Count - 1;
            for (var i = index; i < lastIndex; i++)
            {
                _array[i] = _array[i + 1];
            }

            _array[lastIndex] = default(T);
            Count--;

            return true;
        }

        private bool ValidateSetCapacity(int capacity)
        {
            return capacity > Count;
        }

        private void AddItem(T item)
        {
            _array[Count] = item;
            Count++;
        }

        private bool IncreaseArray(int? capacity = null)
        {
            var tempArray = _array;
            if (capacity == null)
            {
                _capacity = _capacity * RateFactor;
            }
            else
            {
                var isValidCapacity = ValidateSetCapacity(capacity.Value);
                if (!isValidCapacity)
                {
                    return false;
                }

                _capacity = capacity.Value;
            }
        }

        public bool Remove(T item)
        {
            for (var i = 0; i < Count; i++)
            {
                if (_array[i].Equals(item))
                {
                    var isSuccess = RemoveAt(i);
                    if (!isSuccess)
                    {
                        return false;
                    }
                }
            }
        }

        public void Sort(IComparer<T> comparer)
        {
            Array.Sort(_array, comparer);
        }

        public IEnumerator GetEnumerator()
        {
            return GetGenericEnumerator();
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return GetGenericEnumerator();
        }
    }
}
