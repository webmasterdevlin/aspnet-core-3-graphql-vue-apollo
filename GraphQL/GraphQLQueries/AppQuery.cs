using System;
using AspNetCoreVueStarter.Contracts;
using AspNetCoreVueStarter.GraphQL.GraphQLTypes;
using GraphQL;
using GraphQL.Types;

namespace AspNetCoreVueStarter.GraphQL.GraphQLQueries
{
    public class AppQuery : ObjectGraphType
    {
        public AppQuery(IOwnerRepository repository)
        {
            Field<ListGraphType<OwnerType>>("owners", resolve: context => repository.GetAll());

            Field<OwnerType>("owner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> {Name = "ownerId"}),
                resolve: context =>
                {
                    if (Guid.TryParse(context.GetArgument<string>("ownerId"), out Guid id))
                        return repository.GetById(id);
                    
                    context.Errors.Add(new ExecutionError("Wrong value for guid"));
                    return null;
                });
        }
    }
}