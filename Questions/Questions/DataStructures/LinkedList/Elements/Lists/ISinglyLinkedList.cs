using Questions.DataStructures.LinkedList.Elements.Node;

namespace Questions.DataStructures.LinkedList.Elements.Lists
{
    public interface ISinglyLinkedList<T>: ILinkedList<T>
    {
        #region Properties
        ISinglyNode<T> Head { get; set; }
        ISinglyNode<T> Last { get; set; }
        #endregion

        #region AbstractMethods
        void AddAtEnd(ISinglyNode<T> node);
        #endregion
    }
}
