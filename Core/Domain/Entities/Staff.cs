using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Domain.Entities
{
    public class Staff:AuditableEntities
    {
        public string StaffNumber { get; set; } = default!;
        public DateTime TimeIn {get; set;} 
        public DateTime TimeOut {get; set;}
    }
}