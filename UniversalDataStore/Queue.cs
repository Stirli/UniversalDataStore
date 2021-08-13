using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UniversalDataStore
{
    public class Queue<T>
    {
        private const int BUFFER_SIZE = 128;
        private const int GROUTH_FACTOR = 150;
        private T[] _buffer;
        private CircleCursor _tail;
        private CircleCursor _head;
        private int _size;

        public Queue()
        {
            _buffer = new T[BUFFER_SIZE];
            _tail = new CircleCursor(BUFFER_SIZE);
            _head = new CircleCursor(BUFFER_SIZE);
        }

        public Queue(T[] array)
        {
            _buffer = new T[array.Length];
            array.CopyTo(_buffer, 0);
            _tail = new CircleCursor(array.Length);
            _head = new CircleCursor(array.Length);
            _size = array.Length;
        }

        public int Count { get => _size; }

        public void Enqueue(T element)
        {
            if (_size == _buffer.Length && _tail == _head)
            {
                Extend();
            }

            _buffer[_tail] = element;
            _tail++;
            _size++;
        }

        public T Dequeue()
        {
            var val = Peek();
            _head++;
            _size--;
            return val;
        }

        public T Peek()
        {
            if (_size == 0)
            {
                ThrowIsEmpty();
            }

            return _buffer[_head];
        }


        public bool Contains(T v)
        {
            if (_size > 0)
            {
                if (_head < _tail)
                {
                    for (int i = _head; i < _tail; i++)
                    {
                        if (_buffer[i].Equals(v))
                            return true;
                    }
                }
                else
                {
                    for (int i = 0; i < _tail; i++)
                    {
                        if (_buffer[i].Equals(v))
                            return true;
                    }
                    for (int i = _head; i < _buffer.Length; i++)
                    {
                        if (_buffer[i].Equals(v))
                            return true;
                    }
                }
            }

            return false;
        }

        private void Extend()
        {
            int newBufferSize = _buffer.Length + _buffer.Length * GROUTH_FACTOR / 100;
            if (newBufferSize < BUFFER_SIZE)
            {
                newBufferSize = BUFFER_SIZE;
            }

            var newBuffer = new T[newBufferSize];

            if (_size > 0)
            {
                if (_head < _tail)
                {
                    Array.Copy(_buffer, _head, newBuffer, 0, _size);
                }

                else
                {
                    Array.Copy(_buffer, _head, newBuffer, 0, _buffer.Length - _head);
                    Array.Copy(_buffer, _tail, newBuffer, _buffer.Length - _head, _tail);
                }
            }

            _buffer = newBuffer;
            _head = new CircleCursor(newBufferSize);
            _tail = new CircleCursor(newBufferSize, _size);

        }

        #region Exceptions
        private static void ThrowIsEmpty()
        {
            throw new InvalidOperationException("Queue is empty");
        }
        #endregion
    }
}
