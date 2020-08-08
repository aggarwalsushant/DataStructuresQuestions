using System;

namespace Questions.QuestionFiles.Arrays
{
    public partial class ArrayQuestions
    {

        /// <summary>
        /// MinProductPairwiseProductInArrayWithIntegers, TC: O(n), SC: O(1)
        /// The numbers in the array could be positive or negative both.
        ///
        /// Another GFG question with only positive integers is
        /// https://www.geeksforgeeks.org/minimum-product-pair-an-array-of-positive-integers/
        /// </summary>
        public static void MinProductPairwiseProductInArrayWithIntegers()
        {
            //var array = Console.ReadLine().Split(' ').Select(x => Convert.ToInt32(x)).ToArray();

            var array = new int[] { 2, 3, -2, -3, 4 };
            int first, second, max;

            if (array[0] < array[1])
            {
                first = array[0];
                second = array[1];
                max = second;
            }
            else
            {
                first = array[1];
                second = array[0];
                max = first;
            }

            for (int i = 2; i < array.Length; i++)
            {
                if (array[i] < first)
                {
                    second = first;
                    first = array[i];
                }
                else if (array[i] < second)
                {
                    second = array[i];
                }
                else if (array[i] > max)
                    max = array[i];
            }

            if (first < 0)
                Console.Write(first * max);
            else
                Console.Write(first * second);
        }

    }
}
