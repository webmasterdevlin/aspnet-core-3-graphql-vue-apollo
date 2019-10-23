using AspNetCoreVueStarter.Entities;
using GraphQL.Types;

namespace AspNetCoreVueStarter.GraphQL.GraphQLTypes
{
    public class AccountType : ObjectGraphType<Account>
    {
        public AccountType()
        {
            Field(a => a.Id, type: typeof(IdGraphType)).Description("Id property from the account object.");
            Field(a => a.Description).Description("Description property from the account object.");
            Field(a => a.OwnerId, type: typeof(IdGraphType)).Description("OwnerId property from the account object.");
            Field<AccountTypeEnumType>("Type", "Enumeration for the account type object");
        }
    }
}