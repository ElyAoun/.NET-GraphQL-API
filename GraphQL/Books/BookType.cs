using graphQLTest.Entities;

namespace graphQLTest.GraphQL.Queries.Books
{
    public class BookType
    {
        //protected override void Configure(IObjectTypeDescriptor<Book> descriptor)
        //{
        //    descriptor.BindFields(BindingBehavior.Implicit);

        //    //descriptor.Field(c => c.Id).Description("Book Id");

        //    //descriptor.Field(c => c.Id).Description("Book Id");

        //}

        [GraphQLName("BookID")]
        public int Id { get; set; }

        [GraphQLName("BookTitle")]
        public string Title { get; set; }

        public Author Author { get; set; }

        [IsProjected(true)]
        public int AuthorId { get; set; }

        [GraphQLNonNullType]
        //public async Task<AuthorType> Instructor([Service] AuthorDataLoader authorDataLoader)
        //{
        //    return await authorDataLoader.LoadAsync(AuthorId, CancellationToken.None);
        //}

        [GraphQLName("QueryDate")]
        public DateTime QueryDate()
        {
            return DateTime.Now;
        }

        [GraphQLName("Nbr")]
        public int nbr()
        {
            return 3;
        }
    }
}
