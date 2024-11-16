using System;
using System.Configuration;
using BookStoreBackend.Models;
using Microsoft.EntityFrameworkCore;

namespace BookStoreBackend.Data
{
public partial class BookstoreDbContext : DbContext
{
    public IConfiguration _configuration;
    public BookstoreDbContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public BookstoreDbContext(DbContextOptions<DbContext> options, IConfiguration configuration)
        : base(options)
    {
            _configuration = configuration;
    }

    public virtual DbSet<Author> Authors { get; set; }

    public virtual DbSet<Book> Books { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        => optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DefaultConnection"));// "Server=localhost;Database=BookstoreDb;User Id=sa;Password=abc123$%;MultipleActiveResultSets=true;TrustServerCertificate=true");

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Book>()
            .HasOne(b => b.Author)
            .WithMany(a => a.Books)
            .HasForeignKey(b => b.AuthorId);
    }
}

}
