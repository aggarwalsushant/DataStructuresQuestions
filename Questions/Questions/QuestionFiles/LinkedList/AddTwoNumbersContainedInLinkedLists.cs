using Questions.DataStructures.LinkedList.Elements.Lists;
using Questions.DataStructures.LinkedList.Elements.Node;
using Questions.Utilities;

namespace Questions.QuestionFiles.LinkedList
{
    public partial class LinkedListQuestions
    {
        /// <summary>
        /// AddTwoNumbersContainedInLinkedLists
        ///
        /// Question: You are given two non-empty linked lists representing
        /// two non-negative integers. The digits are stored in reverse order
        /// and each of their nodes contain a single digit. Add the two
        /// numbers and return it as a linked list.
        /// You may assume the two numbers do not contain any leading zero, except the number 0 itself.
        ///
        /// LeetCode Question
        /// https://leetcode.com/problems/add-two-numbers/
        /// Type: LinkedList
        /// Difficulty: Medium
        /// </summary>
        public void AddTwoNumbersContainedInLinkedLists()
        {
            var l1 = LLUtility.CreateSinglyLinkedList(new int[] { 2,4,3 }).Head;
            var l2 = LLUtility.CreateSinglyLinkedList(new int[] { 5,6,4 }).Head;

            // Initialise it with 0 so we don't have to make flags for checking and iteration.
            // We'll just provide the output with next node instead.
            var sum = new SinglyNode<int>(0);

            int temp, q;
            temp = q =  0;
            ISinglyNode<int> sumPointer = sum;

            // checking the pointer with current digits. If both of them are null means numbers are finished.
            while (l1 != null || l2 != null)
            {

                // scan for nullables because numbers may not be of same length. If they aren't,
                // and one number finishes early then just replace it with 0 and don't hamper the addition
                temp = (l1?.Value ?? 0) + (l2?.Value ?? 0) + q;
                q = temp / 10; // carry

                sumPointer.Next = new SinglyNode<int>(temp % 10); // remainder goes as new node (actually sum of the nums)
                sumPointer = sumPointer.Next; // move it ahead to store the next remainder in the next iteration

                // move the pointer to next digits. Nullable is used since both the numbers may not be of same length.
                l1 = l1?.Next;
                l2 = l2?.Next;
            }

            // accomodate quotient/carry if it spills over. E.g. 11 > 1  1
            if (q > 0) sumPointer.Next = new SinglyNode<int>(q);

            //Return or Print the sum now..
            var list = new SinglyLinkedList<int>();
            list.Head = sum.Next;
            list.Print();
        }

    }
}
