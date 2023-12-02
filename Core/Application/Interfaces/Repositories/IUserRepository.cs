using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ADO_Project.Core.Domain.Entities;

namespace ADO_Project.Core.Application.Interfaces.Repositories
{
    public interface IUserRepository
    {
        User Create(User entity);
        User Update(User entity);
        User Get(string id);
        User GetByStaffNumber(string staffNumber);
        ICollection<User> GetAll();
    }
}