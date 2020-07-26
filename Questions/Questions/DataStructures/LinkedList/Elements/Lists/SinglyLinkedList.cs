using Questions.DataStructures.LinkedList.Elements.Node;

namespace Questions.DataStructures.LinkedList.Elements.Lists
{
    public class SinglyLinkedList<T>
    {
        public ISinglyNode<T> Head;
        public ISinglyNode<T> Last;
        public int Count { get; private set; }

        // Add element at end
        public void AddAtEnd(ISinglyNode<T> node)
        {
            if (Head == null)
            {
                Last = Head = node;
            }
            else
            {
                Last.Next = node;
                Last = node;
            }

            Count++;
        }
    }
}
