using Questions.DataStructures.LinkedList.Elements.Node;
using Questions.Utilities;
using System;
using System.Linq;

namespace Questions.QuestionFiles.LinkedList
{
    public partial class LinkedListQuestions
    {
        #region InProgress

        #endregion

        #region Complete


        /// <summary>
        /// FindMiddleElement, TC: O(n), SC: O(1)
        /// </summary>
        public static void FindMiddleElement()
        {
            var linkedList = LLUtility.CreateSinglyLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 }.Cast<int>());

            // look for middle element now
            var node = linkedList.Head;
            ISinglyNode<int> middleNode = null;
            var flag = true;

            while (node != null)
            {
                if (flag)
                    middleNode = middleNode == null ? linkedList.Head : middleNode.Next;

                flag = !flag;
                node = node.Next;
            }

            Console.WriteLine(middleNode.Value);
        }

        /// <summary>
        /// ReverseLinkedList, TC: O(n), SC: O(1)
        /// </summary>
        public static void ReverseLinkedList()
        {
            var list = LLUtility.CreateSinglyLinkedList(new int[] { 1, 2, 3 }.Cast<int>());
            list.Print();

            // Take 3 elements for this process.
            ISinglyNode<int> previous, current, next;

            /* start with previous set to head, current to second element
             * 0. Iterate till C is not NULL.
             * 1. We backup NEXT series from C and reverse ties with P and C.
             * 2. If NEXT series is not null, then shift element by 1, C = Next of C and P = C.
             * else, SET Next of HEAD of list to NULL and HEAD = C
             * 3. Set C = Backed up series i.e. N
             *
             * INCREASE POINTERS ONE BY ONE
             */

            /* Previous = 1st node, Current = 2nd node
              */
            previous = list.Head;
            current = list.Head.Next;

            while (current != null)
            {
                /* Save the chain ahead of Current.
                 * Reverse the flow. Current -> Previous
                 * Shift the previous ahead to current now
                 */
                next = current.Next;
                current.Next = previous;
                previous = current;

                /* If we reach the end of the list, then we have 1st node (which is the Head of the list)
                 * at the end of the list. Set it's _Next_ as NULL and reset list's Head as current
                 * (which is the current element - so called last element of the original list).
                 */
                if (next == null)
                {
                    list.Head.Next = null;
                    list.Head = current;
                }

                // Shift the current ahead to Next (i.e. shift ahead by 1 node)
                current = next;
            }

            Console.WriteLine();
            list.Print();
        }

        /// <summary>
        /// RotateLinkedList, TC: O(n), SC: O(1)
        /// </summary>
        public static void RotateLinkedList()
        {
            var list = LLUtility.CreateSinglyLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }.Cast<int>());
            Console.WriteLine("Original Linked List");
            list.Print();
            int toBeRotated = 3, counter = 0;

            Console.WriteLine($"Rotation count: {toBeRotated}\n");

            ISinglyNode<int> newLastNode= null, node = list.Head;

            // Iterate till we reach last node
            while (node.Next != null)
            {
                // Save the node which is to be made LAST
                if (counter == toBeRotated - 1)
                    newLastNode = node;

                node = node.Next;
                counter++;
            }

            // Last node is the new linking node.
            var linkingNode = node;

            // 1. Link the last node to old HEAD now.
            // 2. Reset the HEAD to new node.
            // 3. Set NEW LAST NODE's next to NULL
            linkingNode.Next = list.Head;
            list.Head = newLastNode.Next;
            newLastNode.Next = null;

            list.Print();
        }

        /// <summary>
        /// ReverseLinkedListPostNnodes, TC: O(n), SC: O(1)
        /// </summary>
        public static void ReverseLinkedListPostNnodes()
        {
            var list = LLUtility.CreateSinglyLinkedList(new int[] { 1, 2, 3, 4, 5, 6 }.Cast<int>());
            int counter = 2, index = 0; // reverse after 2 nodes

            list.Print();

            var node = list.Head;
            ISinglyNode<int> intervalLinkNode = null, previous = null, current = null;

            // Save the node after which you will reverse your list.
            // and mark the next two nodes as previous and current
            // for reversal process
            while (node != null)
            {
                if (index == counter - 1)
                {
                    intervalLinkNode = node;
                    previous = intervalLinkNode.Next;
                    current = previous.Next;
                    break;
                }

                node = node.Next;
                index++;
            }

            ISinglyNode<int> next = null;
            while (current != null)
            {
                next = current.Next;
                current.Next = previous;

                if (next == null)
                {
                    // Reset the interval node's NEXT element to NULL AS END
                    // set the interval's NEXT as the current element which is actually last
                    intervalLinkNode.Next.Next = null;
                    intervalLinkNode.Next = current;
                    break;
                }

                previous = current;
                current = next;
            }

            list.Print();
        }

        /// <summary>
        /// ReverseLinkedListInPairs, TC: O(n), SC: O(1)
        /// </summary>
        public static void ReverseLinkedListInPairs()
        {
            var list = LLUtility.CreateSinglyLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8 }.Cast<int>());
            list.Print();

            int counter = 0;
            ISinglyNode<int> previous, current, next, intervalLinkNode;
            previous = current = next = intervalLinkNode = null;

            // Everytime for reversal take 3 elements
            // first element - previous, 2nd - current
            // till you reverse both of them...save the NEXT of 2nd element in "next"
            previous = list.Head;
            current = previous.Next;

            while (current != null)
            {
                next = current.Next;
                previous.Next = next;
                current.Next = previous;

                if (counter == 0)
                    list.Head = current;
                else
                    // save the interval last node to point to so-called
                    // current node which will become First element in the pair
                    intervalLinkNode.Next = current;

                // shift the interval node to Last of the Pair.
                intervalLinkNode = previous;
                previous = next;

                // check do we even have new previous element
                // if yes, do we have NEXT of previous to reverse.
                // if no, then break out from the loop.
                current = previous != null && previous.Next != null ? previous.Next : null;
                counter++;
            }

            list.Print();
        }

        /// <summary>
        /// ReverseLinkedListInGroupsOfGivenSize, TC: O(n*groupsize), SC: O(1)
        /// https://www.geeksforgeeks.org/reverse-a-list-in-groups-of-given-size/
        /// </summary>
        public static void ReverseLinkedListInGroupsOfGivenSize()
        {
            var list = LLUtility.CreateSinglyLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9 }.Cast<int>());
            list.Print();

            // counter for iteration tracking. Groupsize as given!
            int groupSize = 4, counter;

            // Keep 5 variables. For reversal, usual concept of 3 vars: previous, current and next.
            //
            // intervalLinkNode is for keeping it the first node (which will become last of the group)
            // and will point to (LAST element of the upcoming group - which will become FIRST of that upcoming group)
            //
            // changerNode is for shifting the intervalLinkNode to "NEW" Last node of the reversed group
            // to point to (LAST element of the upcoming group - which will become FIRST of that upcoming group)
            ISinglyNode<int> previous, current, next, intervalLinkNode, changerNode;
            previous = current = next = intervalLinkNode = changerNode = null;

            // this is just to RESET the Head to last element of the first group.
            // After it is false, it will be useless.
            var flag = true;

            // Everytime for reversal take 3 elements. Previous as 1st element, Current as 2nd element
            previous = list.Head;
            current = previous.Next;

            while (current != null)
            {
                counter = 1;

                /* On start, we have interval node as NULL but in next iterations we will have it as
                 * FIRST node of the group which will become LAST after reversal. This will then point
                 * to FIRST node of the upcoming group (which will actually be the LAST element of the
                 * upcoming group before reversal)
                 */
                if (intervalLinkNode != null)
                    intervalLinkNode.Next = previous;

                // Taking this to shift the intervalLinkNode as to Last node of the group.
                // Just for shifting after each iteration.
                changerNode = previous;

                // Iterate till entire group is reversed and you have no more left. i.e. multiple of group size
                // OR you have an incomplete group at the end, so we will break from the loop.
                while (current != null && counter < groupSize)
                {
                    /* Save the chain ahead of Current.
                     * Reverse the flow. Current -> Previous
                     * Shift the previous ahead to current now
                     */
                    next = current.Next;
                    current.Next = previous;

                    // shift counters by one node
                    previous = current;
                    current = next;
                    counter++;
                }

                if (flag)
                {
                    /* set the intervalnode to Head because this will point to new node now
                     * as it has become last element of the first group.
                     * Set Head to the last element of the first group (this is now first element)
                     *
                     * Disable flag.
                     */
                    intervalLinkNode = list.Head;
                    list.Head = previous;
                    flag = !flag;
                }
                else
                {
                    /* Connect the intervalNode (which is of the last group) to New _reversed_ first
                     * node of current group.
                     * Shift the interval node to First element (previous) of the current group
                     * which has now become the last element after reversal.
                     */
                    intervalLinkNode.Next = previous;
                    intervalLinkNode = changerNode;
                }


                // shift counters to first element of next node
                // just like we started inside the inner while loop
                previous = current;

                /* reached the end of the list? then set the intervalNode Next to null
                   mark the end of the list. Come out now!
                 */
                if (current == null)
                {
                    intervalLinkNode.Next = null;
                    break;
                }

                /* If we have completed the group reversal (no of elements are multiple of group size).
                 * Then link the interval node to first element of reversed group. and it will
                 * automatically come out since current has become NULL.
                 */
                current = previous.Next;
                if (current == null)
                {
                    intervalLinkNode.Next = previous;
                }
            }

            list.Print();
        }
        #endregion
    }
}
