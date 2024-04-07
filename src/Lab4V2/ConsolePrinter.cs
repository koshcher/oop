namespace Lab4V2;

/// <summary>
/// Prints information about classes into Console
/// </summary>
public class ConsolePrinter
{
    public static void Print(Book book)
    {
        Console.WriteLine("Book:");
        Console.WriteLine($"- Author: {book.Author}");
        Console.WriteLine($"- Count of pages: {book.PagesCount}");
    }

    public static void Print(Textbook textbook)
    {
        Console.WriteLine("Textbook:");
        Console.WriteLine($"- Author: {textbook.Author}");
        Console.WriteLine($"- Count of pages: {textbook.PagesCount}");
        Console.WriteLine($"- Price: {textbook.Price}");
        Console.WriteLine($"- Rating: {textbook.Rating}");
        Console.WriteLine($"- Language: {textbook.Language}");
        var publicStatus = textbook.IsPublic ? "yes" : "no";
        Console.WriteLine($"- Is public: {publicStatus}");
    }

    public static void Print(Synopsis synopsis)
    {
        Console.WriteLine("Synopsis:");
        Console.WriteLine($"- Author: {synopsis.Author}");
        Console.WriteLine($"- Count of pages: {synopsis.PagesCount}");
        Console.WriteLine($"- Subject: {synopsis.Subject}");
    }
}