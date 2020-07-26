namespace Questions.DataStructures.Tree.Elements.Node
{
    public class BTreeNode<T> : IBTreeNode<T>
    {
        public IBTreeNode<T> Left { get; set; }
        public IBTreeNode<T> Right { get; set; }
        public T Value { get; }

        public BTreeNode(T value) => Value = value;
    }
}
