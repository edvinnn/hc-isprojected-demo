using Demo.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Demo.Api;

public class DemoDbContext(DbContextOptions options) : DbContext(options)
{
    public DbSet<Book> Books { get; set; }
    public DbSet<Author> Authors { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Author>().HasData(new Author
        {
            Id = 1,
            Name = "John Book"
        });
        modelBuilder.Entity<Book>().HasData(new Book
        {
            Id = 1,
            Title = "Book about booking bookable objects",
            AuthorId = 1
        });
    }
}