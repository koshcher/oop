namespace Lab2;

public static class LabExtensions
{
    public static void Print(this int[] nums)
    {
        foreach (var num in nums) Console.Write($"{num} ");
        Console.WriteLine();
    }

    public static void Print(this int[] nums, params int[] highlightIndexes)
    {
        for (int i = 0; i < nums.Length; i++)
        {
            var num = nums[i];
            if (highlightIndexes.Contains(i))
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write($"{num} ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            else
            {
                Console.Write($"{num} ");
            }
        }
        Console.WriteLine();
    }
}