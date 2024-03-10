namespace Lab3;

/// <summary>
/// Reverse comparison of double.
/// So sorting will be descending.
/// </summary>
public class ReverseDoubleComparer : IComparer<double>
{
    public static ReverseDoubleComparer Instance { get; } = new();

    public int Compare(double x, double y)
    {
        return y.CompareTo(x);
    }
}

public partial class AcademicMobility
{
    public partial class InterProgram
    {
        public InterProgram(string name)
        {
            Name = name;
        }

        public static InterProgramComparer Comparer { get; } = new InterProgramComparer();

        public string Name { get; set; }

        public List<Student> Students { get; set; } = [];

        public void Present()
        {
            Console.WriteLine($"International Program: {Name}");
            Console.WriteLine("Students:");
            Console.WriteLine("------------------------");
            foreach (Student student in Students)
            {
                student.WriteToConsole();
                Console.WriteLine("------------------------");
            }
        }
    }

    public class InterProgramComparer : IComparer<InterProgram>
    {
        public int Compare(InterProgram? x, InterProgram? y)
        {
            if (x == null && y == null) return 0;
            if (x == null) return -1;
            if (y == null) return 1;

            return x.Name.CompareTo(y.Name);
        }
    }
}