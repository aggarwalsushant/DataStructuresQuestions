using Questions.Utilities;
using System.Collections.Generic;


namespace Questions.QuestionFiles.Arrays
{
    public partial class ArrayQuestions
    {
        /// <summary>
        /// PrintNoOfDistinctElementsInASmallWindowInArray, TC: O(n), SC: O(window)
        ///
        /// https://www.geeksforgeeks.org/count-distinct-elements-in-every-window-of-size-k/
        /// </summary>
        public static void PrintNoOfDistinctElementsInASmallWindowInArray()
        {
            var array = new int[] { 1, 2, 1, 3, 4, 2, 3 };
            const int window = 4;

            var dict = new Dictionary<int, int>(); // to keep track of elements and their count
            var distinctCountList = new List<int>(); // to store distinct count in every window

            /* iterate for first window
             * and add the elements in dict. Increase the count if they preexist
             * else add with count 1
             */
            for (int i = 0; i < window; i++)
            {
                if (dict.ContainsKey(array[i]))
                    ++dict[array[i]];
                else
                    dict.Add(array[i], 1);
            }

            // first push to add 1 element in our list which print distict counts in window
            distinctCountList.Add(dict.Keys.Count);

            // since we have already iterated through first window
            // and now need to attempt via second window.
            for (int i = window; i < array.Length; i++)
            {
                /* LOGIC: First we take the FIRST element of previous
                 * window and reduce its count FOR OUR CURRENT WINDOW
                 * because *we have slided ahead by one item ahead now*....
                 * If count is 1, then we remove it from dict else
                 * just reduce the count of that element by 1 because even
                 * that element had been repeated in previous window
                 * it's one presence is removed by our sliding ahead..!!!
                 */
                var previousFirstCount = dict[array[i - window]];
                if (previousFirstCount == 1)
                    dict.Remove(array[i - window]);
                else
                    --dict[array[i - window]];

                /* let's add new element. If it pre-exists
                 * increase the counter else add with 1 as count.
                 */
                if (dict.ContainsKey(array[i]))
                    ++dict[array[i]];
                else
                    dict.Add(array[i], 1);

                // At iteration end, just count the no of keys in dict.
                distinctCountList.Add(dict.Count);
            }

            // Print the no of distinct elements now..
            Utility.PrintPlainElements(distinctCountList);
        }

    }
}
