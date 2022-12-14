using System.Reflection;
using Api;
using Api.Schema;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.SystemTextJson;
using GraphQL.Types;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(b => b
    .AddHttpMiddleware<ISchema>()
    .AddSchema<PostsSchema>()
    .AddErrorInfoProvider(options => options.ExposeExceptionStackTrace = builder.Environment.IsDevelopment())
    .AddGraphTypes(Assembly.GetExecutingAssembly())
    .AddSystemTextJson());

builder.Services.AddRefitClient<IPostsClient>()
    .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com"));

var app = builder.Build();

app.UseGraphQL<ISchema>();
app.UseGraphQLPlayground();

await app.RunAsync();