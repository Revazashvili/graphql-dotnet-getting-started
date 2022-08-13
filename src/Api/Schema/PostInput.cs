using GraphQL.Types;

namespace Api.Schema;

public class PostInput : AutoRegisteringInputObjectGraphType<Post>
{
    public PostInput()
    {
        Name = "PostInput";
    }
}