using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ADO_Project.Core.Application.Interfaces.Repositories;
using ADO_Project.Core.Domain.Entities;
using ADO_Project.Infrastructure.Context;
using MySql.Data.MySqlClient;

namespace ADO_Project.Infrastructure.Repository
{
    public class RoleRepository : IRoleRepository
    {
        StartUp _startUp = new StartUp();
        public Role Create(Role entity)
        {
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var quarry = $"insert into role value('{entity.Id}','{entity.Name}','{entity.Description}');";
                var command = new MySqlCommand(quarry, connect);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return entity;
                }
                return null; 
            }
        }

        public Role Get(string id)
        {
               using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from Role where Id = @id;", connect);
                command.Parameters.AddWithValue("@id", id);
                var row = command.ExecuteReader();
                Role role = new();
                while (row.Read())
                {
                    role.Id = Convert.ToString(row[0]);
                    role.Name = Convert.ToString(row[1]);
                    role.Description = Convert.ToString(row[2]);
                }
                return role;
            }
        }

        public List<Role> GetAll()
        {
          List<Role> roles = new List<Role>();
           using (var connect = _startUp.connection())
            {            
                connect.Open();
                var command = new MySqlCommand($"Select * From Role;", connect);
                var row = command.ExecuteReader();
                while (row.Read())
                {
                     Role role = new();
                    role.Id = Convert.ToString(row[0]);
                    role.Name = Convert.ToString(row[1]);
                    role.Description = Convert.ToString(row[2]); 
                    roles.Add(role);
                }
                return roles;
            }
        }

        public Role GetByName(string name)
        {
            
               using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from Role where Name = @name;", connect);
                command.Parameters.AddWithValue("@name", name);
                var row = command.ExecuteReader();
                Role role = new();
                while (row.Read())
                {
                    role.Id = Convert.ToString(row[0]);
                    role.Name = Convert.ToString(row[1]);
                    role.Description = Convert.ToString(row[2]);
                    
                }
                return role;
            }
        }

        public Role Update(Role entity)
        {
            throw new NotImplementedException();
        }
    }
}