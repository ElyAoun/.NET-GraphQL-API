using graphQLTest.Data;
using graphQLTest.DataLoaders;
using graphQLTest.Entities;
using graphQLTest.Services;
using graphQLTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace graphQLTest.GraphQL.Queries.Authors
{
    [ExtendObjectType(OperationTypeNames.Query)]

    public class AuthorQuery
    {

        private readonly IAuthorService _authorService;

        public AuthorQuery(IAuthorService authorService)
        {
            _authorService = authorService;
        }   

        [GraphQLName("authors")]
        public async Task<IEnumerable<Author>> GetAllAuthors([Service] AppDbContext context)
        {
            return await _authorService.GetAll();
        }

        [GraphQLName("author")]
        public async Task<Author> GetAuthorByIdAsync(int id, AuthorBatchDataLoader dataLoader)
        {
            Author author = await _authorService.GetById(id);

            if (author == null)
            {
                return null;
            }

            return author;
        }
    }
}
