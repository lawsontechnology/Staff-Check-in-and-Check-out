using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Domain.Entities
{
    public class User:AuditableEntities
    {
        public string StaffNumber { get; set; } = default!;
        public string ProfileId { get; set; } = default!;
        public string RoleId {get; set;} = default!;
        public Staff Staff { get; set; } = default!;
    }
}