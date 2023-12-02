using ADO_Project.Core.Application.Dtos;
using ADO_Project.Core.Application.Interfaces.Repositories;
using ADO_Project.Core.Application.Interfaces.Service;
using ADO_Project.Core.Domain.Entities;
using ADO_Project.Infrastructure.Repository;
using NLog;
using NLog.Fluent;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ADO_Project.Core.Application.Implementation
{
    public class UserService : IUserService
    {
         IUserRepository _userRepository = new UserRepository();
        //IProfileRepository _profileRepository = new ProfileRepository();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public UserDtos Register(AttendanceRequestModel request)
        {
            try
            {
                var users = _userRepository.GetByStaffNumber(request.StaffNumber);
                if (users.StaffNumber == null)
                {
                    Console.WriteLine("Invalid StaffNumber");
                    return null;
                }
                 
                logger.Info($"{request.StaffNumber} Login SuccessFully");
                 return new UserDtos
                {
                    RoleId = _userRepository.Get(users.RoleId).Id,
                    ProfileId = _userRepository.Get(users.ProfileId).Id,
                    Id = users.Id,
                    StaffNumber = request.StaffNumber,
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
