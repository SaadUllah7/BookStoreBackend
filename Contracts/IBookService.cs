using System;

namespace BookStoreBackend.Contracts
{
    public interface IBookService
    {
        public IEnumerable<BookDto> GetBooks();

        public BookDto GetBookById(int id);
        public  Task<BookDto> AddBook(BookDto book);
        public  Task<bool> DeleteBook(int id);

        public  Task<BookDto> UpdateBook(BookDto book);
    
    }
}
