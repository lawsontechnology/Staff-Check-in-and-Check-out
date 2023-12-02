using ADO_Project.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Application.Dtos
{
    public class UserDtos
    {
        public string Id { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
        public string ProfileId { get; set; } = default!;
        public string RoleId { get; set; } = default!;
        public Staff Staff { get; set; } = default!;
    }

    public class AttendanceRequestModel
    {
        public string StaffNumber { get; set; } = default!;

    }
    public class AttendanceResponseModel
    {
        public string RoleName { get; set; } = default!;
    }

}