namespace DataStructure.Exercise
{
    public class VariableLengthArray
    {
        private int[] _items;

        private const int DefaultCapacity = 4;

        public int Count { get; private set; }

        public VariableLengthArray() : this(DefaultCapacity) { }

        public VariableLengthArray(int capacity)
        {
            _items = new int[capacity];
        }

        public int this[int index]
        {
            get
            {
                RaiseErrorIfIndexOutOfRange(index);
                return _items[index];
            }
            set
            {
                RaiseErrorIfIndexOutOfRange(index);
                _items[index] = value;
            }
        }

        public void Add(int value)
        {
            EnsureCapacity();
            _items[Count] = value;
            Count++;
        }

        public void AddRange(params int[] values)
        {
            if (values == null)
            {
                return;
            }

            for (int i = 0; i < values.Length; i++)
            {
                Add(values[i]);
            }
        }

        public void Insert(int index, int value)
        {
            RaiseErrorIfIndexOutOfRange(index);
            EnsureCapacity();

            for (int i = Count; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }

            _items[index] = value;

            Count++;
        }

        public void RemoveLast()
        {
            if (Count == 0)
            {
                return;
            }
            Count--;
        }

        public void RemoveAt(int index)
        {
            RaiseErrorIfIndexOutOfRange(index);

            for (int i = index; i < _items.Length - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            Count--;
        }

        public void Clear()
        {
            _items = new int[DefaultCapacity];
            Count = 0;
        }

        private void RaiseErrorIfIndexOutOfRange(int index)
        {
            if (Count <= index)
            {
                _ = _items[_items.Length];
            }
        }

        private void EnsureCapacity()
        {
            if (_items.Length != Count)
            {
                return;
            }
            Grow();
        }

        private void Grow()
        {
            int capacity;
            if (_items.Length > DefaultCapacity)
            {
                capacity = _items.Length;
            }
            else
            {
                capacity = DefaultCapacity;
            }

            var items = new int[capacity * 2];
            for (int i = 0; i < _items.Length; i++)
            {
                items[i] = _items[i];
            }
            _items = items;
        }
    }
}
