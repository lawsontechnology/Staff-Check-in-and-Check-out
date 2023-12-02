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
    public class CompanyRepository : ICompanyRepository
    {
        StartUp _startUp = new StartUp();
        public Company Create(Company entity)
        {
            using ( var connect = _startUp.connection())
            {
                connect.Open();
                var quarry = $"insert into Company values('{entity.Id}','{entity.Name}','{entity.CACRegNumber}','{entity.Logo}');";
                var command = new MySqlCommand(quarry, connect);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return entity;
                }
                return null;
            }
        }

        public Company Get(string id)
        {
             using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from company where Id = @id;", connect);
                command.Parameters.AddWithValue("@id", id);
                var row = command.ExecuteReader();
                Company company = new();
                while (row.Read())
                {
                    company.Id = Convert.ToString(row[0]);
                    company.Name = Convert.ToString(row[1]);
                    company.CACRegNumber = Convert.ToString(row[2]);
                    company.Logo = Convert.ToString(row[3]);

                }
                return company;
            }
        }

        public ICollection<Company> GetAll()
        {
            ICollection<Company> companies = new List<Company>();
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"Select * From company;", connect);
                var row = command.ExecuteReader();
                while (row.Read())
                {
                    Company company = new();
                    company.Id = Convert.ToString(row[0]);
                    company.Name = Convert.ToString(row[1]);
                    company.CACRegNumber = Convert.ToString(row[2]);
                    company.Logo = Convert.ToString(row[3]);
                    companies.Add(company);
                }
                return companies;
            }
        }

        public Company GetByRegNum(string regNumber)
        {
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from company where CacRegNumber = @regNumber;", connect);
                command.Parameters.AddWithValue("@regNumber", regNumber);
                var row = command.ExecuteReader();
                Company company = new();
                while (row.Read())
                {
                    company.Id = Convert.ToString(row[0]);
                    company.Name = Convert.ToString(row[1]);
                    company.CACRegNumber = Convert.ToString(row[2]);
                    company.Logo = Convert.ToString(row[3]);

                }
                return company;
            }
        }

        public Company Update(Company entity)
        {
            throw new NotImplementedException();
        }
    }
}