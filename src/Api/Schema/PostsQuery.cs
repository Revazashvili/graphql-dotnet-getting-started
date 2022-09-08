using GraphQL;

namespace Api.Schema;

public class PostsQuery
{
    public static Task<IEnumerable<Post>> Posts([FromServices]IPostsClient postsClient) => postsClient.GetAsync();
    public static Task<Post> Post([FromServices]IPostsClient postsClient,int id) => postsClient.GetByIdAsync(id);
}