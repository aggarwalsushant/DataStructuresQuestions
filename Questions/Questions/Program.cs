using Questions.QuestionFiles.LinkedList;
using Questions.QuestionFiles.Arrays;

using System;
using Questions.Utilities;
using System.Linq;
using Questions.DataStructures.LinkedList.Elements.Node;
using Questions.DataStructures.LinkedList.Elements.Lists;

namespace Questions
{
    class Program
    {
        static void Main(string[] args)
        {
            //int[] array = new int[] { 2, 3, 2, 1, 5, 1 };
            //int answer = Questions.FindFirstDuplicate(array);
            //Console.WriteLine(answer < 0 ? "No duplicates." : "First Duplicate: " + answer);
            //Questions.RotateImageBy90Degrees();

            //Questions.CreateTwoConstructorsOfSingletonClass();


            //Questions.PrintPyramidShapeUsingANumber();
            //ArrayQuestions.ArrayRotation();

            //ArrayQuestions.SearchElementInSortedAndRotatedArray();
            //ArrayQuestions.Find_Pairs_With_Given_Sum_In_Sorted_And_Rotated_Array();

            //ArrayQuestions.Find_Maximum_Value_Of_Sum_Of_Index_And_Element_With_Only_Rotations_Allowed();
            //ArrayQuestions.RotationCountInClockwiseRotatedSortedArray();
            //ArrayQuestions.FindMaxHammingDistance();
            //ArrayQuestions.FindMinimumElementInSortedAndRotatedArray();
            //ArrayQuestions.QueriesOnLeftAndRightCircularShiftOnArray();
            //ArrayQuestions.FindElementAtGivenIndexAfterNoOfRotations();
            //ArrayQuestions.ParenthesisChecker();

            //ArrayQuestions.KadaneAlgorithm();


            //ArrayQuestions.TrickOrTreat();
            //List<int> numbers = new List<int>() { 5, 5, 3, 2, 5, 1 };
            //int target = 12;
            //ArrayQuestions.sum_up(numbers, target);

            //StringQuestions.MinimumNumberOfStations();
            //StringQuestions.LongestPalindromeInAString();
            //LinkedListQuestions.RotateLinkedList();
            //LinkedListQuestions.ReverseLinkedListInGroupsOfGivenSize();
            //ArrayQuestions.BeautifulSubarrays();
            //ArrayQuestions.SingleLineLambda();

            //StringQuestions.MatchRegex();

            //Console.WriteLine(ArrayQuestions.SudokuChecker() ? true : false);
            //ArrayQuestions.IsCryptSolution();
            //ArrayQuestions.CountHourglass();

            //var array = new int[] { 1,0,0,0,0,1,0,0 };
            //var array = new int[] { 1,1,1,0,1,1,1,1 };
            //ArrayQuestions.cellCompete(array, 2);

            //var array = new int[] { 2,3,4,5,6 };
            //ArrayQuestions.GcdOfArray(array.Length, array);
            //ArrayQuestions.GcdArray(array.Length, array);

            //Clusters();

            //ArrayQuestions.KthLargestElementInAnArray();
            //var llObj = new LinkedListQuestions();
            //llObj.ReverseLinkedListInGroupsOfGivenSizeV2();

            ISinglyLinkedList<int> linkedList = LLUtility.CreateSinglyLinkedList(new int[] { 1, 2, 3, 4, 5, 6, 7 }.Cast<int>());
            Console.WriteLine(linkedList.Count);
            //LLUtility.PrintLinkedList(linkedList);
            linkedList.AddAtEnd(new SinglyNode<int>(8));
            Console.WriteLine(linkedList.Count);
            //LLUtility.PrintLinkedList(linkedList);

            //ArrayQuestions.MinProductPairwiseProductInArrayWithIntegers();
            //ArrayQuestions.PrintNoOfDistinctElementsInASmallWindowInArray();
            Console.ReadLine();
            //IQueryable<object>
            //ICollection<int> a;
            //IList<int> b;
            //IDictionary<int, string> c;


        }

    }
}
