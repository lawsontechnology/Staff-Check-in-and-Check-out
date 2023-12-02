using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using ADO_Project.Core.Application.Interfaces.Repositories;
using ADO_Project.Core.Domain.Entities;
using ADO_Project.Infrastructure.Context;
using MySql.Data.MySqlClient;

namespace ADO_Project.Infrastructure.Repository
{
    public class UserRepository : IUserRepository
    {
        StartUp _startUp = new StartUp();
        public User Create(User entity)
        {
            using (var connect = _startUp.connection())
            {
                connect.Open(); 
                var quarry = $"insert into User values('{entity.Id}','{entity.StaffNumber}','{entity.ProfileId}','{entity.RoleId}');";
                var command = new MySqlCommand(quarry, connect);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return entity;
                }
                return null;
            }
        }

        public User Get(string id)
        {
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from User where Id = @id;", connect);
                command.Parameters.AddWithValue("@id", id);
                var row = command.ExecuteReader();
                User user = new User();
                while (row.Read())
                {
                    user.Id = Convert.ToString(row[0]);
                    user.StaffNumber = Convert.ToString(row[1]);
                    user.ProfileId = Convert.ToString(row[2]);
                    user.RoleId = Convert.ToString(row[3]);

                }
                return user;
            }
        }

        public User GetByStaffNumber(string staffNumber)
        {
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from User where staffNumber = @staffNumber;", connect);
                command.Parameters.AddWithValue("@staffNumber", staffNumber);
                var row = command.ExecuteReader();
                User user = new User();
                while (row.Read())
                {
                    user.Id = Convert.ToString(row[0]);
                    user.StaffNumber = Convert.ToString(row[1]);
                    user.ProfileId = Convert.ToString(row[2]);
                    user.RoleId = Convert.ToString(row[3]);

                }
                return user;
            }
        }

        public ICollection<User> GetAll()
        {
            ICollection<User> users = new List<User>();
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"Select * From User;", connect);
                var row = command.ExecuteReader();
                while (row.Read())
                {
                    User user = new User();
                    user.Id = Convert.ToString(row[0]);
                    user.StaffNumber = Convert.ToString(row[1]);
                    user.ProfileId = Convert.ToString(row[2]);
                    user.RoleId = Convert.ToString(row[3]);
                    users.Add(user);

                }
                return users;
            }
        }
        public User Update(User entity)
        {
            throw new NotImplementedException();
        }
    }
}