using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AspNetCoreVueStarter.Contracts;
using AspNetCoreVueStarter.Entities;
using AspNetCoreVueStarter.Entities.Context;
using Microsoft.EntityFrameworkCore;

namespace AspNetCoreVueStarter.Repository
{
    public class AccountRepository : IAccountRepository
    {
        private readonly ApplicationContext _context;

        public AccountRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Account> GetAllAccountsPerOwner(Guid ownerId)
        {
            return _context.Accounts.Where(a => a.OwnerId.Equals(ownerId)).ToList();
        }

        public async Task<ILookup<Guid, Account>> GetAccountByOwnerIds(IEnumerable<Guid> ownerIds)
        {
            var accounts = await _context.Accounts.Where(a => ownerIds.Contains(a.OwnerId)).ToListAsync();
            return accounts.ToLookup(x => x.OwnerId);
        }
    }
}