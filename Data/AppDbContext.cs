using graphQLTest.Entities;
using Microsoft.EntityFrameworkCore;

namespace graphQLTest.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
            
        }

        public DbSet<Book> Books { get; set; }

        public DbSet<Author> Authors { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>(entity =>
            {
                entity.HasKey(x => x.Id);
                entity.HasOne(x => x.Author).WithMany(x => x.Books).HasForeignKey(x => x.AuthorId);
            });

            modelBuilder.Entity<Author>(entity =>
            {
                entity.HasKey(x => x.Id);
            }
            );
        }
    }
}
