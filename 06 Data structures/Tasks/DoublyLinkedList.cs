using System;
using System.Collections;
using System.Collections.Generic;
using Tasks.DoNotChange;

namespace Tasks
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        private int _index = -1;
        private Node<T> _head;

        public int Length => _index + 1;

        public void Add(T e)
        {
            if (_head == null)
            {
                _head = new Node<T>(e);
            }
            else
            {
                var current = _head;
                
                for (var i = 0; i < _index; ++i)
                {
                    current = _head.Next;
                }

                current.Next = new Node<T>(e);
            }
            ++_index;
        }

        public void AddAt(int index, T e)
        {
            if (index < 0 || index > _index + 1) throw new IndexOutOfRangeException();

            var current = _head;
            for (var i = 0; i < index - 1; ++i)
            {
                current = current.Next;
            }

            Node<T> temp = new Node<T>(e);
            temp.Next = current.Next;
            current.Next = temp;

            if (index == 0)
            {
                _head = temp;
            }

            ++_index;
        }

        public T ElementAt(int index)
        {
            ValidateIndexForRemoval(index);

            Node<T> current = _head;
            for (var i = 0; i < index; ++i)
            {
                current = current.Next;
            }

            return current.Data;
        }

        public IEnumerator<T> GetEnumerator()
        {
            Node<T> current = _head;
            while(current != null)
            {
                yield return current.Data;
                current = current.Next;
            }
        }

        public void Remove(T item)
        {
            ValidateIndexForRemoval();

            var current = _head;
            var previous = (Node<T>)null;

            while (current != null)
            {
                if (current.Data.Equals(item))
                {
                    if(previous == null)
                    {
                        _head = current.Next;
                    }
                    else
                    {
                    previous.Next = current.Next;

                    }
                    --_index;
                    return;
                }

                previous = current;
                current = current.Next;
            }
        }

        public T RemoveAt(int index)
        {
            ValidateIndexForRemoval(index);

            var current = _head;
            var previous = (Node<T>)null;
            for (var i = 0; i < index; ++i)
            {
                previous = current;
                current = current.Next;
            }

            --_index;
            previous.Next = current.Next;

            return current.Data;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new NodeIterator<T>(this._head);
        }

        private void ValidateIndexForRemoval()
        {
            if(_head == null) throw new IndexOutOfRangeException();
        }

        private void ValidateIndexForRemoval(int index)
        {
            ValidateIndexForRemoval();
            if (index < 0 || index > _index) throw new IndexOutOfRangeException();
        }
    }

    public class Node<T>
    {
        public T Data { get; set; }

        public Node<T> Next { get; set; }

        public Node(T data)
        {
            Data = data;
            Next = null;
        }
    }
}
