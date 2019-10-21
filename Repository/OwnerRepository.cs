using System;
using System.Collections.Generic;
using System.Linq;
using AspNetCoreVueStarter.Contracts;
using AspNetCoreVueStarter.Entities;
using AspNetCoreVueStarter.Entities.Context;

namespace AspNetCoreVueStarter.Repository
{
    public class OwnerRepository : IOwnerRepository
    {
        private readonly ApplicationContext _context;

        public OwnerRepository(ApplicationContext context)
        {
            _context = context;
        }

        public IEnumerable<Owner> GetAll() => _context.Owners.ToList();
        
        public Owner GetById(Guid id)
        {
            return _context.Owners.SingleOrDefault(o => o.Id.Equals(id));
        }

        public Owner CreateOwner(Owner owner)
        {
            owner.Id = Guid.NewGuid();
            _context.Add(owner);
            _context.SaveChanges();
            return owner;
        }

        public void DeleteOwner(Owner owner)
        {
            _context.Remove(owner);
            _context.SaveChanges();
        }
    }
}