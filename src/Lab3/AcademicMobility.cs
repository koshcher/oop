namespace Lab3;

public partial class AcademicMobility
{
    /// <summary>
    /// Hold connection to the file where we will store Students
    /// </summary>
    private readonly StreamWriter fileWriter;

    public AcademicMobility()
    {
        Email = string.Empty;
        InternationPrograms = [];
        Universities = [];
        Students = [];
        fileWriter = new StreamWriter("academic-mobility.txt", true) { AutoFlush = true };
    }

    public AcademicMobility(
        string fileName,
        string email, List<InterProgram> internationPrograms,
        List<string> universities, List<Student> students
    )
    {
        fileWriter = new StreamWriter(fileName, true) { AutoFlush = true };
        Email = email;
        InternationPrograms = internationPrograms;
        Universities = universities;
        Students = students;
    }

    /// <summary>
    /// Don't forget to clean up file writer
    /// </summary>
    ~AcademicMobility()
    {
        if (fileWriter != null)
        {
            fileWriter.Close();
            fileWriter.Dispose();
        }
    }

    public enum StudyProgramType
    { InternationProgram, University };

    public string Email { get; set; }
    public List<InterProgram> InternationPrograms { get; set; }
    public List<Student> Students { get; set; }
    public List<string> Universities { get; set; }

    /// <returns>
    /// Type is eather international program or university
    /// and second element is index.
    /// </returns>
    public (StudyProgramType, int)? FindStudyProgram(string name)
    {
        Universities.Sort();
        var index = Universities.BinarySearch(name);
        if (index >= 0) return (StudyProgramType.University, index);

        InternationPrograms.Sort((x, y) => x.Name.CompareTo(y.Name));
        index = InternationPrograms.BinarySearch(new InterProgram(name), InterProgram.Comparer);
        if (index >= 0) return (StudyProgramType.InternationProgram, index);

        return null;
    }

    public void ReadFromConsole()
    {
        Console.WriteLine("Enter Email:");
        Email = Console.ReadLine() ?? string.Empty;

        Console.WriteLine("Enter Internation Programs count:");
        var count = ConsoleHelpers.ReadInt(
           value => value >= 0,
           "Count must be a non negative integener (>=0):"
       );

        InternationPrograms = new List<InterProgram>(count);
        for (int i = 0; i < count; i += 1)
        {
            Console.WriteLine($"Enter internation program {i + 1}:");
            InternationPrograms.Add(new(Console.ReadLine() ?? string.Empty));
        }

        Console.WriteLine("Enter Universities count:");
        count = ConsoleHelpers.ReadInt(
           value => value >= 0,
           "Count must be a non negative integener (>=0):"
       );

        Universities = new List<string>(count);
        for (int i = 0; i < count; i += 1)
        {
            Console.WriteLine($"Enter university {i + 1}:");
            Universities.Add(Console.ReadLine() ?? string.Empty);
        }
    }

    public void RegisterStudent(Student student)
    {
        Students.Add(student);
        student.WriteToFile(fileWriter);
        fileWriter.WriteLine("-----------------------");
    }

    public void WriteToConsole()
    {
        WriteTo(Console.WriteLine);
    }

    public void WriteToFile()
    {
        WriteTo(fileWriter.WriteLine);
    }

    /// <summary>
    /// Because we have the same output for Console and File.
    /// Let's just have 1 method that will write line by line into any source.
    /// </summary>
    private void WriteTo(Action<string> writeLine)
    {
        writeLine($"Email: {Email}");
        writeLine($"Internation programs:");
        foreach (var program in InternationPrograms)
        {
            writeLine($"- {program.Name}");
        }
        writeLine($"Universitiess:");
        foreach (var uni in Universities)
        {
            writeLine($"- {uni}");
        }
    }

    public partial class InterProgram
    {
        public IEnumerable<Student> GetBestCandidates(int limit)
        {
            return Students.OrderByDescending(x => x.GetRating()).Take(limit);
        }
    }
}