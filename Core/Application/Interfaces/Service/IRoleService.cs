using ADO_Project.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Project.Core.Application.Interfaces.Service
{
    public interface IRoleService
    {
        RoleDtos Get(string id);
        List<RoleDtos> GetAll();
    }
}
