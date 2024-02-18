namespace Demo.Api.Models;

public class Book
{
    [IsProjected] // This works
    public int Id { get; set; }

    public string Title { get; set; }

    public int AuthorId { get; set; }

    [IsProjected] // Does not work. Uncomment to make the demo request work...
    public Author Author { get; set; }
}