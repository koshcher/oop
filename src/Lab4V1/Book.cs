namespace Lab4V1;

/// <summary>
/// Book has fields: author and pagesCount
/// Because pricing and name is specific and don't appear in Synopsis
/// </summary>
public class Book
{
    private string author;
    private uint pagesCount;

    public Book(string author, uint pagesCount)
    {
        this.author = author;
        this.pagesCount = pagesCount;
    }

    public string Author { get => author; set => author = value; }
    public uint PagesCount { get => pagesCount; set => pagesCount = value; }
}