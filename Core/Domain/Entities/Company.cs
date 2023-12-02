using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Domain.Entities
{
    public class Company:AuditableEntities
    {
        public string Name { get; set; } = default!;
        public string CACRegNumber { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public ICollection<Staff> Staffs { get; set; } = new HashSet<Staff>();
    }
}