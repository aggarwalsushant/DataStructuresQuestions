using Questions.DataStructures.LinkedList.Elements.Lists;
using Questions.DataStructures.LinkedList.Elements.Node;
using System.Collections.Generic;

namespace Questions.Utilities
{

    public class LLUtility
    {
        public static ISinglyLinkedList<T> CreateSinglyLinkedList<T>(IEnumerable<T> collection)
        {
            var linkedList = new SinglyLinkedList<T>();

            // add in linked list
            foreach (var item in collection)
            {
                var node = new SinglyNode<T>(item);
                linkedList.AddAtEnd(node);
            }

            return linkedList;
        }
    }

}
