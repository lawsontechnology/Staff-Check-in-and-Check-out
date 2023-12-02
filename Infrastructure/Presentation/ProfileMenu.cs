using ADO_Project.Core.Application.Dtos;
using ADO_Project.Core.Application.Implementation;
using ADO_Project.Core.Application.Interfaces.Service;
using ADO_Project.Core.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADO_Project.Infrastructure.Presentation
{
    public class ProfileMenu
    {
        IProfileService _profileService = new ProfileService();
        public void MainMenu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter 1 to Register StaffDetails\nEnter 2 to view All StaffDetails\nEnter 0 to Quit");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    RegisterMenu();
                }
                else if(opt == 2)
                {
                    ViewAllProfiles();
                } 
                else if(opt == 3)
                {
                   // GetProfile();
                }
                else if (opt == 0)
                {
                    stop = true;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                }

            }

        }
       
         public void RegisterMenu()
        {
            Console.WriteLine();
            Console.WriteLine("===>Personal Info<===");
            Console.WriteLine("Enter FirstName :");
            string firstName = Console.ReadLine();
            Console.Write("Enter LastName :");
            string lastName = Console.ReadLine();
            Console.Write("Enter PhoneNumber :");
            string phoneNumber = Console.ReadLine();
            while (!IsValidPhoneNumber(phoneNumber))
            {
                Console.WriteLine("Invalid Phone Number !!!");
                Console.Write("input correct PhoneNumber: ");
                phoneNumber = Console.ReadLine();
            }
            Console.Write("Enter StaffNumber : ");
            string staffNumber = Console.ReadLine();
            Console.Write("Enter DateOfBirth :");
            string Dob = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("===>Address Info<===");
            Console.Write("Enter house Number: ");
            string num = Console.ReadLine();
            Console.Write("Enter street: ");
            string street = Console.ReadLine();
            Console.Write("Enter city: ");
            string city = Console.ReadLine();
            Console.Write("Enter state: ");
            string state = Console.ReadLine();
            Console.Write("Enter PostalCode :");
            string postal = Console.ReadLine();
            Console.WriteLine() ;
            Console.WriteLine("====> Role Info<===");
            Console.Write("Enter RoleName:  ");
            string roleName = Console.ReadLine();
            Console.Write("Enter Role Description : ");
            string description= Console.ReadLine();

            var CreateStaff = new RegisterRequestModel
            {
                FirstName = firstName,
                LastName =lastName,
                PhoneNumber  = phoneNumber,
                Image = "",
                StaffNumber = staffNumber,
                Dob =   Dob,
                Number = num,
                Street =street,
                City = city,
                State = state,
                PostalCode = postal,
                RoleDescription = description,
                RoleName = roleName,
               
            };
            var response = _profileService.Create(CreateStaff);
            Console.WriteLine(response != null ? $"Congratulations {response.FirstName +""+ response.LastName}, Registration Successful": "registration not successful");

        }
        static bool IsValidPhoneNumber(string phoneNumber)
        {
            string pattern = @"^\(?([0-9]{4})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$";
            return Regex.IsMatch(phoneNumber, pattern);
        }
       public void ViewAllProfiles()
       {
            var list = _profileService.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"FirstName: {item.FirstName},LastName: {item.LastName},Dob:{item.Dob},PhoneNumber:{item.PhoneNumber},StaffNumber: {item.StaffNumber},Address:{item.AddressId}");

            }
        }




       /* public void GetProfile()
        {
            Console.Write("Enter Id Of Profile To View");
            var view = Console.ReadLine();
            if (view != null) 
            {
                _profileService.Get(view);
            }   
        }*/
    }
    

}
