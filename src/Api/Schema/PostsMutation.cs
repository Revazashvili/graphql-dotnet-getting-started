using GraphQL;
using GraphQL.Types;

namespace Api.Schema;

public class PostsMutation : ObjectGraphType
{
    public PostsMutation(IPostsClient postsClient)
    {
        Name = nameof(PostsMutation);

        FieldAsync<AutoRegisteringObjectGraphType<Post>>("insert",
            arguments: new QueryArguments(
                new QueryArgument<PostInput> { Name = "post" }),
            resolve: async context => await postsClient.InsertAsync(context.GetArgument<Post>("post")));
    }
}