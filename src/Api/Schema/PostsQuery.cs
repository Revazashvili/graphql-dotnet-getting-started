using GraphQL;

namespace Api.Schema;

public class AutoPostsQuery
{
    public static Task<IEnumerable<Post>> Posts([FromServices] IPostsClient postsClient) => postsClient.GetAsync();
    public static Task<Post> Post(int id, [FromServices] IPostsClient postsClient) => postsClient.GetByIdAsync(id);
}