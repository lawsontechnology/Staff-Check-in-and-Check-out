using ADO_Project.Core.Application.Dtos;
using ADO_Project.Core.Application.Interfaces.Repositories;
using ADO_Project.Core.Application.Interfaces.Service;
using ADO_Project.Core.Domain.Entities;
using ADO_Project.Infrastructure.Repository;
using NLog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace ADO_Project.Core.Application.Implementation
{
    public class ProfileService : IProfileService
    {
        IProfileRepository _ProfileRepository = new ProfileRepository();
        IAddressRepository _addressRepository = new AddressRepository();
        IUserRepository _userRepository = new UserRepository(); 
        IRoleRepository _roleRepository = new RoleRepository();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public ProfileDtos Create(RegisterRequestModel register)
        {
           try
            {

                var profile = _ProfileRepository.GetByStaffNumber(register.StaffNumber);
                if (profile == null)
                {
                    Console.WriteLine("Already Exists");
                    return null;
                }
                var address = new Address
                {
                    Number = register.Number,
                    Street = register.Street,
                    City = register.City,
                    State = register.State,
                    PostalCode = register.PostalCode,
                    
                };
                Profile profiles = new()
                {
                    FirstName = register.FirstName,
                    LastName = register.LastName,
                    Dob = register.Dob,
                    Image = register.Image,
                    PhoneNumber = register.PhoneNumber,
                    StaffNumber = register.StaffNumber,
                    AddressId = address.Id,
                  
                };
                Role role = new()
                {
                    Name = register.RoleName,
                    Description = register.RoleDescription,
                };
                User user = new()
                {
                    StaffNumber = register.StaffNumber,
                    ProfileId = profiles.Id,
                     RoleId = role.Id,
                };
                _addressRepository.Create(address);
                _ProfileRepository.Create(profiles);
                _roleRepository.Create(role);
                _userRepository.Create(user);
                logger.Info($"{profiles.FirstName + profiles.LastName} Profile Created Successfully");
                return new ProfileDtos
                {
                    Id = profiles.Id,
                    FirstName = profiles.FirstName,
                    LastName = profiles.LastName,
                    Dob = profiles.Dob,
                    Image = profiles.Image,
                    PhoneNumber = profiles.PhoneNumber,
                    StaffNumber = profiles.StaffNumber,
                    AddressId = address.Id,
                };

            }
             catch (Exception exp)
            {

                logger.Error(exp);
            }
            return null;
        }


        public ProfileDtos Get(string id)
        {
            try
            {
                var profile = _ProfileRepository.Get(id);
                var address = _addressRepository.Get(profile.AddressId);
                logger.Info($"Getting Profile {profile.FirstName + profile.LastName}");
                return new ProfileDtos
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Dob = profile.Dob,
                    Image = profile.Image,
                    PhoneNumber = profile.PhoneNumber,
                    StaffNumber = profile.StaffNumber,
                    AddressId = address.Id,
                };
            }
            catch (Exception exp)
            {

                logger.Error(exp);
            }
            return null;
        }

        public List<ProfileDtos> GetAll()
        {
            try
            {

                List<ProfileDtos> listOfProfile = new List<ProfileDtos>();
                var profiles = _ProfileRepository.GetAll();
                foreach (var profi in profiles)
                {
                    var address = _addressRepository.Get(profi.AddressId);
                    var profile = new ProfileDtos
                    {
                        Id = profi.Id,
                        FirstName = profi.FirstName,
                        LastName = profi.LastName,
                        Dob = profi.Dob,
                        Image = profi.Image,
                        PhoneNumber = profi.PhoneNumber,
                        StaffNumber = profi.StaffNumber,
                        AddressId = $"{address.Number} {address.Street} {address.City} {address.State} {address.PostalCode}",
                    };

                    listOfProfile.Add(profile);
                }
                logger.Info($"Getting All List Of Profiles");
                return listOfProfile;
            }
            catch (Exception exp)
            {

                logger.Error(exp);
            }
            return null;
        }

        public ProfileDtos GetByStaffNumber(string StaffNumber)
        {
            try
            {

                var profile = _ProfileRepository.Get(StaffNumber);
                var address = _addressRepository.Get(profile.AddressId);
                logger.Info($"Getting Staff With This StaffNumber : {StaffNumber}");
                return new ProfileDtos
                {
                    FirstName = profile.FirstName,
                    LastName = profile.LastName,
                    Dob = profile.Dob,
                    Image = profile.Image,
                    PhoneNumber = profile.PhoneNumber,
                    StaffNumber = profile.StaffNumber,
                    AddressId = address.Id,
                };
            }
            catch (Exception exp)
            {

                logger.Error(exp);
            }
            return null;
        }
    }
}
