using graphQLTest.Data;
using graphQLTest.Entities;
using graphQLTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace graphQLTest.Services
{
    public class AuthorService : IAuthorService
    {
        private readonly AppDbContext _context;

        public AuthorService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Author>> GetAll()
        {
            return await _context.Authors.Include(a=>a.Books).ToListAsync();
        }

        public async Task<Author> GetById(int authorId)
        {
            return await _context.Authors.Include(a=>a.Books).AsNoTracking().Where(x => x.Id == authorId).FirstOrDefaultAsync();
        }

        public async Task<IEnumerable<Author>> GetManyByIds(IReadOnlyList<int> authorsIds)
        {
            return await _context.Authors
                .Where(i => authorsIds.Contains(i.Id))
                .ToListAsync();
        }

        public async Task<Author> Create(Author author)
        {
            var data = new Author
            {
                Id = author.Id,
                Name = author.Name
            };

            await _context.Authors.AddAsync(data);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<Author> Update(Author author)
        {
            _context.Authors.Update(author);
            await _context.SaveChangesAsync();

            return author;
        }

        public async Task<bool> Delete(int id)
        {
            Author author = await this.GetById(id);

            _context.Authors.Remove(author);

            await _context.SaveChangesAsync();

            return true;
        }
    }
}
