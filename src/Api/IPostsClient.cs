using Refit;

namespace Api;

public interface IPostsClient
{
    [Get("/posts")]
    Task<IEnumerable<Post>> GetAsync();

    [Get("/posts/{id}")]
    Task<Post> GetByIdAsync(int id);

    [Post("/posts")]
    Task<Post> InsertAsync([Body] Post post);
}