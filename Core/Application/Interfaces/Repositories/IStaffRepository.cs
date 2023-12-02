using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ADO_Project.Core.Domain.Entities;

namespace ADO_Project.Core.Application.Interfaces.Repositories
{
    public interface IStaffRepository
    {
        Staff Create(Staff entity);
        Staff Update(Staff entity);
        Staff Get(string id);
        ICollection<Staff> GetAll();
    }
}