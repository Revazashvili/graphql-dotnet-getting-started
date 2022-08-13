using GraphQL;
using GraphQL.Types;

namespace Api.Schema;

public class PostsQuery : ObjectGraphType<object>
{
    public PostsQuery(IPostsClient postsClient)
    {
        Name = nameof(PostsQuery);
        
        FieldAsync<ListGraphType<AutoRegisteringObjectGraphType<Post>>>("posts",
            resolve: async _ => await postsClient.GetAsync());
        
        FieldAsync<AutoRegisteringObjectGraphType<Post>>("post",
            arguments:new QueryArguments(new QueryArgument<NonNullGraphType<IntGraphType>> { Name = "id" }),
            resolve: async context => await postsClient.GetByIdAsync(context.GetArgument<int>("id")));
    }
}