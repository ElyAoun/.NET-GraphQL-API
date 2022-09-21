using graphQLTest.Data;
using graphQLTest.Entities;
using graphQLTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace graphQLTest.Services
{
    public class BookService : IBookService
    {
        //private readonly IDbContextFactory<AppDbContext> _contextFactory;
        private readonly AppDbContext _context;

        //public BookService(IDbContextFactory<AppDbContext> contextFactory)
        //{
        //    _contextFactory = contextFactory;
        //}

        public BookService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Book>> GetAll()
        {
            //await using AppDbContext context = _contextFactory.CreateDbContext();
            //{
            return await _context.Books.Include(b => b.Author).ToListAsync();
            //}
        }

        public async Task<Book> GetById(int bookId)
        {
            //await using AppDbContext context = _contextFactory.CreateDbContext();
            //{
            return await _context.Books.Include(b => b.Author).AsNoTracking().Where(x => x.Id == bookId).FirstOrDefaultAsync();
            //}
        }

        public async Task<Book> Create(Book book)
        {
            //await using AppDbContext context = _contextFactory.CreateDbContext();

            var data = new Book
            {
                Id = book.Id,
                Title = book.Title,
                AuthorId = book.AuthorId,
            };

            await _context.Books.AddAsync(data);
            await _context.SaveChangesAsync();
            
            return book;
        }

        public async Task<Book> Update(int id, Book book)
        {
            Book b = await this.GetById(id);

            if (b == null)
            {
                return null;
            }

            b.Title = book.Title;
            Console.WriteLine(book.AuthorId);
            b.AuthorId = book.AuthorId;
            Console.WriteLine(b.AuthorId);

            Console.WriteLine(b);

            _context.Books.Update(b);
            await _context.SaveChangesAsync();

            return b;

        }

        public async Task<bool> Delete(int id)
        {
            Book book = await this.GetById(id);

            _context.Books.Remove(book);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
