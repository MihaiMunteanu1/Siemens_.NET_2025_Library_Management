using BooksManagement.model;

namespace BooksManagement.repository.interfaces;

/**
 * Repository interface for performing operations specific to the `Book` entity.
 */
public interface IBookRepository : IRepository<int, Book>
{
    /**
     * Retrieves books with a title matching the specified string asynchronously.
     *
     * @param title The title or part of the title to search for.
     * @return A task that represents the asynchronous operation. The task result contains a collection of books.
     */
    Task<IEnumerable<Book>> GetBooksByTitleAsync(string title);
    
    /**
     * Retrieves books written by the specified author asynchronously.
     *
     * @param author The author's name to search for.
     * @return A task that represents the asynchronous operation. The task result contains a collection of books.
     */
    Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author);

    /**
     * Retrieves books published in the specified year asynchronously.
     *
     * @param publishedYear The year of publication to search for.
     * @return A task that represents the asynchronous operation. The task result contains a collection of books.
     */
    Task<IEnumerable<Book>> GetBooksByYearPublishedAsync(int publishedYear);
    

    /**
     * Retrieves a book with the specified title and author asynchronously.
     *
     * @param title The title of the book.
     * @param author The author of the book.
     * @param year The year of publication.
     * @return A task that represents the asynchronous operation. The task result contains the book if found; otherwise, null.
     */
    Task<Book> GetBookByTitleAuthorAsync(string title, string author);
}