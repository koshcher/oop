namespace Lab3;

public static class ResearchWork
{
    public static void PrintGeneratedArray()
    {
        var arr = GenerateArray(20);
        Console.WriteLine($"Array size: {arr.Length}");
        for (int i = 0; i < arr.Length; i++)
        {
            Console.Write($"{arr[i]} ");
        }
        Console.WriteLine();
    }

    public static void Projects()
    {
        Console.WriteLine("Enter the number of projects (rows): ");
        int projectsCount = ConsoleHelpers.ReadInt(x => x > 0, "Must be a positive integer");

        Console.WriteLine("Enter the number of months (columns): ");
        int monthsCount = ConsoleHelpers.ReadInt(x => x > 0, "Must be a positive integer");

        Console.WriteLine("Enter the starting value of the range: ");
        int minValue = ConsoleHelpers.ReadInt(x => x > 0, "Must be non positive integer");

        Console.WriteLine("Enter the end value of the range: ");
        int maxValue = ConsoleHelpers.ReadInt(x => x > 0, "Must be non positive integer");

        int[,] matrix = GenerateMatrix(projectsCount, monthsCount, minValue, maxValue);
        Console.WriteLine("Matrix of profits from projects:");

        DisplayMatrix(matrix);

        int[] projectProfits = CalculateProjectProfits(matrix);
        int totalCompanyIncome = CalculateTotalCompanyIncome(matrix);
        int maxProfitProjectIndex = FindMaxProfitProjectIndex(projectProfits);

        Console.WriteLine("Total profit from each project:");
        for (int i = 0; i < projectProfits.Length; i++)
        {
            Console.WriteLine($"Project {i + 1}: {projectProfits[i]}");
        }

        Console.WriteLine($"The company's total revenue for all months: {totalCompanyIncome}");
        Console.WriteLine($"Index of the project with the highest profit: {maxProfitProjectIndex + 1}");
    }

    public static void Strings()
    {
        Console.Write("Enter a string of characters: ");
        string inputString = Console.ReadLine() ?? "";

        int wordsStartingWithUppercaseCount = CountWordsStartingWithUppercase(inputString);

        Console.WriteLine($"Number of words starting with a capital letter: {wordsStartingWithUppercaseCount}");

        string resultText = GetLastLettersOfWords(inputString);
        Console.WriteLine($"Text composed of the last letters of all words: {resultText}");
    }

    private static int[] CalculateProjectProfits(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        int[] projectProfits = new int[rows];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                projectProfits[i] += matrix[i, j];
            }
        }

        return projectProfits;
    }

    private static int CalculateTotalCompanyIncome(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);
        int totalCompanyIncome = 0;

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                totalCompanyIncome += matrix[i, j];
            }
        }

        return totalCompanyIncome;
    }

    private static int CountWordsStartingWithUppercase(string input)
    {
        return input
            .Split(' ')
            .Count(word => !string.IsNullOrEmpty(word) && char.IsUpper(word[0]));
    }

    private static void DisplayMatrix(int[,] matrix)
    {
        int rows = matrix.GetLength(0);
        int columns = matrix.GetLength(1);

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                Console.Write($"{matrix[i, j],5}");
            }
            Console.WriteLine();
        }
    }

    private static int FindMaxProfitProjectIndex(int[] projectProfits)
    {
        int maxProfit = int.MinValue;
        int maxProfitIndex = -1;

        for (int i = 0; i < projectProfits.Length; i++)
        {
            if (projectProfits[i] > maxProfit)
            {
                maxProfit = projectProfits[i];
                maxProfitIndex = i;
            }
        }

        return maxProfitIndex;
    }

    private static int[] GenerateArray(int size)
    {
        Random random = new();
        int[] array = new int[size];
        for (int i = 0; i < size; i += 1)
        {
            array[i] = random.Next(1, 100);
        }
        return array;
    }

    private static int[,] GenerateMatrix(int rows, int columns, int minValue, int maxValue)
    {
        if (maxValue < minValue)
        {
            (minValue, maxValue) = (maxValue, minValue);
        }

        Random random = new();
        int[,] matrix = new int[rows, columns];

        for (int i = 0; i < rows; i++)
        {
            for (int j = 0; j < columns; j++)
            {
                matrix[i, j] = random.Next(minValue, maxValue + 1);
            }
        }

        return matrix;
    }

    private static string GetLastLettersOfWords(string input)
    {
        return string.Join("",
            input.Split(' ')
            .Where(word => !string.IsNullOrEmpty(word))
            .Select(word => word.Last())
        );
    }
}