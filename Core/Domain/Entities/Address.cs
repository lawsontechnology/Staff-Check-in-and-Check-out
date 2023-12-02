using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Domain.Entities
{
    public class Address:AuditableEntities
    {
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public Profile Profile { get; set; } = default!;
    }
}