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
    }
}
