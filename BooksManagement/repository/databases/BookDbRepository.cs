using System.Data;
using System.Data.Common;
using BooksManagement.model;
using BooksManagement.repository.interfaces;

namespace BooksManagement.repository.databases;

/**
 * I am using asynchronous methods (async/await) to perform database operations
 * without blocking the main thread of execution.
 * By using async/await, we perform I/O operations (like database connections and reading data)
 * in a non-blocking manner.
 */
public class BookDbRepository : IBookRepository
{
    
    private readonly string _connectionString;
    private readonly DbProviderFactory _dbProviderFactory;

    public BookDbRepository(string connectionString, DbProviderFactory dbProviderFactory)
    {
        _connectionString = connectionString;
        _dbProviderFactory = dbProviderFactory;
    }
    
    private async Task<DbConnection> CreateConnectionAsync()
    {
        var connection = _dbProviderFactory.CreateConnection();
        if (connection == null)
            throw new InvalidOperationException("Failed to create a database connection.");

        connection.ConnectionString = _connectionString;
        await connection.OpenAsync();
        return connection;
    }
    
    public async Task<Book> GetByIdAsync(int id)
    {
        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM books WHERE id = @Id";
        var idParameter = command.CreateParameter();
        idParameter.ParameterName = "@Id";
        idParameter.Value = id;
        command.Parameters.Add(idParameter);

        using var reader = await command.ExecuteReaderAsync();
        return await reader.ReadAsync() ? MapReaderToBook(reader) : null;
    }

    public async Task<IEnumerable<Book>> GetAllAsync()
    {
        var books = new List<Book>();

        await using var connection = await CreateConnectionAsync();
        await using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM books";

        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            books.Add(MapReaderToBook(reader));
        }

        return books;
    }

    public async Task<Book> CreateAsync(Book entity)
    {
        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO books (title, author, quantity, genre, price, yearpublished) VALUES (@Title, @Author, @Quantity, @Genre, @Price, @PublishedYear) RETURNING id;";

        command.Parameters.Add(CreateParameter(command, "@Title", entity.Title));
        command.Parameters.Add(CreateParameter(command, "@Author", entity.Author));
        command.Parameters.Add(CreateParameter(command, "@PublishedYear", entity.YearPublished));
        command.Parameters.Add(CreateParameter(command, "@Quantity", entity.Quantity));
        command.Parameters.Add(CreateParameter(command, "@Genre", entity.Genre));
        command.Parameters.Add(CreateParameter(command, "@Price", entity.Price));

        var result = await command.ExecuteScalarAsync();
        if (result != null)
        {
            entity.Id = Convert.ToInt32(result);
        }

        return entity;
    }

    public async Task UpdateAsync(Book entity)
    {
        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "UPDATE books SET title = @Title, author = @Author, quantity = @Quantity, price = @Price, genre = @Genre, yearpublished = @PublishedYear WHERE id = @Id";

        command.Parameters.Add(CreateParameter(command, "@Id", entity.Id));
        command.Parameters.Add(CreateParameter(command, "@Title", entity.Title));
        command.Parameters.Add(CreateParameter(command, "@Author", entity.Author));
        command.Parameters.Add(CreateParameter(command, "@PublishedYear", entity.YearPublished));
        command.Parameters.Add(CreateParameter(command, "@Quantity", entity.Quantity));
        command.Parameters.Add(CreateParameter(command, "@Genre", entity.Genre));
        command.Parameters.Add(CreateParameter(command, "@Price", entity.Price));

        await command.ExecuteNonQueryAsync();
    }
    

    public async Task DeleteAsync(int id)
    {
        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM books WHERE id = @Id";

        command.Parameters.Add(CreateParameter(command, "@Id", id));
        await command.ExecuteNonQueryAsync();
    }

    public async Task<IEnumerable<Book>> GetBooksByTitleAsync(string title)
    {
        var books = new List<Book>();

        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM books WHERE title LIKE @Title";
        command.Parameters.Add(CreateParameter(command, "@Title", $"%{title}%"));

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            books.Add(MapReaderToBook(reader));
        }

        return books;
    }

    public async Task<IEnumerable<Book>> GetBooksByAuthorAsync(string author)
    {
        var books = new List<Book>();

        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM books WHERE author LIKE @Author";
        command.Parameters.Add(CreateParameter(command, "@Author", $"%{author}%"));

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            books.Add(MapReaderToBook(reader));
        }

        return books;
    }

    public async Task<IEnumerable<Book>> GetBooksByYearPublishedAsync(int publishedYear)
    {
        var books = new List<Book>();

        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM books WHERE yearpublished = @PublishedYear";
        command.Parameters.Add(CreateParameter(command, "@PublishedYear", publishedYear));

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            books.Add(MapReaderToBook(reader));
        }

        return books;
    }

    public Task<Book> GetBookByTitleAuthorAsync(string title, string author)
    {
        using var connection = CreateConnectionAsync().Result;
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM books WHERE title = @Title AND author = @Author";
        command.Parameters.Add(CreateParameter(command, "@Title", title));
        command.Parameters.Add(CreateParameter(command, "@Author", author));

        using var reader = command.ExecuteReader();
        return reader.Read() ? Task.FromResult(MapReaderToBook(reader)) : Task.FromResult<Book>(null);
    }

    /**
     * Converts a database record to a Book entity
     * Maps database fields to corresponding Book properties
     * @param reader The database record containing book data
     * @return Book object with data from the database
     */
    private Book MapReaderToBook(IDataRecord reader)
    {
        var id = reader.GetInt32(reader.GetOrdinal("id"));
        var title = reader.GetString(reader.GetOrdinal("title"));
        var author = reader.GetString(reader.GetOrdinal("author"));
        var price = reader.GetFloat(reader.GetOrdinal("price"));
        var genre = reader.GetString(reader.GetOrdinal("genre"));
        var yearPublished = reader.GetInt32(reader.GetOrdinal("yearpublished"));
        var quantity = reader.GetInt32(reader.GetOrdinal("quantity"));
        var book = new Book(title, author,quantity, genre,price, yearPublished)
        {
            Id = id
        };
        return book;
    }

    /**
     * Creates a database parameter for use in SQL commands
     * Handles null values by converting them to DBNull.Value
     * @param command The database command that will use this parameter
     * @param name The name of the parameter 
     * @param value The value to assign to the parameter
     * @return A database parameter ready to be added to a command's Parameters collection
     */
    private DbParameter CreateParameter(DbCommand command, string name, object value)
    {
        var parameter = command.CreateParameter();
        parameter.ParameterName = name;
        parameter.Value = value ?? DBNull.Value;
        return parameter;
    }
}