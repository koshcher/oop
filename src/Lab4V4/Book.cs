namespace Lab4V4;

/// <summary>
/// Book has fields: author and pagesCount
/// Because pricing and name is specific and don't appear in Synopsis
/// </summary>
public abstract class Book : IComparable<Book>
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

    public int CompareTo(Book? other)
    {
        if (other == null) return 1;
        return pagesCount.CompareTo(other.pagesCount);
    }
}

public class FullBookComparer : IComparer<Book>
{
    public int Compare(Book? x, Book? y)
    {
        if (x == null && y == null) return 0;
        else if (x == null) return -1;
        else if (y == null) return 1;

        int authorComparison = string.Compare(x.Author, y.Author, StringComparison.Ordinal);
        if (authorComparison != 0) return authorComparison;

        return x.PagesCount.CompareTo(y.PagesCount);
    }
}