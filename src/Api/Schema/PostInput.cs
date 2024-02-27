namespace Api.Schema;

public record PostInput(int Id, string Title, string Body, int UserId)
{
    public static implicit operator Post(PostInput postInput) =>
        new Post(postInput.Id, postInput.Title, postInput.Body, postInput.UserId);
}