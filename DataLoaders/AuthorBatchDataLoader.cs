using graphQLTest.Entities;
using graphQLTest.Services;
using graphQLTest.Services.Interfaces;
using HotChocolate.Execution.Processing;

namespace graphQLTest.DataLoaders
{
    public class AuthorBatchDataLoader : BatchDataLoader<int, Author>
    {
        private readonly IAuthorService _authorService;

        public AuthorBatchDataLoader(IAuthorService authorService, IBatchScheduler batchScheduler,
                                     DataLoaderOptions options = null) : base(batchScheduler, options)
        {
            _authorService = authorService;
        }

        protected override async Task<IReadOnlyDictionary<int, Author>> LoadBatchAsync(IReadOnlyList<int> keys, CancellationToken cancellationToken)
        {
            IEnumerable<Author> authors = await _authorService.GetManyByIds(keys);
            return authors.ToDictionary(x => x.Id);
        }
    }
}
