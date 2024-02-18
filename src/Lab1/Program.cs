using System.Net;

internal class Program
{
    private static void Main(string[] args)
    {
        Console.WriteLine("Roman Koshchei IPZ-12-1");
        Console.WriteLine("Variant 14");
        Console.WriteLine("18 years old");
        Console.WriteLine("Study Email: romankoshchey@gmail.com");
        Console.WriteLine("Work Email: romankoshchei@gmail.com");

        string? choise = "";
        while (choise != null)
        {
            Console.WriteLine();
            Console.WriteLine("Enter your choise:");
            Console.WriteLine("[1] Task 1");
            Console.WriteLine("[2] Task 2");
            Console.WriteLine("[3] Task 3");
            Console.WriteLine("[4] Task 4");
            Console.WriteLine("[5] Task 5");
            choise = Console.ReadLine()?.Trim();

            switch (choise)
            {
                case "1":
                    FindSmallerDiagonalRhombus();
                    break;

                case "2":
                    FindX();
                    break;

                case "3":
                    FindFX();
                    break;

                case "4":
                    ColorRgb();
                    break;

                case "5":
                    SumOfRowMembers();
                    break;

                default:
                    choise = null;
                    break;
            }
        }

        Console.WriteLine("Goodbye!");
    }

    private static void FindSmallerDiagonalRhombus()
    {
        Console.WriteLine("Enter perimeter of rhombus:");
        var perimeterStr = Console.ReadLine();

        if (!int.TryParse(perimeterStr, out var perimeter))
        {
            Console.WriteLine("Can't parse perimeter into a integer");
        }

        int side = perimeter / 4;
        Console.WriteLine($"Smaller diagonal equals: {side}");
    }

    private static void FindX()
    {
        Console.WriteLine("Enter a:");
        if (!double.TryParse(Console.ReadLine(), out var a))
        {
            Console.WriteLine("Can't parse 'a' into double");
        }

        Console.WriteLine("Enter b:");
        if (!double.TryParse(Console.ReadLine(), out var b))
        {
            Console.WriteLine("Can't parse 'b' into double");
        }

        var x = Math.Pow(Math.E, a) * Math.Sqrt(Math.Sin(a * a) / Math.Log(2 + b)) + Math.Tan(a / b);
        Console.WriteLine($"X = {x}");
    }

    private static void FindFX()
    {
        Console.WriteLine("Enter a:");
        if (!double.TryParse(Console.ReadLine(), out var a))
        {
            Console.WriteLine("Can't parse 'a' into double");
        }

        Console.WriteLine("Enter x:");
        if (!double.TryParse(Console.ReadLine(), out var x))
        {
            Console.WriteLine("Can't parse 'x' into double");
        }

        // with pattern matching
        Console.WriteLine((x, a) switch
        {
            ( >= -1 and < 1, > 0) => $"f(x) = {-1 * a * x}",
            ( > 1, < 0) => $"f(x) = {a - x}",
            (1, 0) => $"f(x) = {a / x}",
            _ => "f(x) doesn't have a solution for given arguments"
        });

        // basic
        //if (x >= -1 && x < 1 && a > 0)
        //{
        //    Console.WriteLine($"f(x) = {-1 * a * x}");
        //    return;
        //}

        //if (x > 1 && a < 0)
        //{
        //    Console.WriteLine($"f(x) = {a - x}");
        //    return;
        //}

        //if (x == 1 && a == 0)
        //{
        //    Console.WriteLine($"f(x) = {a / x}");
        //    return;
        //}

        //Console.WriteLine("f(x) doesn't have a solution for given arguments");
    }

    private static readonly (string name, int r, int g, int b)[] supportedColors = [
        ("red", 255, 0, 0),
        ("orange", 255, 165, 0),
        ("yellow", 255, 255, 0),
        ("green", 0, 255, 0),
        ("blue", 0, 0, 255),
        ("sky", 135, 206, 250), // блакитний
        ("violet", 148, 0, 211),
    ];

    private static void ColorRgb()
    {
        Console.WriteLine("Enter color: ");
        var color = Console.ReadLine()?.ToLower().Trim();

        for (int i = 0; i < supportedColors.Length; i++)
        {
            var (name, r, g, b) = supportedColors[i];
            if (name == color)
            {
                Console.WriteLine($"Color: {color}");
                Console.WriteLine($"RGB: {r} {g} {b}");
                return;
            }
        }

        Console.WriteLine("Color wasn't found");
    }

    public static void SumOfRowMembers()
    {
        Console.WriteLine("Enter natural number n:");
        if (!int.TryParse(Console.ReadLine(), out var n) || n <= 0)
        {
            Console.WriteLine("Provided 'n' is not a possitive integer");
        }

        Console.WriteLine("Enter x >0:");
        if (!double.TryParse(Console.ReadLine(), out var x) || x <= 0)
        {
            Console.WriteLine("Provided 'x' is not a positive number");
        }

        double sum = 0;
        for (var i = 1; i <= n; i += 1)
        {
            // it's fine
            var top = Math.Pow(-1, i) * Math.Pow(x, i);
            var bottom = (i + 1) * (1 + Math.Pow(x, i));
            sum += top / bottom;
        }

        Console.WriteLine($"Sum of row members: {sum}");
    }
}