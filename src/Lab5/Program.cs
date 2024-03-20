Console.WriteLine("Roman Koshchei IPZ-12-1");
Console.WriteLine("Variant 14");
Console.WriteLine("Study Email: romankoshchey@gmail.com");
Console.WriteLine("Lab work 5");

public class Book
{
}

public class Textbook : Book
{
}

public class Synopsis : Book
{
}

public class EBook : Book
{
    private readonly string link;

    public EBook()
    {
        link = string.Empty;
    }

    public EBook(string link)
    {
        this.link = link;
    }
}