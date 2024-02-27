using System.Reflection;
using Api;
using Api.Schema;
using GraphQL;
using Refit;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(b => b
    .AddAutoSchema<AutoPostsQuery>(schema => schema.WithMutation<AutoPostsMutation>())
    .AddErrorInfoProvider(options => options.ExposeExceptionDetails = builder.Environment.IsDevelopment())
    .AddGraphTypes(Assembly.GetExecutingAssembly())
    .AddSystemTextJson());

builder.Services.AddRefitClient<IPostsClient>()
    .ConfigureHttpClient(httpClient => httpClient.BaseAddress = new Uri("https://jsonplaceholder.typicode.com"));

var app = builder.Build();

app.UseGraphQL();
app.UseGraphQLPlayground();

await app.RunAsync();