using System.ComponentModel.DataAnnotations;

namespace graphQLTest.Entities
{
    public class Author
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public virtual ICollection<Book>? Books { get; set; }
    }
}
