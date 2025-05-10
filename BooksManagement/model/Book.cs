namespace BooksManagement.model;

public class Book :  Entity<int>
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Quantity { get; set; }
    public string Genre { get; set; }
    public float Price { get; set; }
    public int YearPublished { get; set; }

    public Book(string title, string author, int quantity, string genre, float price, int yearPublished)
    {
        Title = title;
        Author = author;
        Quantity = quantity;
        Genre = genre;
        Price = price;
        YearPublished = yearPublished;
    }
    
    public override string ToString()
    {
        return
            $"{nameof(Title)}: {Title}, {nameof(Author)}: {Author}, {nameof(Quantity)}: {Quantity}, {nameof(Genre)}: {Genre}, {nameof(Price)}: {Price}, {nameof(YearPublished)}: {YearPublished}";
    }
    
}