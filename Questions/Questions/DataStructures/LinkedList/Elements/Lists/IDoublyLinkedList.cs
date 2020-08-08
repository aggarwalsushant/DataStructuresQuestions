using Questions.DataStructures.LinkedList.Elements.Node;

namespace Questions.DataStructures.LinkedList.Elements.Lists
{
    interface IDoublyLinkedList<T>: ILinkedList<T>
    {
        #region Properties
        IDoublyNode<T> Head { get; set; }
        IDoublyNode<T> Last { get; set; }
        #endregion

        #region AbstractMethods
        void AddAtEnd(IDoublyNode<T> node);
        #endregion
    }
}
