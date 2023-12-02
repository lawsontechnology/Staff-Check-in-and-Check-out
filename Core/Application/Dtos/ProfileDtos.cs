using ADO_Project.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ADO_Project.Core.Application.Dtos
{
    public class ProfileDtos
    {
        public string Id { get; set; } = default!;
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Image { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
        public string Dob { get; set; } = default!;
        public string AddressId { get; set; } = default!;
        public User User { get; set; } = default!;
    }

    public class RegisterRequestModel
    {
        public string FirstName { get; set; } = default!;
        public string LastName { get; set; } = default!;
        public string Image { get; set; } = default!;
        public string PhoneNumber { get; set; } = default!;
        public string StaffNumber { get; set; } = default!;
        public string Dob { get; set; } = default!;
        public string Number { get; set; } = default!;
        public string Street { get; set; } = default!;
        public string City { get; set; } = default!;
        public string State { get; set; } = default!;
        public string PostalCode { get; set; } = default!;
        public string RoleName { get; set; } = default!;
        public string RoleDescription { get; set; } = default!;
  

    }
}