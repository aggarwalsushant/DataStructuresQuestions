namespace Questions.DataStructures.LinkedList.Elements.Node
{
    public class SinglyNode<T>: ISinglyNode<T>
    {
        public SinglyNode(T value) => Value = value;

        public ISinglyNode<T> Next { get; set; }

        public T Value { get; }
    }
}
