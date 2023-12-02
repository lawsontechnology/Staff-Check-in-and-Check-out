using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ADO_Project.Core.Domain.Entities;

namespace ADO_Project.Core.Application.Interfaces.Repositories
{
    public interface ICompanyRepository
    {
        Company Create(Company entity);
        Company Update(Company entity);
        Company Get(string id);
        Company GetByRegNum(string regNumber);
        ICollection<Company> GetAll();
    }
}