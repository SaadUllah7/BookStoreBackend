using BookStoreBackend.Contracts;
using BookStoreBackend.Data;
using BookStoreBackend.Models;

namespace BookStoreBackend.Services
{
    public class BookService : IBookService
    {
        private BookstoreDbContext _dbContext;
        public BookService(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<BookDto> GetBooks() => _dbContext.Books.Select(x => new BookDto
        {
            Id = x.Id,
            Title = x.Title,
            AuthorId = x.AuthorId ?? 0,
            AuthorName = x.Author == null ? string.Empty : x.Author.Name
        }).ToList();

        public BookDto GetBookById(int id) => _dbContext.Books.Where(b => b.Id == id).Select(x => new BookDto
        {
            Id = x.Id,
            Title = x.Title,
            AuthorId = x.AuthorId ?? 0,
            AuthorName = x.Author == null ? string.Empty : x.Author.Name
        }).First();

        public async Task<BookDto> AddBook(BookDto book)
        {
            try
            {
                var author = _dbContext.Authors.FirstOrDefault(a => a.Id == book.AuthorId);
                if (author == null)
                {
                    throw new GraphQLException("Author does not exists");
                }

                var newbook = new Book { Title = book.Title, Author = author };

                _dbContext.Books.Add(newbook);
                await _dbContext.SaveChangesAsync();

                return GetBookById(newbook.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteBook(int id)
        {
            var book = _dbContext.Books.FirstOrDefault(b => b.Id == id);

            _dbContext.Books.Remove(book);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<BookDto> UpdateBook(BookDto book)
        {
            var existingbook = _dbContext.Books.FirstOrDefault(b => b.Id == book.Id);

            existingbook.Title = book.Title;
            existingbook.AuthorId = book.AuthorId;

            _dbContext.Books.Update(existingbook);
            await _dbContext.SaveChangesAsync();
            
            return GetBookById(book.Id);
        }
    }
}