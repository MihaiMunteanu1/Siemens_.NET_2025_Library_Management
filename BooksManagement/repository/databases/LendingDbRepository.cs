using System.Data;
using System.Data.Common;
using BooksManagement.model;
using BooksManagement.repository.interfaces;

namespace BooksManagement.repository.databases;

/**
 * We are using asynchronous methods (async/await) to perform database operations
 * without blocking the main thread of execution.
 * By using async/await, we perform I/O operations (like database connections and reading data)
 * in a non-blocking manner.
 */
public class LendingDbRepository : ILendingRepository
{
    private readonly string _connectionString;
    private readonly DbProviderFactory _dbProviderFactory;

    public LendingDbRepository(string connectionString, DbProviderFactory dbProviderFactory)
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

    public async Task<Lending> GetByIdAsync(int id)
    {
        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM lendings WHERE id = @Id";
        command.Parameters.Add(CreateParameter(command, "@Id", id));

        using var reader = await command.ExecuteReaderAsync();
        return await reader.ReadAsync() ? MapReaderToLending(reader) : null;
    }

    public async Task<IEnumerable<Lending>> GetAllAsync()
    {
        var lendings = new List<Lending>();

        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM lendings";

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            lendings.Add(MapReaderToLending(reader));
        }

        return lendings;
    }

    public async Task<Lending> CreateAsync(Lending entity)
    {
        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "INSERT INTO lendings (book_id, fromdate, todate) VALUES (@BookId, @FromDate, @ToDate) RETURNING id;";

        //reset ID to ensure we use the database-generated
        entity.Id = 0;
        
        command.Parameters.Add(CreateParameter(command, "@BookId", entity.BookId));
        command.Parameters.Add(CreateParameter(command, "@FromDate", entity.from));
        command.Parameters.Add(CreateParameter(command, "@ToDate", entity.to));

        var result = await command.ExecuteScalarAsync();
        if (result != null)
        {
            entity.Id = Convert.ToInt32(result);
        }

        return entity;
    }

    public async Task UpdateAsync(Lending entity)
    {
        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "UPDATE lendings SET book_id = @BookId, fromdate = @FromDate, todate = @ToDate WHERE id = @Id";

        command.Parameters.Add(CreateParameter(command, "@Id", entity.Id));
        command.Parameters.Add(CreateParameter(command, "@BookId", entity.BookId));
        command.Parameters.Add(CreateParameter(command, "@FromDate", entity.from));
        command.Parameters.Add(CreateParameter(command, "@ToDate", entity.to));

        await command.ExecuteNonQueryAsync();
    }

    public async Task DeleteAsync(int id)
    {
        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "DELETE FROM lendings WHERE id = @Id";

        command.Parameters.Add(CreateParameter(command, "@Id", id));
        await command.ExecuteNonQueryAsync();
    }

    public async Task<IEnumerable<Lending>> GetLendingsByBookIdAsync(int bookId)
    {
        var lendings = new List<Lending>();

        using var connection = await CreateConnectionAsync();
        using var command = connection.CreateCommand();
        command.CommandText = "SELECT * FROM lendings WHERE book_id = @BookId";
        command.Parameters.Add(CreateParameter(command, "@BookId", bookId));

        using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            lendings.Add(MapReaderToLending(reader));
        }

        return lendings;
    }
    

    /**
     * Maps a data record to a Lending object
     * @param reader The data record to map
     * @return A Lending object with the mapped values
     */
    private Lending MapReaderToLending(IDataRecord reader)
    {
        return new Lending(
            reader.GetInt32(reader.GetOrdinal("book_id")),
            reader.GetDateTime(reader.GetOrdinal("fromdate")).Date,
            reader.GetDateTime(reader.GetOrdinal("todate")).Date
        )
        {
            Id = reader.GetInt32(reader.GetOrdinal("id"))
        };
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
        
        // if the value is a DateTime, set the Date property
        if (value is DateTime dateTimeValue)
        {
            parameter.Value = dateTimeValue.Date;
        }
        else
        {
            parameter.Value = value ?? DBNull.Value;
        }

        return parameter;
    }
}