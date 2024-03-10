namespace Lab3;

public class ConsoleHelpers
{
    public static int ReadInt(Func<int, bool> successCondition, string errorMessage)
    {
        var parsed = int.TryParse(Console.ReadLine(), out var value);
        while (!parsed || !successCondition(value))
        {
            Console.WriteLine(errorMessage);
            parsed = int.TryParse(Console.ReadLine(), out value);
        }
        return value;
    }
}