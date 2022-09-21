using graphQLTest.Entities;
using graphQLTest.Services;
using graphQLTest.Services.Interfaces;
using Microsoft.AspNetCore.Authentication;

namespace graphQLTest.GraphQL.Authors
{

    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class AuthorMutation
    {
        private readonly IAuthorService _authorService;

        public AuthorMutation(IAuthorService authorService)
        {
            _authorService = authorService;
        }

        public async Task<Author> AddAuthorAsync(Author newAuthor)
        {
            return await _authorService.Create(newAuthor);
        }

        public async Task<Author> UpdateAuthorAsync(int id, Author newAuthor)
        {
            Author author = await _authorService.GetById(id);

            if (author == null)
            {
                return null;
            }

            author.Name = newAuthor.Name;

            author = await _authorService.Update(newAuthor);

            return author;
        }

        public async Task<bool> DeleteAuthorAsync(int id)
        {
            return await _authorService.Delete(id);
        }

    }
}
