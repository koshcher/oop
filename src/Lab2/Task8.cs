namespace Lab2;

public static class Task8
{
    public static void Run()
    {
        double a = -100;
        double b = 100;
        double epsilon = 0.0001;

        var root = BisectionMethod(a, b, epsilon);
        if (root is null)
        {
            Console.WriteLine("The selected interval has no roots or an even number of roots.");
            return;
        }

        Console.WriteLine($"Root found: {root}");

        double equationResult = Equation((double)root);
        Console.WriteLine($"The value of the equation if x = {root}: {equationResult}");
    }

    private static double Equation(double x)
    {
        return Math.Pow(x, 3) - 4 * Math.Pow(x, 2) + 6;
    }

    private static double? BisectionMethod(double a, double b, double epsilon)
    {
        double fa = Equation(a);
        double fb = Equation(b);

        if (fa * fb > 0)
        {
            return null;
        }

        double root = 0;

        while ((b - a) / 2 > epsilon)
        {
            root = (a + b) / 2;
            double fRoot = Equation(root);

            if (fRoot == 0)
                break;

            if (fa * fRoot < 0)
                b = root;
            else
                a = root;
        }

        return root;
    }
}