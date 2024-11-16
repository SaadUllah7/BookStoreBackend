using BookStoreBackend.Contracts;
using BookStoreBackend.Services;

namespace BookStoreBackend.GraphQL.Mutations
{
     [MutationType]
    public class BookMutation
    {
        private readonly IBookService _service;

        public BookMutation(IBookService service)
        {
            _service = service;
        }

        public async Task<BookDto> AddBook(string title, int authorId)
        {
            return await _service.AddBook(new BookDto { Title = title, AuthorId = authorId });
        }

        public async Task<BookDto> UpdateBook(BookDto book)
        {
            return await _service.UpdateBook(book);
        }

        public async Task<bool> DeleteBook(int bookId)
        {
            return await _service.DeleteBook(bookId);
        }
    }
}
