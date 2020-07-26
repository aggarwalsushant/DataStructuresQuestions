using Questions.DataStructures.LinkedList.Elements.Lists;
using Questions.DataStructures.LinkedList.Elements.Node;
using System;
using System.Collections.Generic;
using System.Text;

namespace Questions.Utilities
{

    public class LLUtility
    {
        public static SinglyLinkedList<T> CreateSinglyLinkedList<T>(IEnumerable<T> collection)
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

        public static void PrintLinkedList<T>(SinglyLinkedList<T> linkedList)
        {
            var node = linkedList.Head;
            var builder = new StringBuilder();
            builder.Append("Head ");

            while (node != null)
            {
                builder.Append(node.Value).Append(" -> ");
                node = node.Next;
            }

            builder.Remove(builder.Length - 4, 3);
            Console.WriteLine(builder);
        }

        public static void PrintLinkedListViaNodeDirectly<T>(SinglyNode<T> node) =>
            PrintLinkedList(new SinglyLinkedList<T>() { Head = node });
    }

}
