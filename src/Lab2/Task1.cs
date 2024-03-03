namespace Lab2;

internal static class Task1
{
    public static void Run()
    {
        var nums = InputAndGenerateNums();
        if (nums == null) return;

        Console.WriteLine("Generated nums:");
        nums.Print();

        ShellSort(nums);

        Console.WriteLine("Sorted nums with Shell algorithm:");
        nums.Print();
    }

    /// <summary>
    /// Input count, min and max from Console.
    /// Then generates nums.
    /// </summary>
    public static int[]? InputAndGenerateNums()
    {
        Console.WriteLine("Enter count of numbers (>0): ");
        if (int.TryParse(Console.ReadLine(), out int count) is false || count < 1)
        {
            Console.WriteLine("Count must be a positive integer");
            return null;
        }

        Console.WriteLine("Enter min: ");
        if (int.TryParse(Console.ReadLine(), out int min) is false)
        {
            Console.WriteLine("Min must be an integer");
            return null;
        }

        Console.WriteLine("Enter max: ");
        if (int.TryParse(Console.ReadLine(), out int max) is false)
        {
            Console.WriteLine("Max must be an integer");
            return null;
        }

        return GenerateNums(count, min, max);
    }

    private static int[] GenerateNums(int count, int min, int max)
    {
        if (max < min)
        {
            (max, min) = (min, max);
        }

        var rnd = new Random();
        int[] nums = new int[count];
        for (int i = 0; i < count; i++)
        {
            nums[i] = rnd.Next(min, max);
        }
        return nums;
    }

    private static void ShellSort(int[] array)
    {
        int size = array.Length;
        int gap = size / 2;

        while (gap > 0)
        {
            for (int i = gap; i < size; i++)
            {
                int temp = array[i];
                int j = i;

                while (j >= gap && array[j - gap] > temp)
                {
                    array[j] = array[j - gap];
                    j -= gap;
                }

                array[j] = temp;
            }

            gap /= 2;
        }
    }
}