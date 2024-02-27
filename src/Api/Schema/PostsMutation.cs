using GraphQL;

namespace Api.Schema;

public class AutoPostsMutation
{
    public static Task<Post> Insert(PostInput postInput, [FromServices] IPostsClient postsClient) =>
        postsClient.InsertAsync(postInput);
}