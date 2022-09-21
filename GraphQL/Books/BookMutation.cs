using graphQLTest.Data;
using graphQLTest.Entities;
using graphQLTest.Services.Interfaces;
using HotChocolate.Execution.Processing;
using HotChocolate.Subscriptions;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace graphQLTest.GraphQL.Queries.Books
{
    [ExtendObjectType(OperationTypeNames.Mutation)]
    public class BookMutation
    {
        private readonly IBookService _bookService;

        public BookMutation(IBookService bookService)
        {
            _bookService = bookService;
        }

        public async Task<Book> AddBookAsync(Book newBook)
        {
            return await _bookService.Create(newBook);
        }


        [GraphQLName("bookUpdate")]
        public async Task<Book> UpdateBookAsync(int id, Book newBook)
        {
            Book book = await _bookService.Update(id, newBook);

            return book;
        }

        public async Task<bool> DeleteBookAsync(int id)
        {
            return await _bookService.Delete(id);
        }
    }
}
