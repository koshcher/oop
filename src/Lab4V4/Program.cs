using Lab4V3;
using Lab4V4;

Console.WriteLine("Roman Koshchei IPZ-12-1");
Console.WriteLine("Variant 14");
Console.WriteLine("Study Email: romankoshchey@gmail.com");
Console.WriteLine("Lab work 4 Version 1");

// Book is abstract so we can't create instance of it
// Only instance of child
Book book = new Textbook("Unknown", 230, 300);
// Print will output only fields of Book class
// Because we casted Textbook to Book
ConsolePrinter.Print(book);

var textbook = new Textbook("Goggins", 505, 240);
ConsolePrinter.Print(textbook);

var synopsis = new Synopsis("Math", "Roman", 2);
ConsolePrinter.Print(synopsis);

var bookPopularity = Statistics.CalculateBookMonthlyPopularity(book, [
    new Statistics.BookSales(book, 789),
    new Statistics.BookSales(textbook, 204),
    new Statistics.BookSales(new Textbook("Martin", 700, 700), 1250),
]);
Console.WriteLine($"Book popularity: {bookPopularity}");

var testDifficulty = Statistics.CalculateDifficultyOfTest(45, 23);
Console.WriteLine($"Test difficulty is: {testDifficulty}");

var synopsisEffectiveness = Statistics.CalculateEffectivenessOfSynopsis(
    [45, 23, 56, 90, 93, 56], [87, 75, 23, 90, 95, 87]
);
Console.WriteLine($"Writing synopsis increase your scores {synopsisEffectiveness} times");

Book[] allBooksTogether = [book, textbook, synopsis];
Console.Write("Count of pages of books: ");
Console.WriteLine($"[{string.Join(", ", allBooksTogether.Select(x => x.PagesCount.ToString()))}]");
Console.WriteLine($"Sum of  pages of all books: {allBooksTogether.Sum(x => x.PagesCount)}");

int comparison = textbook.CompareTo(synopsis);
Console.WriteLine(comparison switch
{
    < 0 => "Textbook has less pages than synopsis",
    0 => "Textbook has equale count of pages as the synopsis",
    > 0 => "Textbook has more pages than synopsis"
});

FullSortedBookList sorted = new();
foreach (var item in allBooksTogether)
{
    sorted.Books.Add(item);
}

Console.WriteLine("All books sorted with full book comparison (first author then pages):");
foreach (var item in sorted)
{
    ConsolePrinter.Print(item);
}