namespace Api.Schema;

using GraphQL.Types;

public class PostsSchema : Schema
{
    public PostsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetService<PostsQuery>()!;
        Mutation = serviceProvider.GetService<PostsMutation>()!;
    }
}