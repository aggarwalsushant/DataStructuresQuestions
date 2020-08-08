using System;

namespace Questions.QuestionFiles.Arrays
{
    public partial class ArrayQuestions
    {
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
                    sum = array[m, k] + array[m, k + 1] + array[m, k + 2]
                            + array[m + 1, k + 1]
                        + array[m + 2, k] + array[m + 2, k + 1] + array[m + 2, k + 2];

                    if (sum > maxSum)
                        maxSum = sum;
                }
            }

            Console.WriteLine(maxSum);
        }
    }
}
