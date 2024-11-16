using System;
using BookStoreBackend.Contracts;
using BookStoreBackend.Services;

namespace BookStoreBackend.GraphQL.Mutations
{
    [MutationType]
    public class AuthorMutation
    {
        private readonly IAuthorService _service;

        public AuthorMutation(IAuthorService service)
        {
            _service = service;
        }

        public async Task<AuthorDto> AddAuthor(string name)
        {
            return await _service.AddAuthor(new AuthorDto { Name = name });
        }

        public async Task<AuthorDto> UpdateAuthor(AuthorDto author)
        {
            return await _service.UpdateAuthor(author);
        }

        public async Task<bool> DeleteAuthor(int authorId)
        {
            return await _service.DeleteAuthor(authorId);
        }
    }
}
