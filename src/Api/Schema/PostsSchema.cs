using GraphQL.Types;

namespace Api.Schema;

public class PostsSchema : GraphQL.Types.Schema
{
    public PostsSchema(IServiceProvider serviceProvider) : base(serviceProvider)
    {
        Query = new AutoRegisteringObjectGraphType<PostsQuery>();
        Mutation = new AutoRegisteringObjectGraphType<PostsMutation>();
    }
}