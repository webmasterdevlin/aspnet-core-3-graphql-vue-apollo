using System;
using System.Collections.Generic;
using AspNetCoreVueStarter.Contracts;
using AspNetCoreVueStarter.Entities;
using GraphQL.DataLoader;
using GraphQL.Types;

namespace AspNetCoreVueStarter.GraphQL.GraphQLTypes
{
    public class OwnerType : ObjectGraphType<Owner>
    {
        public OwnerType(IAccountRepository repository, IDataLoaderContextAccessor dataLoader)
        {
            Field(o => o.Id, type: typeof(IdGraphType)).Description("Id property from the owner object.");
            Field(o => o.Name).Description("Name property from the owner object.");
            Field(o => o.Address).Description("Address property from the owner object.");
            Field<ListGraphType<AccountType>>("accounts",
                resolve: context =>
                {
                    var key = "GetAccountsByOwnerIds";
                    IDataLoader<Guid, IEnumerable<Account>> loader = dataLoader.Context.GetOrAddCollectionBatchLoader<Guid, Account>(key, repository.GetAccountByOwnerIds);
                    
                    return loader.LoadAsync(context.Source.Id);
                });
        }
    }
}