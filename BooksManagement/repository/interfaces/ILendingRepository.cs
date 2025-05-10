using BooksManagement.model;

namespace BooksManagement.repository.interfaces;

/**
 * Repository interface for performing operations specific to the `Lending` entity.
 */
public interface ILendingRepository : IRepository<int, Lending>
{
    /**
     * Retrieves all lendings for a specific book asynchronously.
     *
     * @param bookId The identifier of the book.
     * @return A task that represents the asynchronous operation. The task result contains a collection of lendings.
     */
    Task<IEnumerable<Lending>> GetLendingsByBookIdAsync(int bookId);
    
}