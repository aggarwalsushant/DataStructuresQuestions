using Questions.DataStructures.LinkedList.Elements.Node;
using System;
using System.Text;

namespace Questions.DataStructures.LinkedList.Elements.Lists
{
    public class DoublyLinkedList<T> : IDoublyLinkedList<T>
    {
        #region Properties
        public IDoublyNode<T> Head { get; set; }
        public IDoublyNode<T> Last { get; set; }
        public int Count { get; private set; }
        #endregion

        #region Methods
        // Add element at end
        public void AddAtEnd(IDoublyNode<T> node)
        {
            if (Head == null)
            {
                Last = Head = node;
            }
            else
            {
                Last.Next = node;
                node.Previous = Last;
                Last = node;
            }

            Count++;
        }

        public void Print()
        {
            var node = Head;
            var builder = new StringBuilder();
            builder.Append("Head ");

            while (node != null)
            {
                builder.Append(node.Value).Append(" <-> ");
                node = node.Next;
            }

            builder.Remove(builder.Length - 4, 3);
            Console.WriteLine(builder);
        }
        #endregion
    }
}
