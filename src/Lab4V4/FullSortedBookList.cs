using Lab4V3;
using System.Collections;

namespace Lab4V4;

/// <summary>
/// List of books that are sorted with FullBookComparer in priority:
/// 1. by author
/// 2. by pages count
/// </summary>
public class FullSortedBookList : IEnumerable<Book>
{
    private readonly SortedSet<Book> books = new(new FullBookComparer());

    public SortedSet<Book> Books { get => books; }

    public IEnumerator<Book> GetEnumerator() => books.GetEnumerator();

    IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
}