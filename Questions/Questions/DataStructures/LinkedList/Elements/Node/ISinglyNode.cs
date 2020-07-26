using Questions.DataStructures.CommonElements;

namespace Questions.DataStructures.LinkedList.Elements.Node
{
    public interface ISinglyNode<T> : INode<T>
    {
        ISinglyNode<T> Next { get; set; }
    }
}
