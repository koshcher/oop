namespace Lab4V3;

public class Synopsis : Book
{
    private string subject;

    public Synopsis(string subject, string author, uint pagesCount) : base(author, pagesCount)
    {
        this.subject = subject;
    }

    public string Subject { get => subject; set => subject = value; }
}