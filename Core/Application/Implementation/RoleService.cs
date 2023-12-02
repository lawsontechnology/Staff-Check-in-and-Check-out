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

namespace ADO_Project.Core.Application.Implementation
{
    public class RoleService : IRoleService
    {
         IRoleRepository _roleRepository = new RoleRepository();
         IUserRepository _userRepository = new UserRepository();
        private static readonly Logger logger = LogManager.GetCurrentClassLogger();
        public RoleDtos Get(string id)
        {
            try
            {
                var role = _roleRepository.Get(id);
                logger.Info($"Getting Role {role.Name}");
                return new RoleDtos
                {
                    Name = role.Name,
                    Description = role.Description,
                };
            }
            
            catch (Exception ex) 
            {
                logger.Error(ex);
            }
            return new RoleDtos
            {
                Name = null,
                Description = null,
            };
        }

        public List<RoleDtos> GetAll()
        {
           try
            {
                var role = _roleRepository.GetAll();
                var listOfRole = role.Select(x => new RoleDtos
                {
                    Description = x.Description,
                    Name = x.Name,
                }).ToList();
                logger.Info("GetAll Value Of Roles");
                return listOfRole;
            }
            catch (Exception ex) 
            {
                logger.Error(ex);
            }
            return null;
        }

        
    }
}
