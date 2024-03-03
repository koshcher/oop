using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2;

public static class Task9
{
    public static void Run()
    {
        Console.WriteLine("Enter text line:");
        var line = Console.ReadLine();
        if (line == null) return;

        var words = line.Split(' ', StringSplitOptions.RemoveEmptyEntries);

        var sortedByLength = string.Join(' ', words.OrderByDescending(x => x.Length));
        Console.WriteLine("Sorted by length:");
        Console.WriteLine(sortedByLength);

        var sortedByAlphabet = string.Join(' ', words.Order());
        Console.WriteLine("Sorted by alphabet:");
        Console.WriteLine(sortedByAlphabet);
    }
}