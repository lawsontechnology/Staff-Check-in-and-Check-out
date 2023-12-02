using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ADO_Project.Core.Domain.Entities;

namespace ADO_Project.Core.Application.Interfaces.Repositories
{
    public interface IAddressRepository
    {
        Address Get(string id);
        Address Create(Address entity);
        Address Update(Address entity);       
        ICollection<Address> GetAll();
    }
}