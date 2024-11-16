using System;
using BookStoreBackend.Contracts;
using BookStoreBackend.Services;

namespace BookStoreBackend.GraphQL.Queries
{
    [QueryType]
    public class AuthorQuery
    {
        private readonly IAuthorService _service;

        public AuthorQuery(IAuthorService service)
        {
            _service = service;
        }

        public IEnumerable<AuthorDto> GetAuthors() => _service.GetAuthors();

        public AuthorDto GetAuthorById(int id) => _service.GetAuthorById(id);
    }
}
