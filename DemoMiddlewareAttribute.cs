using System.Diagnostics;
using System.Reflection;
using System.Runtime.CompilerServices;
using Demo.Api.Models;
using HotChocolate.Types.Descriptors;
using HotChocolate.Types.Pagination;

namespace Demo.Api;

public class DemoMiddlewareAttribute : ObjectFieldDescriptorAttribute
{
    public DemoMiddlewareAttribute([CallerLineNumber] int order = 0)
    {
        Order = order;
    }

    protected override void OnConfigure(
        IDescriptorContext context,
        IObjectFieldDescriptor descriptor,
        MemberInfo member)
    {
        descriptor.Use(next => async middlewareContext =>
        {
            await next(middlewareContext);

            var result = middlewareContext.Result as Connection<Book>;

            var firstBook = result.Edges.First().Node;

            // Because we have set [IsProjected] for Id property on Book class this will work for the demo query.
            Debug.Assert(firstBook.Id == 1);

            // Impossible to get firstBook.Author here, because [IsProjected] does not work for Author.
            // Debug.Assert(firstBook.Author != null);
        });
    }
}