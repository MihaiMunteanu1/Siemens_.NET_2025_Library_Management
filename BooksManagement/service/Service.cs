using BooksManagement.model;
using BooksManagement.repository.interfaces;

namespace BooksManagement.service;

/**
 * Service class that provides methods for managing books and lendings.
 */
public class Service : IService
{
    private readonly IBookRepository _bookRepository;
    private readonly ILendingRepository _lendingRepository;

    public Service(IBookRepository bookRepository, ILendingRepository lendingRepository)
    {
        _bookRepository = bookRepository;
        _lendingRepository = lendingRepository;
    }


    public async Task<Book> GetBookByTitleAuthorAsync(string title, string author)
    {
        if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(author) )
        {
            throw new ArgumentException("Title, author, and year must be provided.");
        }

        return await _bookRepository.GetBookByTitleAuthorAsync(title, author);
    }
    

    public async Task<IEnumerable<Book>> GetAllBooksAsync()
    {
        return await _bookRepository.GetAllAsync();
    }

    public async Task<IEnumerable<Book>> GetAllBooksByTitleAsync(string title)
    {
        if (string.IsNullOrWhiteSpace(title))
        {
            throw new ArgumentException("Title cannot be empty.");
        }

        return await _bookRepository.GetBooksByTitleAsync(title);
        
    }

    public async Task<IEnumerable<Book>> GetAllBooksByAuthorAsync(string author)
    {
        if (string.IsNullOrWhiteSpace(author))
        {
            throw new ArgumentException("Author cannot be empty.");
        }

        return await _bookRepository.GetBooksByAuthorAsync(author);

    }

    public async Task<IEnumerable<Book>> GetAllBooksByYearAsync(int year)
    {
        
        if (year <= 0)
        {
            throw new ArgumentException("Year must be a positive integer.");
        }
        
        return await _bookRepository.GetBooksByYearPublishedAsync(year);

    }

    public async Task<Book> CreateBookAsync(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }

        // check if the book already exists
        var existingBooks = await _bookRepository.GetAllAsync();
        if (existingBooks.Any(b => b.Title.Equals(book.Title, StringComparison.OrdinalIgnoreCase) 
                                   && b.Author.Equals(book.Author, StringComparison.OrdinalIgnoreCase)))
        {
            throw new InvalidOperationException($"A book with the title '{book.Title}' by '{book.Author}' already exists.");
        }
        return await _bookRepository.CreateAsync(book);
    }

    public async Task UpdateBookAsync(Book book)
    {
        if (book == null)
        {
            throw new ArgumentNullException(nameof(book));
        }

        // check if the book exists
        var existingBook = await _bookRepository.GetByIdAsync(book.Id);
        if (existingBook == null)
        {
            throw new KeyNotFoundException($"Book with ID {book.Id} not found.");
        }

        await _bookRepository.UpdateAsync(book);
    }

    public async Task DeleteBookAsync(int id)
    {
        // check if the book exists
        var book = await _bookRepository.GetByIdAsync(id);
        if (book == null)
        {
            throw new KeyNotFoundException($"Book with ID {id} not found.");
        }

        
        await _bookRepository.DeleteAsync(id);
    }

    ///  Lendings

    public async Task LendBookAsync(Lending lending, DateTime from, DateTime to)
    {
        
        var book = await _bookRepository.GetByIdAsync(lending.BookId);
        
        // check if the book would be over-lent in the requested period
        var isOverLent = await IsBookOverLentInPeriodAsync(book, from, to);
        if (isOverLent)
        {
            throw new InvalidOperationException($"Cannot lend book '{book.Title}' - all copies are already lent during the requested period.");
        }

        // update the lending with the provided dates
        lending.from = from;
        lending.to = to;

        await _lendingRepository.CreateAsync(lending);
    }
    
    public async Task<bool> IsBookOverLentInPeriodAsync(Book book, DateTime startDate, DateTime endDate)
    {
        // get all lendings for this specific book
        var bookLendings = await _lendingRepository.GetLendingsByBookIdAsync(book.Id);
    
        // count how many lendings overlap with the specified date range
        int overlappingLendings = 0;
        foreach (var lending in bookLendings)
        {
            // check if the lending period overlaps with the requested period
            // two date ranges overlap if one starts before or on the day the other ends,
            // and ends after or on the day the other starts
            if (lending.from <= endDate && lending.to >= startDate)
            {
                overlappingLendings++;
            }
        }
    
        // if the number of overlapping lendings equals or exceeds the book's quantity,
        // the book would be over-lent
        return overlappingLendings >= book.Quantity;
    }
    
    /**
     * Returns books that are available for lending during the specified period
     * @param startDate The start date of the lending period
     * @param endDate The end date of the lending period
     * returns A collection of books available for lending during the specified period
     */
    public async Task<IEnumerable<Book>> GetAvailableBooksInPeriodAsync(DateTime startDate, DateTime endDate)
    {
        
        // get all books
        var allBooks = await _bookRepository.GetAllAsync();
        var availableBooks = new List<Book>();
    
        // check each book if it's available in the specified period
        foreach (var book in allBooks)
        {
            // skip books with zero quantity
            if (book.Quantity <= 0)
                continue;
            
            // check if the book would be over-lent in the specified period
            bool isOverLent = await IsBookOverLentInPeriodAsync(book, startDate, endDate);
        
            // if the book is not over-lent, it's available
            if (!isOverLent)
            {
                availableBooks.Add(book);
            }
        }
    
        return availableBooks;
    }
}