namespace Lab4V4;

/// <summary>
/// Class contains different methods to calculatet statistics.
/// Methods are static, because the class doesn't hold any state.
/// </summary>
public class Statistics
{
    public record BookSales(Book Book, uint SalesCount);

    private const uint AVARAGE_PERCENT = 50;
    private const uint MAX_PERCENT = 100;
    private const uint MIN_PERCENT = 0;

    /// <summary>
    /// Calculate rating of a particular book based on monthly sales.
    /// Rating is relative to other books.
    /// </summary>
    /// <param name="book">Book for which we calculate rating</param>
    /// <param name="sales">List of all book sold in the month</param>
    /// <returns>Popularity rating from 0 to 100</returns>
    public static uint CalculateBookMonthlyPopularity(Book book, List<BookSales> sales)
    {
        var avarageSales = sales.Average(s => s.SalesCount);
        if (avarageSales == 0) return AVARAGE_PERCENT;

        var bookSales = sales.FirstOrDefault(x => x.Book.Equals(book));
        if (bookSales == null) return MIN_PERCENT;

        double popularity = 0.01 * AVARAGE_PERCENT * bookSales.SalesCount / avarageSales;

        uint rounded = (uint)Math.Round(popularity);
        if (rounded > MAX_PERCENT) return MAX_PERCENT;
        if (rounded < MIN_PERCENT) return MIN_PERCENT;
        return rounded;
    }

    /// <summary>
    /// Calculate percent difficulty of a particular test.
    /// Based on count of students that passed.
    /// </summary>
    /// <param name="allStudents">Count of all students that took the test</param>
    /// <param name="studentsThatSolved">Count of students that solved the test</param>
    /// <returns></returns>
    public static uint CalculateDifficultyOfTest(uint allStudents, uint studentsThatSolved)
    {
        var passedPercent = MAX_PERCENT * studentsThatSolved * 0.1 / allStudents;

        var difficulty = MAX_PERCENT - passedPercent;

        uint rounded = (uint)Math.Round(difficulty);
        if (rounded > MAX_PERCENT) return MAX_PERCENT;
        if (rounded < MIN_PERCENT) return MIN_PERCENT;

        return rounded;
    }

    /// <summary>
    /// Calculates effectiveness of writing synopsis based on tests scores.
    /// </summary>
    /// <param name="scoresWithoutSynopsis">List of scores (from 0% to 100%) without writing synopsis</param>
    /// <param name="scoresWithSynopsis">List of scores (from 0% to 100%) with writing synopsis</param>
    /// <returns>Number in how much times with synopsis studend score more than without</returns>
    public static double CalculateEffectivenessOfSynopsis(List<uint> scoresWithoutSynopsis, List<uint> scoresWithSynopsis)
    {
        var withoutSynopsisAvg = scoresWithoutSynopsis.Average(x => x);
        var withSynopsisAvg = scoresWithSynopsis.Average(x => x);
        return withSynopsisAvg / withoutSynopsisAvg;
    }
}