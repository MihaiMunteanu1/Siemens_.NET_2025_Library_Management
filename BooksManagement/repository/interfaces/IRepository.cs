using BooksManagement.model;

namespace BooksManagement.repository.interfaces;

/**
 * All methods in this interface return a Task , which are part of the Task-based Asynchronous Pattern (TAP) in .NET.
 * A Task represents an asynchronous operation that may not have completed yet.
 * By returning a Task, these methods can be awaited, allowing asynchronous execution without blocking the calling thread.
 */


/**
 * Generic repository interface for performing CRUD operations on entities.
 *
 * @typeparam TId The type of the entity's identifier.
 * @typeparam TEntity The type of the entity.
 */
public interface IRepository<TId, TEntity> where TEntity : Entity<TId>
{
    /**
     * Retrieves an entity by its identifier asynchronously.
     *
     * @param id The identifier of the entity.
     * @return A task that represents the asynchronous operation. The task result contains the entity.
     */
    Task<TEntity> GetByIdAsync(TId id);

    /**
     * Retrieves all entities asynchronously.
     *
     * @return A task that represents the asynchronous operation. The task result contains a collection of entities.
     */
    Task<IEnumerable<TEntity>> GetAllAsync();

    /**
     * Creates a new entity asynchronously.
     *
     * @param entity The entity to create.
     * @return A task that represents the asynchronous operation. The task result contains the created entity.
     */
    Task<TEntity> CreateAsync(TEntity entity);

    /**
     * Updates an existing entity asynchronously.
     *
     * @param entity The entity to update.
     * @return A task that represents the asynchronous operation.
     */
    Task UpdateAsync(TEntity entity);

    /**
     * Deletes an entity by its identifier asynchronously.
     *
     * @param id The identifier of the entity to delete.
     * @return A task that represents the asynchronous operation.
     */
    Task DeleteAsync(TId id);
}