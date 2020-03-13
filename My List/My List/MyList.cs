using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace My_List
{
    class MyList<T> : IEnumerable, IEnumerator<T>
    {
        private int _capacity = 4;
        private T[] _arr;
        private int _counter;
        private int _i = -1;
        public MyList()
        {
            _arr = new T[_capacity];
            _counter = 0;
        }
        public MyList(int capacity)
        {
            _arr = new T[capacity];
            _capacity = capacity;
            _counter = 0;
        }

        public T Current
        {
            get
            {
                if (_i == -1 || _i >= _arr.Length)
                    throw new InvalidOperationException();
                return _arr[_i];
            }
        }

        object IEnumerator.Current
        {
            get
            {
                return Current;
            }
        }

        public void add(T element)
        {
            if (_counter >= this._capacity)
            {
                Array.Resize(ref _arr, 2 * _capacity);
                _capacity *= 2;
            }
            _arr[_counter] = element;
            _counter++;
        }
        public void removeAt(int index)
        {
            if (index < 0 || index >= _arr.Length) throw new Exception();
            if (index > 0)
            {
                Array.Copy(_arr, 0, _arr, 0, index);
            }
            if (index < _arr.Length - 1)
                Array.Copy(_arr, index + 1, _arr, index, _arr.Length - index - 1);

        }
        public int indexOf(T item)
        {
            for(int i =0; i < _arr.Length; i++)
            {
                if (item.Equals(_arr[i])) return i;
            }
            return -1;
        }
        public void Dispose()
        {
            _arr = null;
        }

        public IEnumerator GetEnumerator() => _arr.GetEnumerator();

        public bool MoveNext()
        {
            if (++_i >= _arr.Length)
            {
                return false;
            }
            else
            {
                _i++;             
            }
            return true;
        }

        public void Reset()
        {
            _i = -1;
        }
    }
}
