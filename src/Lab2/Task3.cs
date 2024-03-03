namespace Lab2;

public static class Task3
{
    public static void Run()
    {
        var nums = Task1.InputAndGenerateNums();
        if (nums == null) return;

        Console.WriteLine("Generated nums:");
        nums.Print();

        SwapFirstAndLast(nums);

        Console.WriteLine("After first and last are swapped:");
        nums.Print(0, nums.Length - 1);

        var minMax = SwapMinAndMax(nums);
        if (minMax != null)
        {
            Console.WriteLine("After min and max are swapped:");
            nums.Print(minMax.Min, minMax.Max);
        }
    }

    private static void SwapFirstAndLast(int[] nums)
    {
        SwapNums(nums, 0, nums.Length - 1);
    }

    private record MinMax(int Min, int Max);

    private static MinMax? SwapMinAndMax(int[] nums)
    {
        if (nums == null || nums.Length < 2) return null;

        int minIndex = 0;
        int min = nums[minIndex];

        int maxIndex = 0;
        int max = nums[maxIndex];

        for (int i = 1; i < nums.Length; i += 1)
        {
            var num = nums[i];
            if (num < min)
            {
                minIndex = i;
                min = num;
            }
            else if (num > max)
            {
                maxIndex = i;
                max = num;
            }
        }

        SwapNums(nums, minIndex, maxIndex);
        return new(minIndex, maxIndex);
    }

    private static void SwapNums(int[] nums, int index1, int index2)
    {
        if (nums == null || nums.Length < 2) return;
        (nums[index2], nums[index1]) = (nums[index1], nums[index2]);
    }
}