using Lab3;
using System.Text;

Console.WriteLine("Roman Koshchei IPZ-12-1");
Console.WriteLine("Variant 14");
Console.WriteLine("Study Email: romankoshchey@gmail.com");
Console.WriteLine("Work Email: romankoshchei@gmail.com");

var academicMobility = new AcademicMobility(
    "./academic-mobility.txt", "mobility@academic.com",
    [
        new("Erasmus Mundus Joint Master's Degree in Computer Vision and Robotics"),
        new("Fulbright Scholar Program"),
        new("Chevening Scholarship"),
        new("International Baccalaureate (IB) Program"),
        new("DAAD Scholarships"),
    ],
    [
        "Harvard University", "University of Oxford", "Stanford University",
        "ETH Zurich", "National University of Singapore"
    ],
    []
);

academicMobility.WriteToConsole();
academicMobility.WriteToFile();

Console.WriteLine();

var student = new Student();
student.ReadFromConsole();

Console.WriteLine();

Console.WriteLine("Student:");
student.WriteToConsole();

using var inputStudentFile = new StreamWriter("input-student.txt") { AutoFlush = true };
student.WriteToFile(inputStudentFile);

inputStudentFile.WriteLine("-----------------------");
student.ExportIqResults(inputStudentFile);

List<Student> students = [];
for (int i = 0; i < 10; i++)
{
    students.Add(Student.GenerateRandomStudent());
}

foreach (var person in students)
{
    academicMobility.RegisterStudent(person);
}

Console.WriteLine();

var studyProgram = academicMobility.FindStudyProgram("Chevening Scholarship");
if (studyProgram.HasValue)
{
    (var type, var index) = studyProgram.Value;
    Console.WriteLine("Chevening Scholarship exist");
    string typeStr = type switch
    {
        AcademicMobility.StudyProgramType.University => "University",
        _ => "International program"
    };
    Console.WriteLine($"It's a {typeStr}");
    Console.WriteLine($"Position is {index}");
}

var interProgram = academicMobility.InternationPrograms[0];
foreach (var person in students)
{
    interProgram.Students.Add(person);
}

interProgram.Present();
Console.WriteLine();

var best = interProgram.GetBestCandidates(5);
Console.WriteLine($"5 best students of {interProgram.Name} program:");
Console.WriteLine("-----------------------");
foreach (var person in best)
{
    person.WriteToConsole();
    Console.WriteLine("-----------------------");
}
Console.WriteLine();

ResearchWork.PrintGeneratedArray();

Console.WriteLine();

ResearchWork.Projects();

Console.WriteLine();

ResearchWork.Strings();