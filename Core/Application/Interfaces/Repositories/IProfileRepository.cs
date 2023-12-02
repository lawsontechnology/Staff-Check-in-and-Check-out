using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ADO_Project.Core.Domain.Entities;

namespace ADO_Project.Core.Application.Interfaces.Repositories
{
    public interface IProfileRepository
    {
        Profile Create(Profile entity);
        Profile Update(Profile entity);
        Profile Get(string id);
        Profile GetByStaffNumber(string staffNumber);
        ICollection<Profile> GetAll();
    }
}