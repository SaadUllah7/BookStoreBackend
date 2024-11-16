using System;

namespace BookStoreBackend.Contracts
{
    public interface IAuthorService
    {
        public IEnumerable<AuthorDto> GetAuthors();

        public AuthorDto GetAuthorById(int id);

        public Task<AuthorDto> AddAuthor(AuthorDto author);

        public Task<bool> DeleteAuthor(int id);

        public Task<AuthorDto> UpdateAuthor(AuthorDto author);
    }
}
