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
    
    public class StaffRepository : IStaffRepository
    {
        StartUp _startUp = new StartUp();
        public Staff Create(Staff entity)
        {
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var quarry = $"insert into Staff values('{entity.Id}','{entity.StaffNumber}','{entity.TimeIn}','{entity.TimeOut}');";
                var command = new MySqlCommand(quarry, connect);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return entity;
                }
                return null;
            }
        }

        public Staff Get(string id)
        {
             using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from staff where Id = @id;", connect);
                command.Parameters.AddWithValue("@id", id);
                var row = command.ExecuteReader();
                Staff staff = new();
                while (row.Read())
                {
                    staff.Id = Convert.ToString(row[0]);
                    staff.StaffNumber = Convert.ToString(row[1]);
                    staff.TimeIn = Convert.ToDateTime(row[2]);
                    staff.TimeOut = Convert.ToDateTime(row[3]);
                }
                return staff;
            }
        }

        public ICollection<Staff> GetAll()
        {
            ICollection<Staff> staffs = new List<Staff>();
             using (var connect = _startUp.connection())
            {            
                connect.Open();
                var command = new MySqlCommand($"Select * From Staff;", connect);
                var row = command.ExecuteReader();
                while (row.Read())
                {
                    Staff staff = new();
                    staff.Id = Convert.ToString(row[0]);
                    staff.StaffNumber = Convert.ToString(row[1]);
                    staff.TimeIn = Convert.ToDateTime(row[2]);
                    staff.TimeOut = Convert.ToDateTime(row[3]);
                    staffs.Add(staff);
                }
                return staffs;
            }
        }

        public Staff Update(Staff entity)
        {
            throw new NotImplementedException();
        }
    }
}