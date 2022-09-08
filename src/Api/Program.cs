using System.Reflection;
using Api;
using Api.Schema;
using GraphQL;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(b => b
    .AddSchema<PostsSchema>()
    .AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = builder.Environment.IsDevelopment())
    .AddGraphTypes(Assembly.GetExecutingAssembly())
    .AddSystemTextJson());

builder.Services.AddRefitClient<IPostsClient>()
    .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com"));

var app = builder.Build();

app.UseGraphQL();
app.UseDeveloperExceptionPage();
app.UseGraphQLPlayground();

await app.RunAsync();