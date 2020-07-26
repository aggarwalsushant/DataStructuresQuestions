using System;
using System.Collections.Generic;
using System.Linq;

namespace Questions.Utilities
{
    public class Utility
    {
        /*
         * This method performs a binary search on an array
         * which is sorted in increasing order from left to right.
         */
        public static int BinarySearch(int[] array, int find, int start, int end)
        {
            int index = -1, mid = -1;

            if (end >= start)
            {
                var arrayLength = end - start + 1;
                mid = start + (arrayLength / 2);

                if (array[mid] == find)
                    return mid;

                else if (find < array[mid])
                    index = BinarySearch(array, find, start, mid - 1);

                else
                    index = BinarySearch(array, find, mid + 1, end);
            }

            return index;
        }

        /**
         * Efficient way of finding the GCD of two numbers
         * based on Euclidean Algorithm.
         */
        public static int GetGcd(int a, int b)
        {
            while (a != 0 && b != 0)
            {
                if (a > b)
                    a %= b;
                else
                    b %= a;
            }

            return a == 0 ? b : a;
        }

        public static void Swap<T>(ref T a, ref T b)
        {
            T temporary = a;
            a = b;
            b = temporary;
        }

        /// <summary>
        /// This method swaps some parts of the array starting
        /// from an index and second index is tha place we will
        /// swap from. Swaps happen for "noOfElements".
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="a"></param>
        /// <param name="firstIndex"></param>
        /// <param name="secondIndex"></param>
        /// <param name="noOfElements"></param>
        public static void SwapSomeArrayParts<T>(ref T[] a, int firstIndex, int secondIndex, int noOfElements)
        {
            for (int i = 0; i < noOfElements; i++)
            {
                Swap<T>(ref a[firstIndex + i], ref a[secondIndex + i]);
            }
        }

        public static T[] GetPartOfArray<T>(T[] array, int start, int end)
        {
            if (end < start)
                return null;

            var length = end - start + 1;
            var part = new T[length];
            for (int i = 0; i < length; i++)
            {
                part[i] = array[start + i];
            }

            return part;
        }

        public static void Print<T>(IEnumerable<T> items)
        {
            var props = typeof(T).GetProperties();

            foreach (var prop in props)
            {
                Console.Write("{0}\t", prop.Name);
            }
            Console.WriteLine();

            foreach (var item in items)
            {
                foreach (var prop in props)
                {
                    Console.Write("{0}\t", prop.GetValue(item, null));
                }
                Console.WriteLine();
            }
        }

        public static void PrintPlainElements<T>(IEnumerable<T> items, bool tabbed = true)
        {
            foreach (var item in items)
            {
                Console.Write($"{item}{(tabbed ? "\t" : "\n")}");
            }
            Console.WriteLine();
        }

        public static void Print<T>(IEnumerable<T> items, int start, int end, bool tabbed = true)
        {
            for (int i = start; i <= end; i++)
                Console.Write($"{items.ElementAt<T>(i)}{(tabbed ? "\t" : "\n")}");

            Console.WriteLine();
        }

        public static void Reverse<T>(ref T[] array) => Reverse(ref array, 0, array.Length - 1);

        public static void Reverse<T>(ref T[] array, int start, int end)
        {
            while (start < end)
            {
                Utility.Swap<T>(ref array[start], ref array[end]);
                ++start;
                --end;
            }
        }

        public static void SplitArrayInTwoParts<T>(T[] array, int splitIndex, out T[] first, out T[] second)
        {
            first = new T[splitIndex];
            second = new T[array.Length - splitIndex];
            var j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i < splitIndex)
                    first[i] = array[i];
                else
                {
                    second[j] = array[i];
                    j++;
                }
            }
        }

        public static void SplitArrayInTwoPartsPreInitialised<T>(T[] array, int splitIndex, ref T[] first, ref T[] second)
        {
            var j = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i < splitIndex)
                    first[i] = array[i];
                else
                {
                    second[j] = array[i];
                    j++;
                }
            }
        }

        public static void InsertionSort(ref int[] array, int start, int end)
        {
            //var beginCounter = -1;

            //for (int i = 0; i < end; i++)
            //{
            //    for (int j = i+1; j > 0; j--)
            //    {
            //        if (array[j] > a )
            //        {

            //        }
            //    }
            //}

        }

        public static void InsertionSort(ref int[] array) => InsertionSort(ref array, 0, array.Length - 1);
    }

}
