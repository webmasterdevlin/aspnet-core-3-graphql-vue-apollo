using System;
using System.Collections.Generic;
using AspNetCoreVueStarter.Entities;

namespace AspNetCoreVueStarter.Contracts
{
    public interface IOwnerRepository
    {
        IEnumerable<Owner> GetAll();
        Owner GetById(Guid id);
        Owner CreateOwner(Owner owner);
        void DeleteOwner(Owner owner);
        Owner UpdateOwner(Owner dbOwner, Owner owner);
    }
}