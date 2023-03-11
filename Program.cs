namespace FindIfArrayContainsSum
{
    public class Program
    {
        public static void Main(String[] args)
        {
            int[] sortedArrayWithoutSum = { 1, 2, 2, 4, 5 };
            int[] sortedArrayWithSum = { 1, 2, 3, 5, 5 };
            int[] sortedArrayWithSumDuplicates = { 1, 2, 3, 4, 4 };

            int[] unsortedArrayWithoutSum = { 4, 2, 1, 2, 5 };
            int[] unsortedArrayWithSum = { 5, 3, 2, 1, 5 };
            int[] unsortedArrayWithSumDuplicates = { 4, 2, 3, 4, 1 };

            int target = 8;

            PrintTitle("Sorted Array - Boolean Contains");

            Console.WriteLine(SortedArrayContainsSum(sortedArrayWithoutSum, target));
            Console.WriteLine(SortedArrayContainsSum(sortedArrayWithSum, target));
            Console.WriteLine(SortedArrayContainsSum(sortedArrayWithSumDuplicates, target));

            PrintTitle("Unsorted Array - Boolean Contains");


            Console.WriteLine(UnsortedArrayContainsSum(unsortedArrayWithoutSum, target));
            Console.WriteLine(UnsortedArrayContainsSum(unsortedArrayWithSum, target));
            Console.WriteLine(UnsortedArrayContainsSum(unsortedArrayWithSumDuplicates, target));

            PrintTitle("Sorted Array - Indices");


            OutputIntArray(SortedArrayContainsSumReturnIndices(sortedArrayWithoutSum, target));
            OutputIntArray(SortedArrayContainsSumReturnIndices(sortedArrayWithSum, target));
            OutputIntArray(SortedArrayContainsSumReturnIndices(sortedArrayWithSumDuplicates, target));

            PrintTitle("Unsorted Array - Indices");

            OutputIntArray(UnsortedArrayContainsSumIndices(unsortedArrayWithoutSum, target));
            OutputIntArray(UnsortedArrayContainsSumIndices(unsortedArrayWithSum, target));
            OutputIntArray(UnsortedArrayContainsSumIndices(unsortedArrayWithSumDuplicates, target));

            PrintTitle("Sorted Array - Values");


            OutputIntArray(SortedArrayContainsSumReturnValues(sortedArrayWithoutSum, target));
            OutputIntArray(SortedArrayContainsSumReturnValues(sortedArrayWithSum, target));
            OutputIntArray(SortedArrayContainsSumReturnValues(sortedArrayWithSumDuplicates, target));

            PrintTitle("Unsorted Array - Values");

            OutputIntArray(UnsortedArrayContainsSumValues(unsortedArrayWithoutSum, target));
            OutputIntArray(UnsortedArrayContainsSumValues(unsortedArrayWithSum, target));
            OutputIntArray(UnsortedArrayContainsSumValues(unsortedArrayWithSumDuplicates, target));
        }

        public static void PrintTitle(string title)
        {
            string banner = new('#', title.Length);
            Console.WriteLine(banner);
            Console.WriteLine(title);
            Console.WriteLine(banner);

        }

        public static Boolean SortedArrayContainsSum(int[] array, int targetSum)
        {

            if (array.Length < 2)
            {
                return false;
            }

            int min = 0;
            int max = array.Length - 1;
            int sum;

            while (min < max)
            {
                sum = array[min] + array[max];

                if (sum == targetSum)
                {
                    return true;
                }

                if (sum > targetSum)
                {
                    max -= 1;
                }
                else
                {
                    min += 1;
                }

            }

            return false;
        }

        public static Boolean UnsortedArrayContainsSum(int[] array, int targetSum)
        {

            if (array.Length < 2)
            {
                return false;
            }

            HashSet<int> additiveCompliments = new();
            int additiveCompliment;

            foreach (int item in array)
            {
                if (additiveCompliments.Contains(item))
                {
                    return true;
                }

                additiveCompliment = targetSum - item;

                additiveCompliments.Add(additiveCompliment);

            }

            return false;
        }


        public static void OutputIntArray(int[] array)
        {
            Console.WriteLine(string.Join(", ", array));
        }

        public static int[] SortedArrayContainsSumReturnIndices(int[] array, int targetSum)
        {

            if (array.Length < 2)
            {
                return new int[0];
            }

            int min = 0;
            int max = array.Length - 1;
            int sum;
            int[] indices = new int[2];

            while (min < max)
            {
                sum = array[min] + array[max];

                if (sum == targetSum)
                {
                    indices[0] = min;
                    indices[1] = max;

                    return indices;
                }

                if (sum > targetSum)
                {
                    max -= 1;
                }
                else
                {
                    min += 1;
                }

            }

            return new int[0];
        }

        public static int[] UnsortedArrayContainsSumIndices(int[] array, int targetSum)
        {

            if (array.Length < 2)
            {
                return new int[0];
            }

            Dictionary<int, int> additiveCompliments = new(); // compliment, index of item
            int additiveCompliment;
            int item;

            for (int i = 0; i < array.Length; i++)
            {
                item = array[i];


                if (additiveCompliments.ContainsKey(item))
                {
                    int[] indices = new int[2];
                    indices[0] = additiveCompliments[item];
                    indices[1] = i;
                    return indices;
                }

                additiveCompliment = targetSum - item;
                if (!additiveCompliments.ContainsKey(additiveCompliment))
                {
                    additiveCompliments.Add(additiveCompliment, i);
                }

            }

            return new int[0];
        }

        public static int[] SortedArrayContainsSumReturnValues(int[] array, int targetSum)
        {

            if (array.Length < 2)
            {
                return new int[0];
            }

            int min = 0;
            int max = array.Length - 1;
            int sum;

            while (min < max)
            {
                sum = array[min] + array[max];

                if (sum == targetSum)
                {
                    int[] values = new int[2];

                    values[0] = array[min];
                    values[1] = array[max];

                    return values;
                }

                if (sum > targetSum)
                {
                    max -= 1;
                }
                else
                {
                    min += 1;
                }

            }

            return new int[0];
        }


        public static int[] UnsortedArrayContainsSumValues(int[] array, int targetSum)
        {

            if (array.Length < 2)
            {
                return new int[0];
            }

            Dictionary<int, int> additiveCompliments = new();
            int additiveCompliment;

            foreach (int item in array)
            {
                if (additiveCompliments.ContainsKey(item))
                {
                    int[] values = new int[2];
                    values[0] = item;
                    values[1] = additiveCompliments[item];

                    return values;
                }

                additiveCompliment = targetSum - item;

                if (!additiveCompliments.ContainsKey(additiveCompliment))
                {
                    additiveCompliments.Add(additiveCompliment, item);
                }


            }

            return new int[0];
        }

    }
}