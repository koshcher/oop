namespace Lab2;

public static class Task4
{
    public static void Run()
    {
        var nums = Task1.InputAndGenerateNums();
        if (nums == null) return;

        Console.WriteLine("Generated nums:");
        nums.Print();

        Console.WriteLine("Enter k: ");
        if (int.TryParse(Console.ReadLine(), out int k) is false)
        {
            Console.WriteLine("K must be an integer");
            return;
        }

        var centered = FindCenteredNumbers(nums, k);
        Console.WriteLine("Centered numbers:");
        foreach (var centeredItem in centered)
        {
            Console.WriteLine($"Value: {centeredItem.Value}, Index: {centeredItem.Index}");
        }
    }

    public record Element(int Value, int Index);

    public static List<Element> FindCenteredNumbers(int[] array, int k)
    {
        var list = new List<Element>();
        for (int i = 0; i < array.Length; i++)
        {
            var num = array[i];
            if (IsCenteredNumber(num, k))
            {
                list.Add(new Element(num, k));
            }
        }
        return list;
    }

    private static bool IsCenteredNumber(int number, int k)
    {
        int n = 0;
        int centeredNumber = 0;

        while (centeredNumber <= number)
        {
            centeredNumber = (k * n * n - k * n + 2) / 2;

            if (centeredNumber == number)
            {
                return true;
            }

            n++;
        }

        return false;
    }
}