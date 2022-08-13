using GraphQL;
using GraphQL.Types;

namespace Api.Schema;

public class PostsMutation : ObjectGraphType
{
    public PostsMutation()
    {
        Name = nameof(PostsMutation);
        
        FieldDelegate<ListGraphType<StringGraphType>>("userNames",
            resolve: new Func<IResolveFieldContext, IEnumerable<string>>(context => new[]
            {
                "1",
                "2",
                "3"
            }));
    }
}