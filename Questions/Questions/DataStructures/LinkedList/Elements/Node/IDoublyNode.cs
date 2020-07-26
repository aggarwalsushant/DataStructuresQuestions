using Questions.DataStructures.CommonElements;

namespace Questions.DataStructures.LinkedList.Elements.Node
{
    // Doubly node - which has Next & Previous
    public interface IDoublyNode<T> : INode<T>
    {
        IDoublyNode<T> Previous { get; set; }
        IDoublyNode<T> Next { get; set; }
    }
}
