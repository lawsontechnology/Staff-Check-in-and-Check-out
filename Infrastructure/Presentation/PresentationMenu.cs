using ADO_Project.Core.Application.Dtos;
using ADO_Project.Core.Application.Implementation;
using ADO_Project.Core.Application.Interfaces.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ADO_Project.Infrastructure.Presentation
{
    public class PresentationMenu
    {
         IUserService _userService = new UserService();
        public void MainMenu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter 1 for Attendance\nEnter 0 to Quit");
                 int opt = int.Parse(Console.ReadLine());
                if (opt == 1)
                {
                    LoginMenu();
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

         public void LoginMenu()
        {
            Console.WriteLine("Enter your StaffNumber ID To Login");
            string staffNumber = Console.ReadLine();

            var request = new AttendanceRequestModel
            {
                StaffNumber = staffNumber
            };
            var user = _userService.Register(request);
            if (user == null)
            {
                Console.WriteLine("Invalid StaffNumber !!!");
                bool stop = false;
                while (!stop)
                {
                    Console.WriteLine("Enter 1 for Attendance\nEnter 0 To Quit");
                    int option = int.Parse(Console.ReadLine());
                    if (option == 1)
                    {
                        LoginMenu();
                    }
                    else if (option == 0)
                    {
                        stop = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");

                    }


                }
            }
            if (user != null)
            {
                if (user.RoleId == "1")
                {
                    SuperAdmin Admin = new();
                    Admin.MainMenu();
                    return;
                }
                StaffMenu staffMenu = new();
                staffMenu.MainMenu();
                return;
            }
           
         }


    }
}
