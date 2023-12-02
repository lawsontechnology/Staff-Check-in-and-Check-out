using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Domain.Entities
{
    public class Profile:AuditableEntities
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Image { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string StaffNumber {get; set;} = default!;
        public string Dob { get; set; } = default!;
        public string AddressId { get; set; } = default!;
        public User User { get; set; } = default!;
    }
}