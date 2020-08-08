using Questions.DataStructures.LinkedList.Elements.Node;
using Questions.Utilities;
using System.Collections.Generic;
using System.Linq;

namespace Questions.QuestionFiles.LinkedList
{
    public partial class LinkedListQuestions
    {
        /// <summary>
        /// ReverseLinkedListInGroupsOfGivenSizeV2 (Using Stack), TC: O(n*groupsize), SC: O(groupSize)
        /// This is done via Stack and that's why takes more space.
        /// https://www.geeksforgeeks.org/reverse-linked-list-groups-given-size-set-2/
        ///
        /// It's previous attempt for better SC is in the file below.
        /// Method: ReverseLinkedListInGroupsOfGivenSize, TC: O(n*groupsize), SC: O(1)
        /// https://www.geeksforgeeks.org/reverse-a-list-in-groups-of-given-size/
        /// </summary>
        public void ReverseLinkedListInGroupsOfGivenSizeV2()
        {
            var list = LLUtility.CreateSinglyLinkedList(new int[] { 1, 2, 2, 4, 5, 6, 7, 8 });

            var head = list.Head;
            var flag = true;
            var tempNode = head;
            var size = 4;
            var stack = new Stack<ISinglyNode<int>>();
            ISinglyNode<int> tempNode2 = null;

            // iterate while your first moving temp node is valid
            while (tempNode != null)
            {
                // push elements in stack based on group size.
                for (int i = 0; i < size; i++)
                {
                    if (tempNode != null)
                    {
                        stack.Push(tempNode);
                        tempNode = tempNode.Next;
                    }
                    // if elements perish before group iteration completes, then come out.
                    else
                        break;
                }

                // We'll now pull out elements from stack to point to Head to begin
                // and then iterate through another temp node till we connect all stack
                // elements in reverse order. Post that, connect reversed list's END
                // to remaining "initial" list that still needs to be reversed.
                while (stack.Any())
                {
                    // Realign HEAD only once.
                    if (flag)
                    {
                        head = stack.Pop();
                        tempNode2 = head;
                        flag = false;

                        // Realigned HEAD now should point to the list.
                        list.Head = head;
                    }
                    else
                    {
                        tempNode2.Next = stack.Pop();
                        tempNode2 = tempNode2.Next;
                    }
                }

                // Now, connect reversed list's END
                // to remaining "initial" list that still needs to be reversed.
                tempNode2.Next = tempNode;

                list.Print();
            }
        }
    }
}
