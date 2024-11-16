using BookStoreBackend.Contracts;
using BookStoreBackend.Data;
using BookStoreBackend.GraphQL.Mutations;
using BookStoreBackend.GraphQL.Queries;
using BookStoreBackend.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<BookstoreDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services
    .AddGraphQLServer()
    .AddQueryType(d => d.Name("Query"))
    .AddTypeExtension<BookQuery>()
    .AddTypeExtension<AuthorQuery>()
    .AddMutationType(x => x.Name("Mutation"))
    .AddTypeExtension<BookMutation>()
    .AddTypeExtension<AuthorMutation>();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});

builder.Services.AddScoped<BookQuery>();
builder.Services.AddScoped<BookMutation>();
builder.Services.AddScoped<AuthorQuery>();
builder.Services.AddScoped<AuthorMutation>();

builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("AllowAll");
app.UseAuthorization();

app.MapControllers();
app.MapGraphQL();

app.Run();
