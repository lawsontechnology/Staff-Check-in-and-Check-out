using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Domain.Entities
{
    public class Role:AuditableEntities
    {
        public string Name { get; set; } = default!;
        public string Description { get; set; } = default!;
    }
}