using Questions.DataStructures.CommonElements;

namespace Questions.DataStructures.Tree.Elements.Node
{
    public interface IBTreeNode<T> : INode<T>
    {
        IBTreeNode<T> Left { get; set; }
        IBTreeNode<T> Right { get; set; }
    }
}
