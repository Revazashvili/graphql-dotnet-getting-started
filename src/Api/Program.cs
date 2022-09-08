using Api;
using Api.Schema;
using GraphQL;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(b => b
    .AddSchema<PostsSchema>()
    .AddAutoClrMappings()
    .AddErrorInfoProvider(options => options.ExposeExceptionDetails = builder.Environment.IsDevelopment())
    .AddSystemTextJson());

builder.Services.AddRefitClient<IPostsClient>()
    .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com"));

var app = builder.Build();

app.UseGraphQL();
app.UseGraphQLPlayground();

await app.RunAsync();