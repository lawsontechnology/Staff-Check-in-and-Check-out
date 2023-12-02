using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;


namespace ADO_Project.Infrastructure.Context
{
    public class StartUp
    {
        public StartUp()
        {
            CreateSchema();
            CreateAddressTable();
            CreateProfileTable();
            CreateCompanyTable();
            CreateRoleTable();
            CreateStaffTable();
            CreateUserTable();
        }
        public string connectionString = "Server = localhost; User = root; Password = Olarenwaju2005;";
        public void CreateSchema()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                connection.Open();
                var query = "CREATE SCHEMA IF NOT EXISTS `EmployeeAttendance`";
                var command = new MySqlCommand(query, connection);
                int rowsAffected = command.ExecuteNonQuery();
               // Console.WriteLine(rowsAffected > 0 ? "Schema created" : "Schema already exists");
            }
        }


        public string connectionStrings = "Server=localhost;User=root;Database=EmployeeAttendance;Password=Olarenwaju2005;";

        public MySqlConnection connection()
        {
            return new MySqlConnection(connectionStrings);
        }

       

        public void CreateTable(string tableQuarry)
        {
           using (var connection = new MySqlConnection(connectionStrings))
            {
                connection.Open();
                var command = new MySqlCommand(tableQuarry, connection);
                int row = command.ExecuteNonQuery();
               // Console.WriteLine(row != -1 ? "table created" : "not created");
            }
        }

        public void CreateRoleTable()
        {
            var quarry = "create table if not exists role(Id varchar(50) not null unique,Name varchar(50) unique,Description varchar(150), primary key(Id));";
            CreateTable(quarry);

        }
        public void CreateStaffTable()
        {
            var quarry = "create table if not exists Staff(Id varchar(50) not null unique,StaffNumber varchar(200) not null, TimeIn DATETIME, TimeOut DATETIME,primary key(Id));";
            CreateTable(quarry);
        }

        public void CreateProfileTable()
        {
            var quarry = "create table if not exists Profile(Id varchar(50) not null unique,FirstName varchar(100) not null,LastName varchar(100) not null,Image varchar(300),PhoneNumber varchar(16) not null,StaffNumber varchar(100) not null unique,DOB varchar(50),AddressId varchar(50) not null,primary key(Id), foreign key(AddressId) references Address(Id));";
            CreateTable(quarry);
        }

        public void CreateCompanyTable()
        {
            var quarry = "create table if not exists Company(Id varchar(50) not null unique,Name varchar(100) not null,CacRegNumber varchar(100) not null,Logo varchar(100),primary key(Id));";
            CreateTable(quarry);
        }

        public void CreateAddressTable()
        {
            var quarry = "create table if not exists Address(Id varchar(50) not null unique,Number varchar(20) not null,Street varchar(100) not null,City varchar(100) not null,State varchar(100) not null, PostalCode varchar(200) not null,primary key(Id));";
            CreateTable(quarry);
        }
        public void CreateUserTable()
        {
            var quarry = "create table if not exists User(Id varchar(50) not null unique,StaffNumber varchar(100) unique not null,ProfileId varchar(50) unique,RoleId varchar(50) unique, primary key(Id),foreign key(ProfileId) references Profile(Id), foreign key(RoleId) references Role(Id));";
            CreateTable(quarry);
        }
    }
}