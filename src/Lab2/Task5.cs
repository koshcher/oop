namespace Lab2;

public static class Task5
{
    public static void Run()
    {
        var nums = Task1.InputAndGenerateNums();
        if (nums == null) return;

        Console.WriteLine("Enter k: ");
        if (int.TryParse(Console.ReadLine(), out int k) is false)
        {
            Console.WriteLine("K must be an integer");
            return;
        }

        var centered = Task4.FindCenteredNumbers(nums, k);
        Console.WriteLine("Centered numbers:");
        foreach (var centeredItem in centered)
        {
            Console.WriteLine($"Value: {centeredItem.Value}, Index: {centeredItem.Index}");
        }

        Console.WriteLine("Enter element to search in centered numbers:");
        if (int.TryParse(Console.ReadLine(), out int search) is false)
        {
            Console.WriteLine("Search must be an integer");
            return;
        }

        var indexes = IndexesOf(centered.Select(x => x.Value), search);
        Console.WriteLine("Found at:");
        foreach (var index in indexes) Console.Write(index);
        Console.WriteLine();
    }

    public static List<int> IndexesOf(IEnumerable<int> nums, int value)
    {
        List<int> indexes = [];

        var sorted = nums.ToArray();
        Array.Sort(sorted);

        var index = Array.BinarySearch(sorted, value);
        if (index < 0) return [];
        indexes.Add(index);

        for (int i = index - 1; i >= 0; i--)
        {
            if (indexes[i] != value) break;
            indexes.Add(i);
        }

        for (int i = index + 1; i < sorted.Length; i++)
        {
            if (indexes[i] != value) break;
            indexes.Add(i);
        }

        return indexes;
    }
}