using GraphQL;
using GraphQL.Types;

namespace Api.Schema;

public class PostsQuery : ObjectGraphType<object>
{
    public PostsQuery()
    {
        Name = nameof(PostsQuery);
        
        FieldDelegate<ListGraphType<StringGraphType>>("userNames",
            resolve: new Func<IResolveFieldContext, IEnumerable<string>>(context => new[]
            {
                "1",
                "2",
                "3"
            }));
    }
}