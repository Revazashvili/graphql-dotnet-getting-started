
using GraphQL;

namespace Api.Schema;

public class PostsMutation
{
    public static Task<Post> Insert([FromServices] IPostsClient postsClient, PostInput post) =>
        postsClient.InsertAsync(post);
}