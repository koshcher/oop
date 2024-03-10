namespace Lab3;

public enum ScientificAchievement
{
    Article,
    Conference,
    Competition,
    OtherEvent
}

/// <summary>
/// Properties automatically create private fields during compilation.
/// </summary>
public class Student
{
    public string SurName { get; set; }
    public string FirstName { get; set; }
    public int Course { get; set; }
    public string Speciality { get; set; }
    public string University { get; set; }

    public List<int> Marks { get; set; }
    public List<ScientificAchievement> ScientificAchievements { get; set; }

    public Student()
    {
        SurName = string.Empty;
        FirstName = string.Empty;
        Course = 1;
        Speciality = string.Empty;
        University = string.Empty;
        Marks = GenerateMarks();
        ScientificAchievements = [];
    }

    /// <summary>
    /// Maybe need to check marks in future. That each mark is between 0 and 100.
    /// </summary>
    public Student(
        string surName, string firstName, int course, string speciality,
        string university, List<int> marks, List<ScientificAchievement> achievements
    )
    {
        SurName = surName;
        FirstName = firstName;
        Course = course;
        Speciality = speciality;
        University = university;
        Marks = marks;
        ScientificAchievements = achievements;
    }

    private static List<int> GenerateMarks()
    {
        const int count = 10;
        var rnd = new Random();
        var marks = new List<int>(count);
        for (int i = 0; i < count; i++)
        {
            marks.Add(rnd.Next(40, 101));
        }
        return marks;
    }

    public static Student GenerateRandomStudent()
    {
        Random random = new();

        string[] names = ["John", "Jane", "Alice", "Bob", "Eva", "Michael", "Olivia", "Daniel"];
        string[] universities = ["Harvard", "MIT", "Stanford", "Oxford", "ETH Zurich", "NUS"];
        string[] specialities = ["Computer Science", "Physics", "Engineering", "Biology", "Economics"];

        Student randomStudent = new()
        {
            SurName = names[random.Next(names.Length)],
            FirstName = names[random.Next(names.Length)],
            Course = random.Next(1, 6),
            Speciality = specialities[random.Next(specialities.Length)],
            University = universities[random.Next(universities.Length)],
            Marks = GenerateMarks()
        };

        // Generate random scientific achievements
        for (int i = 0; i < 3; i++)
        {
            randomStudent.ScientificAchievements.Add(
                (ScientificAchievement)random.Next(Enum.GetValues(typeof(ScientificAchievement)).Length)
            );
        }

        return randomStudent;
    }

    /// <summary>
    /// Maybe make static and return Student in future.
    /// </summary>
    public void ReadFromConsole()
    {
        Console.WriteLine("Enter SurName:");
        SurName = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter FirstName:");
        FirstName = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter Course:");
        Course = ConsoleHelpers.ReadInt(
           value => value > 0,
           "Course should be a positive integener (>0):"
       );

        Console.WriteLine("Enter Speciality:");
        Speciality = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter University:");
        University = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter Scientific Achievements count:");
        var count = ConsoleHelpers.ReadInt(
           value => value >= 0,
           "Count must be a non negative integener (>=0):"
       );

        Console.WriteLine("Scientific Achievements types:");
        Console.WriteLine("- [1] Article");
        Console.WriteLine("- [2] Conference");
        Console.WriteLine("- [3] Competition");
        Console.WriteLine("- [other] OtherEvent");

        ScientificAchievements = new(count);
        for (int i = 0; i < count; i += 1)
        {
            Console.WriteLine($"Enter scientific achievement {i + 1}:");
            var type = Console.ReadLine();
            ScientificAchievements.Add(type switch
            {
                "1" => ScientificAchievement.Article,
                "2" => ScientificAchievement.Conference,
                "3" => ScientificAchievement.Competition,
                _ => ScientificAchievement.OtherEvent,
            });
        }

        Console.WriteLine("Enter Marks count:");
        count = ConsoleHelpers.ReadInt(
            value => value >= 0,
            "Count must be a non negative integener (>=0):"
        );

        Marks = new(count);
        for (int i = 0; i < count; ++i)
        {
            var mark = ConsoleHelpers.ReadInt(
                value => value >= 0 && value <= 100,
                "Enter mark (>=0 and <=100):"
            );
            Marks.Add(mark);
        }
    }

    public double GetRating()
    {
        int sum = 0;
        foreach (var mark in Marks)
        {
            sum += mark;
        }
        double avg = sum / Marks.Count;

        foreach (var achivement in ScientificAchievements)
        {
            avg += achivement switch
            {
                ScientificAchievement.Article => 5,
                _ => 4
            };
        }
        return avg;
    }

    /// <summary>
    /// Let's assume that IQ is average mark.
    /// </summary>
    /// <param name="writer">Stream Writer of file</param>
    public void ExportIqResults(StreamWriter writer)
    {
        if (Marks.Count == 0) return;

        int sum = 0;
        foreach (var mark in Marks)
        {
            sum += mark;
        }
        double avg = sum / Marks.Count;

        writer.WriteLine($"Student: {SurName} {FirstName}");
        writer.WriteLine($"IQ: {avg}");
    }

    public void WriteToConsole()
    {
        WriteTo(Console.WriteLine);
    }

    /// <summary>
    /// Writing student info to file.
    /// </summary>
    /// <param name="writer">
    /// StreamWriter for file.
    /// It's better to not open file inside of logic method.
    /// Open file outside and then just pass stream.
    /// </param>
    public void WriteToFile(StreamWriter writer)
    {
        WriteTo(writer.WriteLine);
    }

    /// <summary>
    /// Because we have the same output for Console and File.
    /// Let's just have 1 method that will write line by line into any source.
    /// </summary>
    private void WriteTo(Action<string> writeLine)
    {
        writeLine($"SurName: {SurName}");
        writeLine($"FirstName: {FirstName}");
        writeLine($"Course: {Course}");
        writeLine($"Speciality: {Speciality}");
        writeLine($"University: {University}");
    }
}