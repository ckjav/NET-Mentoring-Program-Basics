using System;
using Tasks.DoNotChange;

namespace Tasks
{
    public class HybridFlowProcessor<T> : IHybridFlowProcessor<T>
    {
        private readonly DoublyLinkedList<T> _doublyLinkedList;

        public HybridFlowProcessor()
        {
            _doublyLinkedList = new DoublyLinkedList<T>();
        }


        public T Dequeue()
        {
            ValidateIndexContent();

            return _doublyLinkedList.RemoveAt(0);
        }

        public void Enqueue(T item)
        {
            _doublyLinkedList.Add(item);
        }

        public T Pop()
        {
            ValidateIndexContent();

            return _doublyLinkedList.RemoveAt(_doublyLinkedList.Length - 1);
        }

        public void Push(T item)
        {
            _doublyLinkedList.Add(item);
        }

        private void ValidateIndexContent()
        {
            if (_doublyLinkedList == null || _doublyLinkedList.Length < 1) throw new InvalidOperationException();
        }
    }
}
