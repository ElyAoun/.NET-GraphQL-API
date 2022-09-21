using graphQLTest.Data;
using graphQLTest.GraphQL.Authors;
using graphQLTest.GraphQL.Queries.Authors;
using graphQLTest.GraphQL.Queries.Books;
using graphQLTest.Services;
using graphQLTest.Services.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;


var policyName = "_myAllowSpecificOrigins";

var builder = WebApplication.CreateBuilder(args);

string connectionString = builder.Configuration.GetConnectionString("DBConnection");

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: policyName,
                      builder =>
                      {
                          builder
                            .WithOrigins("http://localhost:3000") // specifying the allowed origin (React)
                            .WithMethods("GET") // defining the allowed HTTP method
                            .WithMethods("POST")
                            .AllowAnyHeader(); // allowing any header to be sent
                      });
});


builder.Services.AddDbContext<AppDbContext>(options => options
           .UseSqlServer(builder.Configuration.GetConnectionString("DBConnection"))
           
           );

builder.Services
    .AddGraphQLServer()
    .AddQueryType()
    .AddMutationType()
    .AddTypeExtension<BookQuery>()
    .AddTypeExtension<AuthorQuery>()
    .AddTypeExtension<BookMutation>()
    .AddTypeExtension<AuthorMutation>();

builder.Services.AddScoped<BookQuery>();
builder.Services.AddScoped<BookMutation>();
builder.Services.AddScoped<AuthorQuery>();
builder.Services.AddScoped<AuthorMutation>();



builder.Services.AddScoped<IBookService, BookService>();
builder.Services.AddScoped<IAuthorService, AuthorService>();



var app = builder.Build();

app.UseCors(policyName);

app.MapGraphQL();

app.Run();
