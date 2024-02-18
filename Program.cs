using Demo.Api;
using Demo.Api.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddScoped<BooksService>();
builder.Services.AddDbContext<DemoDbContext>(options => options.UseInMemoryDatabase("demoDb"));
builder.Services.AddGraphQLServer().AddQueryType<Query>().AddProjections();

var app = builder.Build();
app.MapGraphQL();
app.Run();

public class Query
{
    [DemoMiddleware]
    [UsePaging(MaxPageSize = 2)]
    [UseProjection]
    public IQueryable<Book> GetBooks([Service] BooksService service)
    {
        return service.GetBooks().Include(b => b.Author);
    }
}

public class BooksService
{
    private readonly DemoDbContext _dbContext;

    public BooksService(DemoDbContext dbContext)
    {
        _dbContext = dbContext;
        _dbContext.Database.EnsureCreated();
    }

    public IQueryable<Book> GetBooks() => _dbContext.Books.AsQueryable();
}