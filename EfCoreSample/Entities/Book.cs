namespace EfCoreSample.Entities;

public class Book
{
    public int Id { get; init; }
    public required string Name { get; init; }
    public required string Author { get; init; }
}