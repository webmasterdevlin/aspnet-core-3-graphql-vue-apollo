using AspNetCoreVueStarter.Entities;
using GraphQL.Types;

namespace AspNetCoreVueStarter.GraphQL.GraphQLTypes
{
    public class AccountTypeEnumType : EnumerationGraphType<TypeOfAccount>
    {
        public AccountTypeEnumType()
        {
            Name = "Type";
            Description = "Enumeration for the account type object";
        }
    }
}