namespace Questions.DataStructures.LinkedList.Elements.Lists
{
    public interface ILinkedList<T>
    {
        #region AbstractProperties
        int Count { get; }
        #endregion

        #region Methods
        void Print();
        #endregion
    }
}
