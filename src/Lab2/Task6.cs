namespace Lab2;

public static class Task6
{
    public record Matrix(int[,] Data, int Rows, int Cols);

    public static void Run()
    {
        Console.Write("Enter students count: ");
        if (int.TryParse(Console.ReadLine(), out int students) is false || students < 1)
        {
            Console.WriteLine("Students must be a positive integer");
            return;
        }

        Console.Write("Enter subjects count: ");
        if (int.TryParse(Console.ReadLine(), out int subjects) is false || students < 1)
        {
            Console.WriteLine("Students must be a positive integer");
            return;
        }

        var grades = GenerateGradesMatrix(students, subjects);

        Console.WriteLine("Grades");
        PrintGrades(grades);

        PrintStudentsForDeduction(grades);
        PrintStudentsRates(grades);
        PrintSubjectWithHighestAvgGrade(grades);
    }

    private static void PrintSubjectWithHighestAvgGrade(Matrix grades)
    {
        var maxAvg = -1;
        var maxAvgSubject = -1;

        for (int j = 0; j < grades.Cols; j++)
        {
            int sum = 0;
            for (int i = 0; i < grades.Rows; i++)
            {
                sum += grades.Data[i, j];
            }
            var avg = sum / grades.Rows;
            if (avg > maxAvg)
            {
                maxAvg = avg;
                maxAvgSubject = j;
            }
        }

        if (maxAvgSubject < 0)
        {
            Console.WriteLine("Subject wasn't found");
        }
        else
        {
            Console.WriteLine($"Subject {maxAvgSubject} has highest avg rate: {maxAvg}");
        }
    }

    private static void PrintStudentsRates(Matrix grades)
    {
        Console.WriteLine("Students Rates:");
        for (int i = 0; i < grades.Rows; i++)
        {
            var sum = 0;
            for (int j = 0; j < grades.Cols; j++)
            {
                sum += grades.Data[i, j];
            }
            Console.WriteLine($"Student {i} has avg grade: {sum / grades.Cols}");
        }
    }

    private static void PrintStudentsForDeduction(Matrix grades)
    {
        Console.WriteLine("Students for Deduction:");
        for (int i = 0; i < grades.Rows; i++)
        {
            if (IsForDeduction(grades, i))
            {
                Console.WriteLine($"Student: {i} is for deduction");
            }
        }
    }

    private static bool IsForDeduction(Matrix grades, int student)
    {
        var sum = 0;
        for (int j = 0; j < grades.Cols; j += 1)
        {
            var grade = grades.Data[student, j];
            sum += grade;
        }
        return sum / grades.Cols < 60;
    }

    public static Matrix GenerateGradesMatrix(int students, int subjects)
    {
        var rnd = new Random();
        var grades = new int[students, subjects];

        for (int i = 0; i < students; i += 1)
        {
            for (int j = 0; j < subjects; j += 1)
            {
                grades[i, j] = rnd.Next(40, 101);
            }
        }

        return new(grades, students, subjects);
    }

    public static void PrintGrades(Matrix grades)
    {
        for (int i = 0; i < grades.Rows; i++)
        {
            for (int j = 0; j < grades.Cols; j++)
            {
                var num = grades.Data[i, j];
                if (num < 10)
                {
                    Console.Write($"|   {num} ");
                }
                else if (num == 100)
                {
                    Console.Write($"| {num} ");
                }
                else
                {
                    Console.Write($"|  {num} ");
                }
            }
            Console.WriteLine("|");
        }
    }
}