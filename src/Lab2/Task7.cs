namespace Lab2;

public static class Task7
{
    public static void Run()
    {
        Console.Write("Enter students count: ");
        if (int.TryParse(Console.ReadLine(), out int students) is false || students < 1)
        {
            Console.WriteLine("Students must be a positive integer");
            return;
        }

        Console.Write("Enter subjects count: ");
        if (int.TryParse(Console.ReadLine(), out int subjects) is false || subjects < 1)
        {
            Console.WriteLine("Subjects must be a positive integer");
            return;
        }

        var grades = Task6.GenerateGradesMatrix(students, subjects);

        Console.WriteLine("Grades");
        Task6.PrintGrades(grades);

        var lowestAvgSubject = SubjectWithLowestAvg(grades);
        Console.WriteLine($"Subject with lowest avg grade: {lowestAvgSubject}");
        if (lowestAvgSubject >= 0)
        {
            grades = RemoveColumn(grades, lowestAvgSubject);
        }

        Console.WriteLine("Grades after removing subject with lowest avg grade");
        Task6.PrintGrades(grades);

        SortColumnsByAvgDescending(grades);
        Console.WriteLine("Grades after sorting by avg grade for subject:");
        Task6.PrintGrades(grades);

        Console.Write("Enter value to search: ");
        if (int.TryParse(Console.ReadLine(), out int search) is false)
        {
            Console.WriteLine("Search must be ae integer");
            return;
        }

        SearchInMatrix(grades, search);
    }

    private static int SubjectWithLowestAvg(Task6.Matrix grades)
    {
        var minAvg = double.MaxValue;
        var minAvgSubject = -1;

        for (int j = 0; j < grades.Cols; j++)
        {
            double sum = 0;
            for (int i = 0; i < grades.Rows; i++)
            {
                sum += grades.Data[i, j];
            }
            var avg = sum / grades.Rows;
            if (avg < minAvg)
            {
                minAvg = avg;
                minAvgSubject = j;
            }
        }

        return minAvgSubject;
    }

    private static Task6.Matrix RemoveColumn(Task6.Matrix matrix, int columnIndex)
    {
        int[,] newData = new int[matrix.Rows, matrix.Cols - 1];

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0, newJ = 0; j < matrix.Cols; j++)
            {
                if (j != columnIndex)
                {
                    newData[i, newJ] = matrix.Data[i, j];
                    newJ++;
                }
            }
        }

        return new Task6.Matrix(newData, matrix.Rows, matrix.Cols - 1);
    }

    private static void SortColumnsByAvgDescending(Task6.Matrix grades)
    {
        var averages = new double[grades.Cols];
        for (int j = 0; j < grades.Cols; j++)
        {
            double sum = 0;
            for (int i = 0; i < grades.Rows; i++)
            {
                sum += grades.Data[i, j];
            }
            averages[j] = sum / grades.Rows;
        }

        var columnOrder = Enumerable
            .Range(0, grades.Cols)
            .OrderByDescending(index => averages[index])
            .ToArray();

        grades = ReorderColumns(grades, columnOrder);
    }

    private static Task6.Matrix ReorderColumns(Task6.Matrix matrix, int[] columnOrder)
    {
        int[,] newData = new int[matrix.Rows, matrix.Cols];

        for (int i = 0; i < matrix.Rows; i++)
        {
            for (int j = 0; j < matrix.Cols; j++)
            {
                newData[i, j] = matrix.Data[i, columnOrder[j]];
            }
        }

        return new Task6.Matrix(newData, matrix.Rows, matrix.Cols);
    }

    private static void SearchInMatrix(Task6.Matrix grades, int searchValue)
    {
        for (int i = 0; i < grades.Rows; i++)
        {
            for (int j = 0; j < grades.Cols; j++)
            {
                if (grades.Data[i, j] == searchValue)
                {
                    Console.WriteLine($"Value {searchValue} found at position ({i}, {j})");
                    return;
                }
            }
        }

        Console.WriteLine($"Value {searchValue} not found in the matrix");
    }
}