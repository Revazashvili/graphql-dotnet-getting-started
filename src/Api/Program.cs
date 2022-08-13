using System.Reflection;
using Api.Schema;
using GraphQL;
using GraphQL.MicrosoftDI;
using GraphQL.Server;
using GraphQL.Server.Ui.Playground;
using GraphQL.SystemTextJson;
using GraphQL.Types;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddGraphQL(b => b
    .AddHttpMiddleware<ISchema>()
    .AddSchema<PostsSchema>()
    .AddGraphTypes(Assembly.GetExecutingAssembly())
    .AddSystemTextJson());

builder.Services.AddHttpContextAccessor();

var app = builder.Build();

app.UseGraphQL<ISchema>();
app.UseGraphQLPlayground(new PlaygroundOptions
{
    SchemaPollingEnabled = false
});

await app.RunAsync();