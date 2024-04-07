namespace Lab4V1;

public class Textbook : Book
{
    private uint price;
    private uint rating;
    private string language;
    private bool isPublic;

    public Textbook(string author, uint price, uint pagesCount) : base(author, pagesCount)
    {
        this.price = price;
        rating = 50;
        language = "en";
        isPublic = true;
    }

    public uint Price { get => price; set => price = value; }
    public uint Rating { get => rating; set => rating = value; }
    public string Language { get => language; set => language = value; }
    public bool IsPublic { get => isPublic; set => isPublic = value; }
}