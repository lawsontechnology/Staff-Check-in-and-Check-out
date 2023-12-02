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
    public class AddressRepository : IAddressRepository
    {
        StartUp _startUp = new StartUp();

        public Address Create(Address entity)
        {
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var querry = $"Insert into address (Id, Number, Street , City, State,PostalCode) values('{entity.Id}', '{entity.Number}', '{entity.Street}', '{entity.City}','{entity.State}','{entity.PostalCode}');";
                var command = new MySqlCommand(querry, connect);
                var row = command.ExecuteNonQuery();
                if (row != -1)
                {
                    return entity;
                }
                return null;
            }
        }

        public Address Get(string id)
        {
          using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"select * from address where Id = @id;", connect);
                command.Parameters.AddWithValue("@id", id);
                var row = command.ExecuteReader();
                Address address = new();
                while (row.Read())
                {
                    address.Id = Convert.ToString(row[0]);
                    address.Number = Convert.ToString(row[1]);
                    address.Street = Convert.ToString(row[2]);
                    address.City = Convert.ToString(row[3]);
                    address.State = Convert.ToString(row[4]);
                    address.PostalCode = Convert.ToString(row[5]);
                }
                return address;
            }
        }

        public ICollection<Address> GetAll()
        {
            List<Address> Addresses = new List<Address>();
            using (var connect = _startUp.connection())
            {
                connect.Open();
                var command = new MySqlCommand($"Select * From address;", connect);
                var row = command.ExecuteReader();
                while (row.Read())
                {
                    Address address = new Address();
                    address.Id = Convert.ToString(row[0]);
                    address.Number = Convert.ToString(row[1]);
                    address.Street = Convert.ToString(row[2]);
                    address.City = Convert.ToString(row[3]);
                    address.State = Convert.ToString(row[4]);
                    address.PostalCode = Convert.ToString(row[5]);
                    Addresses.Add(address);
                }

            }
            return Addresses;
        }

        public Address Update(Address entity)
        {
            throw new NotImplementedException();
        }
    }
}