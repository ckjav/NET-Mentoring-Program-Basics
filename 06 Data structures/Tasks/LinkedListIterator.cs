using System.Collections;

namespace Tasks
{
    public class NodeIterator<T> : IEnumerator
    {
        private readonly Node<T> _head;
        private Node<T> _current;

        public NodeIterator(Node<T> head)
        {
            _head = head;
        }

        public object Current => _current.Data;

        public bool MoveNext()
        {
            if (_current == null)
            {
                _current = _head;
            }
            else
            {
                _current = _current.Next;
            }

            return _current != null;
        }

        public void Reset()
        {
            _current = _head;
        }
    }
}