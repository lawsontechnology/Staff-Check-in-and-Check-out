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
    public class ProfileRepository : IProfileRepository
    {
        StartUp _startUp = new StartUp();
        public Profile Create(Profile entity)
        {
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var quarry = $"insert into Profile values('{entity.Id}','{entity.FirstName}','{entity.LastName}','{entity.Image}','{entity.PhoneNumber}','{entity.StaffNumber}','{entity.Dob}','{entity.AddressId}');";
                var command = new MySqlCommand(quarry, connect);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return entity;
                }
                return null;
            }
        }

        public Profile Get(string id)
        {
             using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from Profile where Id = @id;", connect);
                command.Parameters.AddWithValue("@id", id);
                var row = command.ExecuteReader();
                Profile profile = new();
                while (row.Read())
                {
                    profile.Id = Convert.ToString(row[0]);
                    profile.FirstName = Convert.ToString(row[1]);
                    profile.LastName = Convert.ToString(row[2]);
                    profile.StaffNumber = Convert.ToString(row[3]);
                    profile.PhoneNumber = Convert.ToString(row[4]);
                    profile.Image = Convert.ToString(row[5]);
                    profile.Dob = Convert.ToString(row[6]);
                    profile.AddressId = Convert.ToString(row[7]);
                }
                return profile;
            }
        }

         public Profile GetByStaffNumber(string staffNumber)
        {
             using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from Profile where StaffNumber = @staffNumber;", connect);
                command.Parameters.AddWithValue("@staffNumber", staffNumber);
                var row = command.ExecuteReader();
                Profile profile = new();
                while (row.Read())
                {
                    profile.Id = Convert.ToString(row[0]);
                    profile.FirstName = Convert.ToString(row[1]);
                    profile.LastName = Convert.ToString(row[2]);
                    profile.StaffNumber = Convert.ToString(row[3]);
                    profile.PhoneNumber = Convert.ToString(row[4]);
                    profile.Image = Convert.ToString(row[5]);
                    profile.Dob = Convert.ToString(row[6]);
                    profile.AddressId = Convert.ToString(row[7]);
                }
                return profile;
            }
        }

        public ICollection<Profile> GetAll()
        {
            ICollection<Profile> profiles = new List<Profile>();
            using (var connect = _startUp.connection())
            {            
                connect.Open();
                var command = new MySqlCommand($"Select * From profile;", connect);
                var row = command.ExecuteReader();
                while (row.Read())
                {
                    Profile profile = new();
                    profile.Id = Convert.ToString(row[0]);
                    profile.FirstName = Convert.ToString(row[1]);
                    profile.LastName = Convert.ToString(row[2]);
                    profile.StaffNumber = Convert.ToString(row[3]);
                    profile.PhoneNumber = Convert.ToString(row[4]);
                    profile.Image = Convert.ToString(row[5]);
                    profile.Dob = Convert.ToString(row[6]);
                    profile.AddressId = Convert.ToString(row[7]);
                    profiles.Add(profile);
                }
                return profiles;
            }
        }

        public Profile Update(Profile entity)
        {
            throw new NotImplementedException();
        }
    }
}