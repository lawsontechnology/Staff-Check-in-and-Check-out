using ADO_Project.Core.Application.Dtos;
using ADO_Project.Core.Application.Implementation;
using ADO_Project.Core.Application.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADO_Project.Infrastructure.Presentation
{
    public class CompanyMenu
    {
        ICompanyService _companyService = new CompanyService();
        public void MainMenu()
        {

            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter 1 To Register Company\nEnter 0 to Quit");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    RegisterMenu();

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
            Console.Write("Enter Name Of Company:");
            string name = Console.ReadLine();
            Console.Write("Enter CacRegNumber :");
            string RegNumber = Console.ReadLine();

            var createCompany = new CompanyRequestModel
            {
                CACRegNumber = RegNumber,
                Name = name,
                Logo = "",
            };
            var check = _companyService.GetAll();
            if(check == null)
            {
                _companyService.Create(createCompany);
                Console.WriteLine(createCompany != null ? $"Congratulations {createCompany.Name}, Registration Successful" : "registration not successful");
            }

            Console.WriteLine("Two Company Can Not Be Created");
         }
    }

}
