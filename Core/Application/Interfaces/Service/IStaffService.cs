using ADO_Project.Core.Application.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Project.Core.Application.Interfaces.Service
{
    public interface IStaffService
    {
        StaffDtos TimeIn(StaffTimeInRequest  request);
        StaffDtos TimeOut(StaffTimeOutRequest request);
        StaffDtos Get(string id);
        List<StaffDtos> GetAll();
    }
}
