using ADO_Project.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Project.Core.Application.Interfaces.Service
{
    public interface IProfileService
    {
        ProfileDtos Create(RegisterRequestModel register);
        ProfileDtos Get(string id);
        ProfileDtos GetByStaffNumber(string StaffNumber);
        List<ProfileDtos> GetAll();
    }
}
