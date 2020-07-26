namespace Questions.DataStructures.LinkedList.Elements.Node
{
    public class DoublyNode<T>: IDoublyNode<T>
    {
        public DoublyNode(T value) => Value = value;

        public IDoublyNode<T> Previous { get; set; }

        public IDoublyNode<T> Next { get; set; }

        public T Value { get; }
    }
}