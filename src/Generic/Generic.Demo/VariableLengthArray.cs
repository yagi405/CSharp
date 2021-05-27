using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic.Demo
{
    public class VariableLengthArray
    {
        private int[] _items;

        private const int DefaultCapacity = 4;

        public int Count { get; private set; }

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

        public VariableLengthArray() : this(DefaultCapacity) { }

        public VariableLengthArray(int capacity)
        {
            _items = new int[capacity];
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

            for (var i = 0; i < Count; i++)
            {
                Add(values[i]);
            }
        }

        public void Insert(int index, int value)
        {
            RaiseErrorIfIndexOutOfRange(index);
            EnsureCapacity();

            for (var i = Count; index < i; i--)
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

            for (var i = index; i < _items.Length - 1; i++)
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
                //_items に index 番目の要素が存在したとしても
                //ユーザーが認知してない要素へのアクセスは認められない
                //従って、わざとエラーにする
                //例外は未履修
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
            if (DefaultCapacity < _items.Length)
            {
                capacity = _items.Length;
            }
            else
            {
                capacity = DefaultCapacity;
            }

            var items = new int[capacity * 2];
            for (var i = 0; i < _items.Length; i++)
            {
                items[i] = _items[i];
            }
            _items = items;
        }
    }
}
