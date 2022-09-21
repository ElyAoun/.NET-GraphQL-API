using graphQLTest.Entities;

namespace graphQLTest.GraphQL.Queries.Authors
{
    public class AuthorType
    {
        [GraphQLName("AuthorID")]
        public int Id { get; set; }

        [GraphQLName("AuthorName")]
        public string Name { get; set; }

        [GraphQLName("books")]
        public ICollection<Book> Books { get; set; }
    }
}
