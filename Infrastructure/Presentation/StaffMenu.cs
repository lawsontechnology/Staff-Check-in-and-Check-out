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
    public class StaffMenu
    {
        public void MainMenu()
        {
            IStaffService _staffService = new StaffService();
            IUserService _userService = new UserService();
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter your StaffNumber");
                string staffNumber = Console.ReadLine();

                var request = new AttendanceRequestModel
                {
                    StaffNumber = staffNumber
                };
                var user = _userService.Register(request);
                if (user == null)
                {
                    Console.WriteLine("Invalid StaffNumber !!!");
                }
                 Console.WriteLine("Enter In for TimeIn \nEnter Out for TimeOut\nEnter 0 to quite");
                var opt = Console.ReadLine().Trim().ToLower();
                if (opt != null)
                {

                    if (opt == "in")
                    {
                        var Time = new StaffTimeInRequest
                        {
                            TimeIn = DateTime.Now,
                            StaffNumber = staffNumber,
                        };
                        _staffService.TimeIn(Time);
                        Console.WriteLine($"Successful TimeIn {DateTime.Now}");
                        return;
                    }
                    else if (opt == "out")
                    {
                        var Time = new StaffTimeOutRequest
                        {
                            TimeOut = DateTime.Now,
                            StaffNumber = staffNumber,
                        };
                        _staffService.TimeOut(Time);
                        Console.WriteLine($"Successful TimeOut {DateTime.Now}");
                        return;
                    }

                    else if (opt == "0")
                    {
                        stop = true;
                    }
                    else
                    {
                        Console.WriteLine("Invalid Input");
                    }

                }

            }
        }
    }
}
