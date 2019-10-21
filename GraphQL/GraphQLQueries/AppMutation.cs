using System;
using AspNetCoreVueStarter.Contracts;
using AspNetCoreVueStarter.Entities;
using AspNetCoreVueStarter.GraphQL.GraphQLTypes;
using GraphQL;
using GraphQL.Types;

namespace AspNetCoreVueStarter.GraphQL.GraphQLQueries
{
    public class AppMutation : ObjectGraphType
    {
        public AppMutation(IOwnerRepository repository)
        {
            Field<OwnerType>("createOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<OwnerInputType>> {Name = "owner"}),
                resolve: context =>
                {
                    var owner = context.GetArgument<Owner>("owner");
                    return repository.CreateOwner(owner);
                }
            );

            Field<StringGraphType>(
                "deleteOwner",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>>
                {
                    Name = "ownerId"
                }),
                resolve: context =>
                {
                    var ownerId = context.GetArgument<Guid>("ownerId");
                    var owner = repository.GetById(ownerId);
                    if (owner == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find owner in db."));
                    }

                    repository.DeleteOwner(owner);
                    return $"The owner with the id: {ownerId} has been deleted";
                }
            );
        }
    }
}