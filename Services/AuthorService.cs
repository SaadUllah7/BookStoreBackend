using System;
using BookStoreBackend.Contracts;
using BookStoreBackend.Data;
using BookStoreBackend.Models;

namespace BookStoreBackend.Services
{
    public class AuthorService : IAuthorService
    {
        private BookstoreDbContext _dbContext;
        public AuthorService(BookstoreDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public IEnumerable<AuthorDto> GetAuthors() => _dbContext.Authors.Select(x => new AuthorDto{
            Id = x.Id,
            Name = x.Name
        }).ToList();

        public AuthorDto GetAuthorById(int id) => _dbContext.Authors.Where(b => b.Id == id).Select(x => new AuthorDto
        {
            Id = x.Id,
            Name = x.Name

        }).First();

        public async Task<AuthorDto> AddAuthor(AuthorDto author)
        {
            try
            {
                var newAuthor = new Author { Name = author.Name };
                _dbContext.Authors.Add(newAuthor);
                await _dbContext.SaveChangesAsync();
                
                return GetAuthorById(newAuthor.Id);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public async Task<bool> DeleteAuthor(int id){
            var author =  _dbContext.Authors.FirstOrDefault(b => b.Id == id);
            
            if(_dbContext.Books.Any(x => x.AuthorId == id)){
                throw new GraphQLException("Cannot delete Author, as it already assigned to a Book");
            }


            _dbContext.Authors.Remove(author);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<AuthorDto> UpdateAuthor(AuthorDto author){
            var existingAuthor =  _dbContext.Authors.FirstOrDefault(b => b.Id == author.Id);
            
            existingAuthor.Name = author.Name;

            _dbContext.Authors.Update(existingAuthor);
            await _dbContext.SaveChangesAsync();
            return GetAuthorById(author.Id);
        }
    }
}
