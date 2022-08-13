namespace Api.Schema;

public class PostsSchema : GraphQL.Types.Schema
{
    public PostsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = serviceProvider.GetService<PostsQuery>()!;
        Mutation = serviceProvider.GetService<PostsMutation>()!;
    }
}