using graphQLTest.Data;
using graphQLTest.Entities;

namespace graphQLTest.Services.Interfaces
{
    public interface IBookService
    {
        Task<IEnumerable<Book>> GetAll();

        Task<Book> GetById(int bookId);

        Task<Book> Create(Book book);

        Task<Book> Update(int id, Book book);

        Task<bool> Delete(int id);
    }
}
