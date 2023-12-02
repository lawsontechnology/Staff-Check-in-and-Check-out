using ADO_Project.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Application.Dtos
{
    public class CompanyDtos
    {
        public string Id { get; set; } = default!;
        public string Name { get; set; } = default!;
        public string CACRegNumber { get; set; } = default!;
        public string Logo { get; set; } = default!;
        public ICollection<StaffDtos> Staffs { get; set; } = new HashSet<StaffDtos>();
    }

    public class CompanyRequestModel
    {
        public string Name { get; set; } = default!;
        public string CACRegNumber { get; set; } = default!;
        public string Logo { get; set; } = default!;
    }
}