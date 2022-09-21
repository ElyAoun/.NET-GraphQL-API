using System.ComponentModel.DataAnnotations;

namespace graphQLTest.Entities
{
    public class Book
    {
        [Key]
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual Author? Author { get; set; }

        public int AuthorId { get; set; }
    }
}
