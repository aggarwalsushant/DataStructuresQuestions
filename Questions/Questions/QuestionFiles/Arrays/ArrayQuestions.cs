using Questions.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Questions.QuestionFiles.Arrays
{
    public partial class ArrayQuestions
    {
        #region InProgress
        #endregion

        #region Completed

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

        public static void KthLargestElementInAnArray()
        {
            /*
             Uses bubble sort to run the algo to sort the
            array in the descending order and run the sort
            till the Kth iteration only.
             */
            var array = new int[] { 3, 10, 1, 5, 10, 30 };
            var k = 2;
            int tempIndex, max;
            bool flag; //Swap only if this flag is true

            // thought is to use bubble sort in descending
            // order and stop at kth iteration.
            for (int i = 0; i < k; i++)
            {
                max = array[i];
                tempIndex = i;
                flag = false;

                for (int j = i+1; j < array.Length; j++)
                {
                    if (array[j] > max)
                    {
                        max = array[j];
                        tempIndex = j;
                        flag = true;
                    }
                }

                if (flag)
                    Utility.Swap(ref array[i], ref array[tempIndex]);

                Console.WriteLine($"Iteration {i+1}:");
                Utility.PrintPlainElements(array);
                Console.WriteLine($"{k}th Highest: {array[k-1]}");
            }
        }

        /// <summary>
        /// CountOfElementsFallingInGivenRange, TC: O(nLog(n)), SC: O(n)
        /// </summary>
        public static void CountOfElementsFallingInGivenRange()
        {
            #region question
            /*
            Question Text: Given an array of n integers in the range 0 to k,
            answer query about how many of n integers fall in to range [a,b]?
            First line of input contains n (no. of elements) and k (range)
            Second line contains n elements
            Third line contains q (number of query)
            Fourth line contains a, b
            Constraints : n, q <= 10^6, k <= 10^5, 0 <= a <= b <= 10^5 -1
            Testcase #1 :
            Input :
            6 10
            1 0 5 3 2 6
            3
            0 0
            1 2
            2 5
            Output: 1 2 3
             */
            #endregion
            var a = new int[] { 1, 0, 2, 3, 2, 6 };
            var min = 0;
            var max = 4;
            var array = a.ToList();

            // sort the array
            array.Sort();
            a = array.ToArray();
            // 0 1 2 3 5 6

            var lower = FindLowerIndex(a, min);
            var higher = FindHigherIndex(a, max);
            int count = higher - lower + 1;

            int FindLowerIndex(int[] arr, int search)
            {
                var start = 0;
                var end = array.Count - 1;
                var mid = 0;

                // reduce END till search is less than or equal to
                // pivot and if it is greater than pivot, then increase the
                // START. break when START surpasses END and return START
                // since END is the movement pointer and we need the
                // actual index, which is denoted by START
                while (start <= end)
                {
                    mid = (start + end) / 2;
                    if (search <= arr[mid])
                    {
                        end = mid - 1;
                    }
                    else if (search > arr[mid])
                    {
                        start = mid + 1;
                    }
                }

                return start;
            }

            int FindHigherIndex(int[] arr, int search)
            {
                var start = 0;
                var end = array.Count - 1;
                var mid = 0;

                // increase START till search is greater than or equal to
                // pivot and if it is less than pivot, then reducethe
                // END. break when START surpasses END and return END
                // since START is the movement pointer and we need the
                // actual index, which is denoted by END
                while (start <= end)
                {
                    mid = (start + end) / 2;
                    if (search < arr[mid])
                    {
                        end = mid - 1;
                    }
                    else if (search >= arr[mid])
                    {
                        start = mid + 1;
                    }
                }

                return end;
            }

            Console.WriteLine($"Count: {count}");
        }

        public static void HousesInStraightLine_ActiveInactive(int[] states, int days)
        {
            // Question link- https://www.geeksforgeeks.org/active-inactive-cells-k-days/
            var currentState = new int[states.Length+2];
            currentState[0] = currentState[currentState.Length - 1] = 0;
            for (int i = 1; i < currentState.Length-1; i++)
            {
                currentState[i] = states[i - 1];
            }

            var newState = new int[currentState.Length];

            var flag = true;
            int[] current = null, backup = null;
            for (int i = 0; i < days; i++)
            {
                current =  flag ? currentState : newState;
                backup  = !flag ? currentState : newState;

                for (int j = 1; j < current.Length - 1; j++)
                {
                    backup[j] = current[j - 1] ^ current[j + 1];
                }

                flag = !flag;
            }

            for (int i = 1; i < current.Length-1; i++)
            {
                Console.Write($"{backup[i]}\t");
            }
        }

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

        public static void CountHourglass()
        {
            var array = new int[,] {
                { -9 , -9 , -9 , 1  , 1 , 1 },
                { 0  , -9 , 0  , 4  , 3 , 2 },
                { -9 , -9 , -9 , 1  , 2 , 3 },
                { 0  , 0  , 8  , 6  , 6 , 0 },
                { 0  , 0  , 0  , -2 , 0 , 0 },
                { 0  , 0  , 1  , 2  , 4 , 0 }
            };

            int sum, maxSum = 0;
            int maxX = array.GetLength(0) - 2;
            int maxY = array.GetLength(1) - 2;

            for (int m = 0; m < maxX; m++)
            {
                for (int k = 0; k < maxY; k++)
                {
                    sum = array[m, k] + array[m, k+1] + array[m, k+2]
                            + array[m + 1, k + 1]
                        + array[m+2, k] + array[m + 2, k + 1] + array[m + 2, k + 2];

                    if (sum > maxSum)
                        maxSum = sum;
                }
            }

            Console.WriteLine(maxSum);
        }


        public static bool SudokuChecker()
        {
            var grid = new char[9, 9]
            {
                {'.','.','.','.','.','.','5','.','.'},
                {'.','.','.','.','.','.','.','.','.'},
                {'.','.','.','.','.','.','.','.','.'},
                {'9','3','.','.','2','.','4','.','.'},
                {'.','.','7','.','.','.','3','.','.'},
                {'.','.','.','.','.','.','.','.','.'},
                {'.','.','.','3','4','.','.','.','.'},
                {'.','.','.','.','.','3','.','.','.'},
                {'.','.','.','.','.','5','2','.','.'}
            };

            var hArray = new int[9];
            var vArray = new int[9];

            // verifying horizontal and vertical lines
            for (int i = 0; i < hArray.Length; i++)
            {
                for (int j = 0; j < hArray.Length; j++)
                {
                    if (!VerifyElement(ref hArray, grid[i, j]))
                        return false;

                    if (!VerifyElement(ref vArray, grid[j, i]))
                        return false;
                }

                //reset array.
                for (int k = 0; k < hArray.Length; k++)
                {
                    hArray[k] = 0;
                    vArray[k] = 0;
                }
            }

            //reset array.
            ResetArray(ref hArray);
            ResetArray(ref vArray);

            // check individual blocks now!!!
            // The most tricky part. We need to run it 9 times (bcz. 9 blocks)
            // manage the iterator counts properly...
            for (int counter = 0; counter < 9; counter++)
            {
                var hori = 3 * (counter % 3);
                var colChange = 3 * (counter / 3);

                for (int row = hori; row < hori + 3; row++)
                {
                    for (int column = colChange; column < colChange + 3; column++)
                    {
                        if (!VerifyElement(ref hArray, grid[row, column]))
                            return false;
                    }
                }

                ResetArray(ref hArray);
            }

            return true;

            bool VerifyElement(ref int[] array, char data)
            {
                var element = 0;
                if (data != '.')
                {
                    element = Convert.ToInt16(Char.GetNumericValue(data));

                    if (array[element - 1] == 0)
                        array[element - 1] = element;
                    else if (array[element - 1] > 0)
                    {
                        array[element - 1] *= -1;
                        return false;
                    }
                }

                return true;
            }
            void ResetArray(ref int[] array)
            {
                //reset array.
                for (int k = 0; k < array.Length; k++)
                {
                    array[k] = 0;
                }
            }
        }

        /// <summary>
        /// BeautifulSubarrays | TC: O(n^3), SC: O(1)
        /// Vijay's Microsoft coding challenge question 1
        /// Interview I/V
        /// </summary>
        public static void BeautifulSubarrays()
        {
            var array = new int[] { 1, 2, 3, 4, 5 };
            int beautifulNumber = 1, start, end;
            int noOfArrays = 0;
            start = 0;
            end = beautifulNumber - 1;

            Console.WriteLine("Beautiful subarray:\n");
            while (start < array.Length - beautifulNumber + 1)
            {
                while (end < array.Length)
                {
                    GetBeautifulSubarray(array, start, end);
                    end++;
                }

                start++;
                end = start + beautifulNumber - 1;
            }

            Console.WriteLine($"\nTotal no of beautiful subarrays: {noOfArrays}");

            void GetBeautifulSubarray(int[] fullArray, int startIndex, int endIndex)
            {
                var counter = 0;
                for (int i = startIndex; i <= endIndex; i++)
                {
                    if (fullArray[i] % 2 != 0)
                        counter++;
                }

                if (counter == beautifulNumber)
                {
                    noOfArrays++;
                    Utility.Print(fullArray.Cast<int>(), start, end);
                }
            }
        }


        /// <summary>
        /// MaximumOfAllSubarraysOfSizeK, TC: O(n*k), SC: O(1)
        /// </summary>
        public static void MaximumOfAllSubarraysOfSizeK()
        {
            var array = new int[] { 8, 5, 10, 7, 9, 4, 15, 12, 90, 13 };
            int k = 4;

            // Iterate till length - subarraysize + 1
            // because you wont be able to iterate in the subarray afterwards later
            // because of out of bounds index
            for (int i = 0; i < array.Length - k + 1; i++)
            {
                var max = array[i];

                for (int j = i; j < k+i; j++)
                {
                    if (array[j] > max)
                        max = array[j];
                }

                Console.Write(max + "  ");
            }
        }


        public static void TrickOrTreat(int[] boxes, int children)
        {
            var candyBoxes = boxes.ToList<int>();// new List<int>() { 5, 5, 3, 1, 5, 2 };

            IncrementalSum(candyBoxes, new List<int>(), children);

            Console.WriteLine("NO");

            void IncrementalSum(List<int> remainingBoxes, List<int> selectedBoxes, int child)
            {
                int sum = 0;
                foreach (var item in selectedBoxes)
                {
                    sum += item;
                }

                if (sum == child)
                {
                    Console.WriteLine("YES");
                    Console.ReadKey();
                    Environment.Exit(0);
                }
                else if (sum > child)
                {
                    return;
                }

                for (int b = 0; b < remainingBoxes.Count; b++)
                {
                    var select = new List<int>(selectedBoxes);
                    int firstBox = remainingBoxes[b];
                    select.Add(firstBox);

                    var restRemainingBoxes = new List<int>();
                    for (int c = b + 1; c < remainingBoxes.Count; c++)
                    {
                        restRemainingBoxes.Add(remainingBoxes[c]);
                    }

                    IncrementalSum(restRemainingBoxes, select, child);
                }

            }
        }

        /// <summary>
        /// MaximumSumIncreasingSubsequence, TC: O(n), SC: O(1)
        /// </summary>
        public static void MaximumSumIncreasingSubsequence()
        {
            var array = new int[] { 1, 101, 2, 3, 100, 4, 5 };
            int maxSum, sum;
            int compareElement = maxSum = sum = array[0];

            for (int i = 1; i < array.Length; i++)
            {
                if (array[i] >= compareElement)
                {
                    compareElement = array[i];
                    sum += array[i];

                    if (sum > maxSum)
                        maxSum = sum;
                }
                else
                {
                    compareElement = sum = array[i];
                }
            }

            Console.WriteLine(maxSum);
        }


        /// <summary>
        /// SortArrayOf012, TC: O(n), SC: O(1)
        /// </summary>
        public static void SortArrayOf012()
        {
            // TC: O(n), SC:O(m) m is no of diff. integers. Generally a fixed no
            var array = new int[] { 0, 2, 1, 2, 0 };
            var counter = new int[3];
            var index =0;

            for (int i = 0; i < array.Length; i++)
            {
                counter[array[i]]++;
            }

            for (int i = 0; i < array.Length; i++)
            {
                if (counter[index] > 0)
                {
                    array[i] = index;
                    --counter[index];
                }
                else
                {
                    index++;
                    array[i] = index;
                }
            }

            Utility.PrintPlainElements<int>(array.Cast<int>());
        }

        public static void ConvertIntegerToRomanNumerals()
        {
            // TC: log(n), SC: O(1)
            var number = 100;
            var roman = new StringBuilder();

            var values = new Dictionary<int, string>();
            values.Add(1, "I");
            values.Add(5, "V");
            values.Add(10, "X");
            values.Add(50, "L");
            values.Add(100, "C");
            values.Add(500, "D");
            values.Add(1000, "M");

            int quotient, modFinder = 1000;

            if (number > 3099 || number == 0)
                Console.WriteLine("Cannot convert");

            // iterate as per ones, tens, thousands. Hence Log(n)
            while (modFinder > 0)
            {
                quotient = number / modFinder;

                // if number is smaller which will not get you
                // a roman equivalent, then continue the loop
                if (quotient == 0)
                {
                    // reduce the divider by 10
                    modFinder /= 10;
                    continue;
                }

                // get roman parts
                GetRomanParts(modFinder, quotient, ref roman);

                // reduce no to get further equivalents in next iteration
                number %= modFinder;

                // reduce divider till it reaches 1.
                modFinder /= 10;
            }

            Console.WriteLine(roman);

            void GetRomanParts(int divider, int quo, ref StringBuilder sb)
            {
                // if quo is 5, get it's equivalent as per divider
                // 5 = V, 50 = L etc.
                if (quo == 5)
                    sb.Append(values[divider * quo]);

                // if quo is in 4,9 then get a shifted equivalent
                // 4 = IV, 9 = IX, 49 = XLIX etc.
                else if (new[] { 4, 9 }.Contains(quo))
                    sb.Append(values[divider]).Append(values[divider * (quo + 1)]);

                // if quo is 1 to 3, then simple repitition.
                else if (quo < 4)
                {
                    for (int i = 0; i < quo; i++)
                    {
                        sb.Append(values[divider]);
                    }
                }

                // last case quo is in 6 to 8, add 5th equivalent
                // and append divider normally. 6 = VI, 26 = XXVI
                else
                {
                    sb.Append(values[divider * 5]);
                    for (int i = 0; i < quo - 5; i++)
                    {
                        sb.Append(values[divider]);
                    }
                }
            }
        }

        public static void SubarrayWithGivenSum()
        {
            // TC: O(n), SC: O(1)
            var array = new int[] { 8,8,1,4,2,4,14,14,1 };
            var length = array.Length;
            int findSum =11, start = 0, end = 0, summer = 0;

            // Set the summer at first element of the array.
            // to find the sum
            int i = 0;
            summer = array[0];

            // iterate till start and end reach the
            // end of the array.
            while (start < length && end < length)
            {
                // if element is bigger than findSum
                // then we move start and end ahead by 1 index.
                // We want to skip the element altogether.
                if (array[i] > findSum)
                {
                    start = end = i + 1;
                    continue;
                }

                // if summer < findSum, then move End by 1 index.
                if (summer < findSum)
                {
                    end = i + 1;
                    summer += array[end];

                    // if we are about to reach the second last
                    // element then allow index till last element.
                    if (i < length - 1)
                        i++;

                }
                // if summer > findSum then remove the first
                // element from the summer and move start by
                // 1 index.
                else if (summer > findSum)
                {
                    summer -= array[start];
                    start += 1;
                }

                // the moment we find the summer = findSum, break away.
                if (summer == findSum)
                    break;
            }

            Console.WriteLine($"start at {start+1} and end at {end+1}");
        }

        public static void MissingNumberInArray()
        {
            // Use concept of AP to find the missing number.
            // TC: O(n), SC: O(1)
            var array = new int[] { 1,2,3,5 ,4,6,7,8,10 };

            var length = array.Length;
            int expectedSum = (length + 2) * (length + 1) / 2;
            int actualSum = 0;

            for (int i = 0; i < length; i++)
            {
                actualSum += array[i];
            }

            Console.WriteLine(expectedSum - actualSum);
        }

        /// <summary>
        /// Kadane Algoritm TC: O(n), SC: O(1)
        /// Contiguous sub array with max sum.
        /// </summary>
        public static void KadaneAlgorithm()
        {
            var array = new int[] { -2, -3, 4, -1, -2, 1, 5, -3 };
            int actualMax=0, segmentMax = 0;

            for (int i = 0; i < array.Length; i++)
            {
                segmentMax = segmentMax + array[i];

                if (segmentMax < 0)
                    segmentMax = 0;
                else if (segmentMax > actualMax)
                    actualMax = segmentMax;
            }

            Console.WriteLine(actualMax);
        }

        public static void FindElementAtGivenIndexAfterNoOfRotations()
        {
            var array = new int[] { 1,2,3,4,5};
            var ranges = new int[,] { { 0, 2 }, { 0, 3 } };
            var index = 1;

            for (int i = ranges.Length/2 - 1; i >= 0; i--)
            {
                if (index.Between(ranges[i,0], ranges[i,1]))
                {
                    if (index == ranges[i, 0])
                        index = ranges[i, 1];
                    else
                        index--;
                }
            }

            Console.WriteLine($"{array[index]}");
        }

        public static void FindMinimumElementInSortedAndRotatedArray()
        {
            // array is sorted in increasing order but rotated
            var array = new int[] {5,4,1,2,3};

            var smallest = findSmallestNumber(array, 0, array.Length - 1);

            Console.WriteLine(smallest);

            int findSmallestNumber(int[] fullArray, int start, int end)
            {
                // if the array is unsorted
                if (fullArray[start] < fullArray[end])
                    return fullArray[start];

                int mid = start + (end - start) / 2;

                // if only 1 element is there
                if (start == end)
                    return fullArray[start];

                // if it's the mid element
                if (mid < end && fullArray[mid] > fullArray[mid+1])
                    return fullArray[mid + 1];

                // if it's the mid element
                if (mid > start && fullArray[mid-1] > fullArray[mid])
                    return fullArray[mid];

                // if mid is greater than end element, this means
                // we have our find probably inside the right half
                // else left half
                if (fullArray[mid]> fullArray[end])
                {
                    return findSmallestNumber(fullArray, mid + 1, end);
                }

                return findSmallestNumber(fullArray, start, mid - 1);
            }
        }

        public static void FindMaxHammingDistance()
        {
            // TC: O(n*n), SC: O(n)
            var array = new int[] { 2,4,8,0 };
            int currentRotation = 0, maxRotation = 0, rotationId = -1;

            var stockArray = new int[array.Length];
            for (int i = 0; i < array.Length; i++)
            {
                stockArray[i] = array[i];
            }

            for (int i = 0; i < array.Length; i++)
            {
                // Rotate left by one unit
                Utility.Reverse(ref array, 0, 1);
                Utility.Reverse(ref array, 2, array.Length -1);
                Utility.Reverse(ref array);

                // reset rotation count to check for this iteration's mishits
                currentRotation = 0;

                // calculate no of mis hits
                for (int j = 0; j < array.Length; j++)
                {
                    if (array[j] != stockArray[j])
                        ++currentRotation;
                }

                // set maxRotation mishits and the rotation number
                if (currentRotation > maxRotation)
                {
                    maxRotation = currentRotation;
                    rotationId = i + 1;
                }
            }

            Console.WriteLine($"Max Hamming Distance: {maxRotation} with rotation of {rotationId} units.");

        }

        public static void RotationCountInClockwiseRotatedSortedArray()
        {
            var array = new int[] { 7, 9, 11, 12, 5 };
            var index = 0;
            for (int i = 0; i < array.Length; i++)
            {
                if (i < array.Length-1 && array[i] > array[i + 1])
                {
                    index = i + 1;
                    break;
                }
            }

            Console.WriteLine(index);

        }

        public static void Find_Maximum_Value_Of_Sum_Of_Index_And_Element_With_Only_Rotations_Allowed()
        {
            // TC: O(n), SC: O(1)
            var array = new int[] { 10, 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            int arraySum=0, previousSum=0, max=0, difference =0, length=array.Length;

            /**
             * make pattern for how each iteration will come up in
             * maths. and then generalise the equation to arrive at the solution.
             * Rj - Rj-1 = arrSum - n * arr[n-j]
             */
            for (int i = 0; i < length; i++)
            {
                // calculate array sum and multiplied array sum.
                arraySum += array[i];
                previousSum += i * array[i];
            }

            for (int i = 1; i < length; i++)
            {
                // Rotation(n) - Rotation(n-1)
                difference = arraySum - length * array[length - i];

                if (difference > 0)
                {
                    // set max as previous rotation muxed sum + difference that we obtained
                    max = previousSum + difference;
                    // set this rotation muxed sum as previous sum for the next iteration now.
                    previousSum = max;
                }
                else
                {
                    // else set previoussum for next iteration as previous sum + difference.
                    previousSum = previousSum + difference;
                }
            }

            Console.WriteLine(max);

        }

        public static void Find_Pairs_With_Given_Sum_In_Sorted_And_Rotated_Array()
        {
            // sorted but rotated array
            var array = new int[] { 4, 5, 0, 1, 2, 3 };
            int sumToFind = 4, pivot = -1, male, female;
            var flag = false;

            // finding *actual* pivot now.
            for (int i = 0; i < array.Length; i++)
            {
                if (i < array.Length - 1 && array[i] > array[i + 1])
                {
                    pivot = i; break;
                }
            }

            #region Method1
            /**
             * Comment Method2 region entirely to run this.
             * This method utilises the Binary Search concept
             * to search for the Female part in the array
             * to sum up to get FIND variable.
             * Not so TIDY method.
             *
             * TC = nLog(n)
             */

            // searching the part-arrays if one element is
            // in first part and other one in the other part.
            for (int i = pivot + 1, j = 0;
                i < array.Length || j <= pivot;
                i++, j++)
            {
                male   = array[i];
                female = sumToFind - male;

                // assuming we have the elements of the pair
                // in different parts of the array as divided by the pivot.
                // Assuming, male is in RIGHT and we search female in the LEFT
                var index = Utility.BinarySearch(array, female, 0, pivot);
                if (index != -1)
                {
                    // We found at least one pair that sums up!
                    flag = true;
                    female = array[index];
                    Console.WriteLine($"{male},{female}");
                }

                // search in the same part of the array - The RIGHT PART
                // MALE and FEMALE are both in RIGHT
                index = -1;
                index = Utility.BinarySearch(array, female, i + 1, array.Length - 1);
                if (index != -1)
                {
                    female = array[index];
                    Console.WriteLine($"{male},{female}");
                }

                //search in the same part of the array - THE LEFT PART
                // MALE and FEMALE are both in LEFT
                male   = array[j];
                female = sumToFind - male;
                index  = -1;
                index  = Utility.BinarySearch(array, female, j + 1, pivot);
                if (index != -1)
                {
                    female = array[index];
                    Console.WriteLine($"{male},{female}");
                }

            }
            #endregion

            #region Method2
            /**
             * Comment Method1 region entirely to run this.
             * More efficient method for this search.
             * Also, in a rotated array we traverse the array
             * using indexes formatted by MODULAR ARITHMETIC.
             *
             * TC = O(n)
             */

            int start = pivot+1, end=pivot;

            while (start != end)
            {
                male   = array[start];
                female = array[end];

                if (male + female == sumToFind)
                {
                    flag = true;
                    Console.WriteLine($"{male},{female}");

                    // Now increase the start point by one index
                    // and reset the end to PIVOT and recheck for
                    // more pairs.
                    // IF YOU'D HAVE WANTED ONLY ONE PAIR, THEN PUT
                    // A return statment.
                    start = (start + 1) % array.Length;
                    end = pivot;
                }
                else if (male + female < sumToFind)
                    start = (start + 1) % array.Length;
                else
                    end = (array.Length + end - 1) % array.Length;
            }
            #endregion

            if (!flag)
                Console.WriteLine($"No pair(s) found that sums up to {sumToFind}");
        }

        public static void ArrayRotation()
        {
            var array1 = new int[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            int stepper = 5;

            #region LeftRotation
            // TC O(n), SC O(step)
            //UsingTempArray(array1, stepper);

            // TC O(n^2), SC O(1)
            //UsingJugglingMethod(array1, stepper);

            // Best method so far!
            // TC O(n), SC O(1)
            //UsingReversalAlgorithm(array1, stepper);

            UsingBlockSwapAlgorithm(array1, stepper);
            #endregion

            #region RightRotation
            // TC O(n), SC O(1)
            CyclicallyRotateArrayOneByOne(array1, stepper);
            #endregion

            #region Methods
            void UsingTempArray(int[] array, int step)
            {
                var arrayToMove = new int[step];
                var j = 0;

                for (int i = 0; i < array.Length; i++)
                {
                    if (i < arrayToMove.Length)
                        arrayToMove[i] = array[i];

                    if (i < array.Length - step)
                        array[i] = array[i + step];
                    else
                        array[i] = arrayToMove[j++];

                    Console.Write($"{array[i]}\t");
                }
            }


            void UsingJugglingMethod(int[] array, int step)
            {

                //var array = new int[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                //int newStep = 3;
                var temp = 0;

                var iterationCount = Utility.GetGcd(array.Length, step);
                int j, k = 0;

                for (int i = 0; i < iterationCount; i++)
                {
                    temp = array[i];
                    j = i;
                    while (true)
                    {
                        k = j + step;
                        if (k >= array.Length)
                            k = k - array.Length;

                        if (k == i)
                            break;

                        array[j] = array[k];
                        j = k;
                    }

                    array[j] = temp;
                }

                Utility.PrintPlainElements<int>(array.Cast<int>());
            }


            void UsingReversalAlgorithm(int[] array, int step)
            {
                //var array = new int[12] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
                //int newStep = 3;

                Utility.Reverse<int>(ref array, 0, step - 1);
                Utility.Reverse<int>(ref array, step, array.Length - 1);
                Utility.Reverse<int>(ref array);

                Utility.PrintPlainElements<int>(array.Cast<int>());
            }


            void CyclicallyRotateArrayOneByOne(int[] array, int step)
            {
                Utility.Reverse<int>(ref array);
                Utility.Reverse<int>(ref array, 0, step - 1);
                Utility.Reverse<int>(ref array, step, array.Length - 1);

                Utility.PrintPlainElements<int>(array.Cast<int>());
            }
            #endregion

            void UsingBlockSwapAlgorithm(int[] array, int step)
            {
                //var array = new int[7] { 1, 2, 3, 4, 5, 6, 7 };
                //var step = 2;

                //Utility.SplitArrayInTwoParts<int>(array, step, out int[] first, out int[] second);

                //var A = new int[step];
                //var B = new int[array.Length - step];

                //while (A.Length != B.Length)
                //{
                //    if (A.Length < B.Length)
                //    {
                //        Utility.SplitArrayInTwoPartsPreInitialised(B, A.Length, ref  )
                //    }
                //}

                var leftCounter = step;
                var rightCounter = array.Length - step;

                if (leftCounter == rightCounter)
                {
                    Utility.SwapSomeArrayParts<int>(ref array, 0, rightCounter, step);
                }
                else
                {
                    if (leftCounter < rightCounter)
                    {
                        Utility.SwapSomeArrayParts<int>(ref array, 0, array.Length - leftCounter, step);
                    }
                    else
                        Utility.SwapSomeArrayParts<int>(ref array, 0, rightCounter, step);
                }

                //while (leftCounter != rightCounter)
                //{
                //    if (leftCounter < rightCounter)
                //    {
                //        // 1234567  >>>  3456712

                //        // 12 345-67  >  21 345-67  >  21 345-76  >  67 543-12
                //        // 2 3    76 543-12  > 76 543 21
                //        Utility.ReverseCertainElements<int>(ref array, 0, leftCounter - 1);
                //        Utility.ReverseCertainElements<int>(ref array, rightCounter, rightCounter + leftCounter - 1);
                //        Utility.Reverse<int>(ref array);

                //        leftCounter = step; // unnecessary
                //        rightCounter = array.Length - step - leftCounter;
                //    }
                //    else if (leftCounter > rightCounter)
                //    {
                //        // 1234567   >>>   6754312
                //        // 12-345 67  >  12-345 76  >  21-345 76  >  67 543-12
                //        Utility.ReverseCertainElements<int>(ref array, 0, leftCounter - 1);
                //        Utility.ReverseCertainElements<int>(ref array, rightCounter, array.Length - 1);
                //        Utility.Reverse<int>(ref array);

                //        leftCounter = step; // unnecessary
                //        rightCounter = array.Length - step;
                //    }
                //    else
                //        break;
                //}


                // 67 345  67 3-45   45 3    6712     453   45 3   4 5   5 4 3 6 7 1 2
                while (leftCounter != rightCounter)
                {
                    if (leftCounter < rightCounter)
                    {
                        Utility.SwapSomeArrayParts<int>(ref array, 0, array.Length - leftCounter, step);
                    }
                    else
                        Utility.SwapSomeArrayParts<int>(ref array, 0, array.Length, step);
                }

                //Utility.PrintPlainElements<int>(B.Cast<int>());

            }


        }

        // TC: O(n + Log(n)) = O(n),  SC: O(1)
        public static void SearchElementInSortedAndRotatedArray()
        {
            var array = new int[12] { 5, 6, 7, 8, 9, 10, 11, 12, 1, 2, 3, 4 };
            int find = 9, index = -1, pivot = -1;

            // find new pivot
            for (int i = 0; i < array.Length; i++)
            {
                if (i < array.Length - 1 && array[i] > array[i + 1])
                {
                    pivot = i; break;
                }
            }

            if (pivot == -1)
                // This means the array is a normal sorted array
                // in increasing order and is NOT ROTATED.
                Utility.BinarySearch(array, find, 0, array.Length - 1);
            else
            {
                // If it's a rotated array, then divide the array
                // as per the new pivot now and ensure your *find*
                // variable is inside the either of the halves of
                // the rotated array.
                if (find.Between(array[0], array[pivot]))
                    index = Utility.BinarySearch(array, find, 0, pivot);
                else
                    index = Utility.BinarySearch(array, find, pivot + 1, array.Length - 1);
            }

            if (index == -1)
                Console.WriteLine($"{find} Not found");
            else
                Console.WriteLine($"{find} found at index: {index + 1}");
        }

        /// <summary>
        /// https://algorithmsandme.com/find-element-sorted-matrix/
        /// </summary>
        public static void SearchANoInNxMSortedMatrix()
        {
            const int Rows = 3, Columns = 4, find = 45;
            int[,] array = new int[Rows, Columns]
            {
                { 10, 20, 30, 40 },
                { 15, 25, 35, 45 },
                { 27, 29, 37, 48 }
            };

            int i = 0, j = Columns - 1;

            while (i < Rows && j >= 0)
            {
                if (array[i, j] == find)
                    break;

                else if (array[i, j] < find)
                    ++i;

                else
                    --j;
            }

            if (j == -1 || i >= Rows)
                Console.WriteLine("Element {0} not found.", find);
            else
                Console.WriteLine("Position of {0} is ({1},{2})", find, i + 1, j + 1);

            Console.ReadLine();
        }

        /// <summary>
        /// TC: O(n^2), SC: O(1)
        /// https://www.geeksforgeeks.org/rotate-a-matrix-by-90-degree-in-clockwise-direction-without-using-any-extra-space/
        ///
        /// </summary>
        public static void RotateImageBy90Degrees()
        {
            #region 2darray
            // This is using a 2D array.
            int[,] array = new int[,]
            {
                {1,2,3,4},
                {5,6,7,8},
                {9,10,11,12},
                {13,14,15,16 }
            };
            int dimension = (int)Math.Sqrt(array.Length);
            int swap = -1;
            Console.WriteLine("Using 2D array: \n");

            Console.WriteLine("Input: \n");
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine(Environment.NewLine);
            }

            // Transpose
            for (int i = dimension - 1; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    swap = array[i, j];
                    array[i, j] = array[j, i];
                    array[j, i] = swap;
                }
            }

            // Now mirror along diagonal
            for (int i = 0; i < dimension; i++)
            {
                swap = -1;
                for (int j = 0; j < dimension / 2; j++)
                {
                    swap = array[i, j];
                    array[i, j] = array[i, dimension - 1 - j];
                    array[i, dimension - 1 - j] = swap;
                }
            }

            Console.WriteLine("\nOutput:\n");
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(array[i, j] + "\t");
                }
                Console.WriteLine(Environment.NewLine);
            }
            #endregion
            #region arrayOfarray

            int[][] arr = new int[3][];
            arr[0] = new int[] { 1, 2, 3 };
            arr[1] = new int[] { 4, 5, 6 };
            arr[2] = new int[] { 7, 8, 9 };


            dimension = arr.Length;
            swap = -1;

            Console.WriteLine("Using array of arrays: \n");

            for (int i = dimension - 1; i >= 0; i--)
            {
                for (int j = i; j >= 0; j--)
                {
                    swap = arr[i][j];
                    arr[i][j] = arr[j][i];
                    arr[j][i] = swap;
                }
            }

            for (int i = 0; i < dimension; i++)
            {
                swap = -1;
                for (int j = 0; j < dimension / 2; j++)
                {
                    swap = arr[i][j];
                    arr[i][j] = arr[i][dimension - 1 - j];
                    arr[i][dimension - 1 - j] = swap;
                }
            }

            Console.WriteLine("\nOutput:\n");
            for (int i = 0; i < dimension; i++)
            {
                for (int j = 0; j < dimension; j++)
                {
                    Console.Write(arr[i][j] + "\t");
                }
                Console.WriteLine(Environment.NewLine);
            }
            #endregion
        }


        /// <summary>
        /// TC: O(n), SC: O(1)
        /// https://www.geeksforgeeks.org/find-first-repeating-element-array-integers/
        /// </summary>
        /// <param name="array"></param>
        /// <returns></returns>
        public static int FindFirstDuplicate(int[] array)
        {
            /*

            Array Question 1 | Codefights Interview Practice

            Code for main()


            int[] array = new int[] { 2, 3, 2, 1, 5, 1 };
            int answer = Questions.FindFirstDuplicate(array);
            Console.WriteLine(answer<0? "No duplicates." : "First Duplicate: "+answer);
            Console.ReadLine();
            */
            int position = -1;

            for (int i = 0; i < array.Length; i++)
            {
                position = Math.Abs(array[i]) - 1;

                if (array[position] > 0 && i == array.Length - 1)
                    return -1;

                else if (array[position] > 0)
                    array[position] = -array[position];

                else
                    return Math.Abs(array[i]);
            }
            return -1;
        }

        public static char FirstNotRepeatingCharacter(string s)
        {
            /*
             * Array Question 2 | Codefights Interview Practice
             *
             * Code for main
             * Questions.FirstNotRepeatingCharacter("abacabad");
             * */
            int repitition = 0;
            for (int i = 0; i < s.Length; i++)
            {
                repitition = 0;
                for (int j = 0; j < s.Length; j++)
                {
                    if (i != j && s[i] == s[j])
                    {
                        ++repitition;
                        break;
                    }
                }

                if (repitition == 0)
                    return s[i];
            }

            return '_';
        }
        #endregion
    }
}
