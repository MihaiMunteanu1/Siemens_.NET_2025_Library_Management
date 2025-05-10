namespace BooksManagement.model;

[Serializable]
public abstract class Entity<TId>
{ 
    public TId Id { get; set; }
}