namespace BooksManagement.model;


/**
 * Class that represents a lending
 * To store the lending of a book, we need to know the book id and the period of time
 */
public class Lending : Entity<int>
{
    public int BookId { get; set; }
    public DateTime from { get; set; }
    public DateTime to { get; set; }

    public Lending(int bookId, DateTime from, DateTime to)
    {
        BookId = bookId;
        this.from = from;
        this.to = to;
    }

    public override string ToString()
    {
        return $"{nameof(BookId)}: {BookId}, {nameof(from)}: {from}, {nameof(to)}: {to}";
    }
}