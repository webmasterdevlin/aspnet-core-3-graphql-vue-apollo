using AspNetCoreVueStarter.GraphQL.GraphQLQueries;
using GraphQL;
using GraphQL.Types;

namespace AspNetCoreVueStarter.GraphQL.GraphQLSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<AppQuery>();
            Mutation = resolver.Resolve<AppMutation>();
        }
    }
}