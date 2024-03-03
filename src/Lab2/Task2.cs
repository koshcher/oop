namespace Lab2;

internal static class Task2
{
    public static void Run()
    {
        Console.WriteLine("Enter top limit to search simple nums: ");
        if (int.TryParse(Console.ReadLine(), out int top) is false)
        {
            Console.WriteLine("Count must be an integer");
            return;
        }

        var nums = SundaramSieve(top);
        nums.Print();
    }

    private static int[] SundaramSieve(int limit)
    {
        int limitNew = (limit - 1) / 2;
        bool[] marked = new bool[limitNew + 1];

        for (int i = 0; i < limitNew + 1; i += 1)
        {
            marked[i] = false;
        }

        for (int i = 1; i <= limitNew; i += 1)
        {
            for (int j = i; (i + j + 2 * i * j) <= limitNew; j += 1)
            {
                marked[i + j + 2 * i * j] = true;
            }
        }

        List<int> primes = new();

        if (limit > 2)
        {
            primes.Add(2);
        }

        for (int i = 1; i <= limitNew; i += 1)
        {
            if (marked[i] == false)
            {
                primes.Add(2 * i + 1);
            }
        }

        return primes.ToArray();
    }
}