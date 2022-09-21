using graphQLTest.Data;
using graphQLTest.Entities;
using graphQLTest.Services;
using graphQLTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Net;

namespace graphQLTest.GraphQL.Queries.Books
{
    [ExtendObjectType(OperationTypeNames.Query)]
    public class BookQuery
    {
        private readonly IBookService _bookService;

        public BookQuery(IBookService bookService)
        {
            _bookService = bookService;
        }   

        [GraphQLName("books")]

        public async Task<IEnumerable<Book>> GetAllBooks()
        {
            return await _bookService.GetAll();
        }

        [GraphQLName("book")]
        public async Task<Book> GetBookByIdAsync(int id)
        {
            Book b = await _bookService.GetById(id);

            if (b == null)
            {
                return null;
            }

            //return new BookType()
            //{
            //    Id = b.Id,
            //    Title = b.Title,
            //    AuthorId = b.AuthorId,
            //    Author = b.Author
            //};

            return b;
        }
    }
}
