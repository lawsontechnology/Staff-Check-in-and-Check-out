using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ADO_Project.Core.Domain.Entities;

namespace ADO_Project.Core.Application.Interfaces.Repositories
{
    public interface IRoleRepository
    {
        Role Create(Role entity);
        Role Update(Role entity);
        Role Get(string id);
        Role GetByName(string name);
        List<Role> GetAll();
    }
}