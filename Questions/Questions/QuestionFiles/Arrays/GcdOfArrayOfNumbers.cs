using Questions.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.QuestionFiles.Arrays
{
    public partial class ArrayQuestions
    {
        #region Gcd_of_array_of_numbers
        //efficient way
        public static void GcdArray(int length, int[] arr)
        {
            var result = arr[0];
            for (int i = 1; i < arr.Length; i++)
            {
                result = Utility.GetGcd(result, arr[i]);
            }

            Console.WriteLine(result);
        }

        // Inefficient way of calculating GCD of array of numbers
        public static void GcdOfArray(int length, int[] array)
        {
            Array.Sort(array);

            var hash = new HashSet<int>(array);

            var gcds = new HashSet<int>();
            var count = gcds.Distinct().Count();

            while (count != 1)
            {
                var startNum = hash.ElementAt(0);
                for (int i = 1; i < hash.Count(); i++)
                {
                    var gcd = Utility.GetGcd(startNum, hash.ElementAt(i));
                    gcds.Add(gcd);
                }

                hash.Clear();

                for (int i = 0; i < gcds.Count(); i++)
                {
                    hash.Add(gcds.ElementAt(i));
                }
                count = gcds.Distinct().Count();
                gcds.Clear();
            }

            IEnumerable<int> list = hash.Distinct();

            Utility.PrintPlainElements(list);
            return;
        }
        #endregion

    }
}
