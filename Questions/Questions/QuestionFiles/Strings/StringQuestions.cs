using Questions.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.QuestionFiles.Strings
{
    public partial class StringQuestions
    {
        #region In Progress
        #endregion

        #region Completed

        /// <summary>
        /// Microsoft F2F interview I/v Question
        /// Given a number (start year) and an iteration count
        /// provide a single line lambda/linq to print the day
        /// on 1 Jan of each year separated by comma.
        /// </summary>
        public static void SingleLineLambda()
        {
            var str =
                String.Join(",",
                    from year in Enumerable.Range(2019, 20)
                    select new DateTime(year, 1, 1).Date.DayOfWeek
                    );
            Console.WriteLine(str);
        }

        /// <summary>
        /// MinimumNumberOfStations, SC: O(m), TC: O(n*m)
        /// n: no of trains, m: no of max potential platforms
        /// </summary>
        public static void MinimumNumberOfStations()
        {
            //var arrivals = new int[] { 900, 940, 950, 1100, 1500, 1800 };
            //var departures = new int[] { 910, 1200, 1120, 1130, 1900, 2000 };
            var arrivals = new int[] { 900, 905, 1001, 1100, 1100, 1120, 1135 };
            var departures = new int[] { 910, 915, 1009, 1300, 1115, 1125, 1140 };
            var maxCount = 1;

            var platforms = new List<Tuple<int, int>>();
            platforms.Add(new Tuple<int, int>(arrivals[0], departures[0]));

            for (int i = 1; i < arrivals.Length; i++)
            {
                for (int j = 0; j < platforms.Count; j++)
                {
                    if (!IsOverlapping(platforms[j].Item1, platforms[j].Item2, arrivals[i], departures[i]))
                        platforms.RemoveAt(j);
                }

                platforms.Add(new Tuple<int, int>(arrivals[i], departures[i]));
                maxCount = platforms.Count > maxCount ? platforms.Count : maxCount;
            }

            Console.WriteLine($"{maxCount}");

            // simple concept
            // a.start < b.end && b.start < a.end
            bool IsOverlapping(int existingTrainIn, int existingTrainOut, int newTrainIn, int newTrainOut)
                => newTrainOut >= existingTrainIn && newTrainIn <= existingTrainOut;
        }

        /// <summary>
        /// CheckedIfStringIsRotatedByTwoPlaces, TC: O(n*m), SC: O(m)
        /// m is no of cases, n is string length
        /// </summary>
        public static void CheckedIfStringIsRotatedByTwoPlaces()
        {
            var numberOfCases = 1; //int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCases; i++)
            {
                var flag = false;
                var target = "amazon"; //Console.ReadLine();
                var source = "azonam"; //Console.ReadLine();
                var temp = source.ToCharArray();

                // Left rotation
                Utility.Reverse(ref temp, 0, 1);
                Utility.Reverse(ref temp, 2, temp.Length - 1);
                Utility.Reverse(ref temp);

                if (new string(temp.ToArray()) == target)
                {
                    Console.WriteLine(1);
                    continue;
                }

                temp = source.ToCharArray();
                // Right Rotation
                Utility.Reverse(ref temp);
                Utility.Reverse(ref temp, 0, 1);
                Utility.Reverse(ref temp, 2, temp.Length - 1);

                Console.WriteLine(new string(temp.ToArray()) == target ? 1 : 0);
            }
        }

        /// <summary>
        /// RecursivelyRemoveAllAdjacentDuplicatesInAString, TC: O(n*m), SC: O(1)
        /// </summary>
        public static void RecursivelyRemoveAllAdjacentDuplicatesInAString()
        {
            var numberOfCases = 1;//int.Parse(Console.ReadLine());

            for (int j = 0; j < numberOfCases; j++)
            {
                var str = "geeeksforgeek";// Console.ReadLine(); //"mississipie";////"acaaabbbacdddd";//"geeeksforgeek";
                var list = new List<char>(); var masterCheck = false;

                while (!masterCheck)
                {
                    // starting with an assumption that we have
                    // different element in the string
                    var repeatingElement = false;

                    // Loop this till second last element since
                    // we compare current and next element
                    for (int i = 0; i < str.Length - 1; i++)
                    {
                        #region comment
                        // if current index char is different from
                        // from next index then check the previous flag.
                        // If it's false, this means we had different element
                        // JUST PRECEDING this comparison and THIS element
                        // can be printed/allowed. e.g. ABC and we are comparing
                        // B and C and we had A just before this comparison which
                        // will have FLAG as false.
                        // If we move from repeating elements to non repeating ones
                        // then we still avoid that element BUT set flag to false
                        // (to indicate NEW non repitition).
                        #endregion
                        if (str[i] != str[i + 1])
                        {
                            if (!repeatingElement)
                            {
                                //Console.Write(str[i]);
                                list.Add(str[i]);
                            }
                            else
                            {
                                #region comment
                                // We set flag to false AND also skip this element
                                // to be printed.
                                #endregion
                                repeatingElement = false;
                            }
                        }
                        else
                        {
                            repeatingElement = true;
                        }
                    }

                    #region comment
                    // if our flag was false (in the end) signifying that
                    // we had a different element at the end. Then print it.
                    #endregion
                    if (!repeatingElement)
                        list.Add(str[str.Length - 1]);

                    // Now check whether we still have
                    // non repeating adjacent elements.
                    // if no, we repeat this removal process.
                    int k = 1; masterCheck = true;
                    while (masterCheck && k < list.Count)
                    {
                        masterCheck = list[k - 1] == list[k] ? false : true;
                        k++;
                    }

                    // if we have repetitively removed all
                    // repeating adjacent elements, then we print and come outside
                    if (!masterCheck)
                    {
                        str = new string(list.ToArray());
                        list.Clear();
                    }

                }

                Console.WriteLine(new string(list.ToArray()));
            }
        }

        /// <summary>
        /// LongestPalindromeInAString, TC: O(n^2), SC: O(1)
        /// </summary>
        public static void LongestPalindromeInAString()
        {
            var str = "baaaabbaa";
            var longestPalindrome = String.Empty;
            var index = -1;
            var builder = new StringBuilder();

            for (int i = 0; i < str.Length; i++)
            {
                for (int j = i; j < str.Length; j++)
                {
                    builder.Append(str[j]);

                    if (IsPalindrome(builder.ToString()) && builder.Length > longestPalindrome.Length)
                    {
                        longestPalindrome = builder.ToString();
                        index = i;
                    }

                }

                builder.Clear();
            }

            if (longestPalindrome != String.Empty)
                Console.WriteLine($"{longestPalindrome} is at index {index}");

            bool IsPalindrome(string substr)
            {
                int start = 0, end = substr.Length - 1;

                while (start < end)
                {
                    if (substr[start] != substr[end])
                        return false;

                    start++;
                    end--;
                }

                return true;
            }
        }


        /// <summary>
        /// Print Star Pyramid, TC: O(n^2), SC: O(1)
        /// </summary>
        public static void PrintStarPyramid()
        {
            var levels = 5;

            for (int i = 0; i < levels; i++)
            {
                for (int j = levels - i - 1; j > 0; j--)
                {
                    Console.Write(" ");
                }

                for (int k = levels - i - 1; k < levels; k++)
                {
                    Console.Write("* ");
                }

                Console.WriteLine();
            }
        }

        /// <summary>
        /// ReverseWordsInGivenString, TC: O(n), SC: O(m)
        /// </summary>
        public static void ReverseWordsInAGivenString()
        {
            var str = "i.like.this.program.very.much";
            var builder = new StringBuilder();
            var stack = new Stack<string>();

            for (int i = 0; i < str.Length; i++)
            {
                if (!(str[i].Equals('.')))
                    builder.Append(str[i]);
                else
                {
                    stack.Push(builder.ToString());
                    builder.Clear();
                }
            }

            // Add in last element of the array to the stack.
            stack.Push(builder.ToString());
            builder.Clear();

            while (stack.Count !=0)
            {
                builder.Append(stack.Pop());
                builder.Append(".");
            }

            // Remove last . from the string.
            builder = builder.Remove(builder.Length - 1, 1);
            Console.WriteLine(builder);
        }

        /// <summary>
        /// ReverseString, TC: O(n), SC: O(n)
        /// </summary>
        public static void ReverseString()
        {
            var str = "edcba".ToCharArray();
            int start = 0, end = str.Length - 1;

            Utility.Reverse<char>(ref str);

            Console.WriteLine(new string(str));
        }

        /// <summary>
        /// Parenthesis Checker TC: O(n), SC: O(1)
        /// </summary>
        public static void ParenthesisChecker()
        {
            var str = "([]";
            Stack<int> stack = new Stack<int>();
            int start = 0;
            var flag = true;

            for (int i = 0; i < str.Length; i++)
            {
                switch (str[i])
                {
                    case '[': stack.Push(2); break;
                    case '(': stack.Push(3); break;
                    case '{': stack.Push(5); break;
                    case ']':
                        {
                            start = stack.Pop();
                            if (start != 2)
                                flag = false;
                        }
                        break;
                    case ')':
                        {
                            start = stack.Pop();
                            if (start != 3)
                                flag = false;
                        }
                        break;
                    case '}':
                        {
                            start = stack.Pop();
                            if (start != 5)
                                flag = false;
                        }
                        break;

                    default:
                        break;
                }

                if (!flag)
                    break;
            }

            if (stack.Count == 0)
                Console.WriteLine("balanced");
            else
                Console.WriteLine("Unbalanced");
        }

        public static void CheckTextAsPalindrome()
        {
            string inputString = "zzzazzazz";
            bool flag = false;
            int length = inputString.Length % 2 == 0 ? inputString.Length : inputString.Length + 1;
            for (int i = 0; i < length / 2; i++)
            {
                if (inputString[i] != inputString[inputString.Length - i - 1])
                {
                    flag = false;
                    break;
                }
                else
                    flag = true;
            }

            Console.WriteLine("{0} is {1} a palindrome.", inputString, flag ? "" : "not");
            Console.ReadLine();
        }
        #endregion

    }
}
