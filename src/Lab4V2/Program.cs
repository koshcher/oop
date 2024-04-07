using Lab4V2;

Console.WriteLine("Roman Koshchei IPZ-12-1");
Console.WriteLine("Variant 14");
Console.WriteLine("Study Email: romankoshchey@gmail.com");
Console.WriteLine("Lab work 4 Version 1");

var book = new Book("Unknown", 300);
ConsolePrinter.Print(book);

var textbook = new Textbook("Goggins", 505, 240);
ConsolePrinter.Print(textbook);

var synopsis = new Synopsis("Math", "Roman", 2);
ConsolePrinter.Print(synopsis);

var bookPopularity = Statistics.CalculateBookMonthlyPopularity(book, [
    new Statistics.BookSales(book, 789),
    new Statistics.BookSales(textbook, 204),
    new Statistics.BookSales(new Book("Martin", 700), 1250),
]);
Console.WriteLine($"Book popularity: {bookPopularity}");

var testDifficulty = Statistics.CalculateDifficultyOfTest(45, 23);
Console.WriteLine($"Test difficulty is: {testDifficulty}");

var synopsisEffectiveness = Statistics.CalculateEffectivenessOfSynopsis(
    [45, 23, 56, 90, 93, 56], [87, 75, 23, 90, 95, 87]
);
Console.WriteLine($"Writing synopsis increase your scores {synopsisEffectiveness} times");