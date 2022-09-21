using graphQLTest.Entities;

namespace graphQLTest.Services.Interfaces
{
    public interface IAuthorService
    {
        Task<IEnumerable<Author>> GetAll();

        Task<Author> GetById(int bookId);

        Task<Author> Create(Author author);

        Task<Author> Update(Author author);

        Task<bool> Delete(int id);

        Task<IEnumerable<Author>> GetManyByIds(IReadOnlyList<int> authorsIds);

    }
}
