namespace BooksManagement.service;

using BooksManagement.model;

public interface IService
{
    /**
     * Retrieves a book by its title and author.
     * @param title The title of the book to find
     * @param author The author of the book to find
     * @return The matching book if found
     */
    Task<Book> GetBookByTitleAuthorAsync(string title, string author);
    
    /**
     * Retrieves all books in the db.
     * @return A collection of all books
     */
    Task<IEnumerable<Book>> GetAllBooksAsync();
    
    /**
     * Retrieves all books that match the specified title.
     * @param title The title to search for
     * @return A collection of books with matching titles
     */
    Task<IEnumerable<Book>> GetAllBooksByTitleAsync(string title);
    
    /**
     * Retrieves all books by a specific author.
     * @param author The author to search for
     * @return A collection of books by the specified author
     */
    Task<IEnumerable<Book>> GetAllBooksByAuthorAsync(string author);
    
    /**
     * Retrieves all books published in a specific year.
     * @param year The publication year to search for
     * @return A collection of books published in the specified year
     */
    Task<IEnumerable<Book>> GetAllBooksByYearAsync(int year);
    
    /**
     * Creates a new book in the db.
     * @param book The book to create
     * @return The created book with assigned ID
     */
    Task<Book> CreateBookAsync(Book book);
    
    /**
     * Updates an existing book's information.
     * @param book The book with updated information
     */
    Task UpdateBookAsync(Book book);
    
    /**
     * Deletes a book from the db by its ID.
     * @param id The ID of the book to delete
     */
    Task DeleteBookAsync(int id);
    
    /**
     * Records a book lending transaction.
     * @param lending The lending information including book ID and date range
     */
    Task LendBookAsync(Lending lending,DateTime from, DateTime to);
    
    /**
     * Checks if a book would be over-lent during a specified date range.
     * A book is considered over-lent if the number of existing lendings that overlap
     * with the date range exceeds the book's available quantity.
     *
     * @param book The book to check for availability
     * @param startDate The start date of the lending period to validate
     * @param endDate The end date of the lending period to validate
     * @return True if lending the book would exceed its quantity, false otherwise
     */
    Task<bool> IsBookOverLentInPeriodAsync(Book book, DateTime startDate, DateTime endDate);

    /**
     * Retrieves all available books within a specified date range.
     * @param startDate The start date of the period to check
     * @param endDate The end date of the period to check
     */
    Task<IEnumerable<Book>> GetAvailableBooksInPeriodAsync(DateTime startDate, DateTime endDate);
}