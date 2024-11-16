using BookStoreBackend.Contracts;
using BookStoreBackend.Services;

namespace BookStoreBackend.GraphQL.Queries
{
    [QueryType]
    public class BookQuery
    {
        private readonly IBookService _service;

        public BookQuery(IBookService service)
        {
            _service = service;
        }

        public IEnumerable<BookDto> GetBooks() => _service.GetBooks();

        public BookDto GetBookById(int id) => _service.GetBookById(id);
    }
}
