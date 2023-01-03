// See https://aka.ms/new-console-template for more information

using ContosoUniversity.Data;
using EfCoreSample.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Npgsql;

// var services = new ServiceCollection();
//
// services.AddDbContext<LibraryContext>(options =>
//     options.UseNpgsql("Server=127.0.0.1;Port=5432;Database=LibraryEfCoreSample;User Id=postgres;Password=!@#123qwe;"));
//
// var serviceProvider = services.BuildServiceProvider();


// var libraryContext = serviceProvider.GetService<LibraryContext>();

var optionsBuilder = new DbContextOptionsBuilder<LibraryContext>()
    .UseNpgsql("Server=127.0.0.1;Port=5432;Database=LibraryEfCoreSample;User Id=postgres;Password=!@#123qwe;");

var libraryContext = new LibraryContext(optionsBuilder.Options);

libraryContext.Database.EnsureCreated();

var newBook = new Book()
{
    Name = "1984",
    Author = "George Orwell"
};

await libraryContext.Books.AddAsync(newBook);

await libraryContext.SaveChangesAsync();

var books = libraryContext.Books
    .Where(x => x.Author == "George Orwell")
    .ToList();

Console.ReadLine();
