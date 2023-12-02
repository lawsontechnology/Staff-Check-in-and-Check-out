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
    public class AttendanceDetails
    {
        IStaffService _staffService = new StaffService();
        public void MainMenu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter 1 To View All StaffAttendance\nEnter 2 To Get A Particular StaffAttendance\nEnter 0 To Quit");
                int opt = int.Parse(Console.ReadLine());
                if (opt == 0) 
                {
                    stop = true;
                }
                else if(opt == 1)
                {
                    ViewAllAttendance();
                }
                else if(opt == 2)
                {
                    GetStaffAttendance();
                }
                else 
                {
                    Console.WriteLine("Invaild Option");
                }
            }
        }

        public void ViewAllAttendance()
        {
            var list = _staffService.GetAll();
            foreach (var item in list)
            {
                Console.WriteLine($"StaffNumber: {item.StaffNumber}, TimeIn: {item.TimeIn}, TimeOut: {item.TimeOut}");

            }
        }

        public void GetStaffAttendance()
        {
            Console.Write("Enter StaffNumber:");
            string staffNumber = Console.ReadLine().Trim();
             var allStaff = _staffService.GetAll();
                foreach (var staff in allStaff)
                {
                    if(staff.StaffNumber == staffNumber)
                    {

                       Console.WriteLine($"StaffNumber: {staff.StaffNumber}, TimeIn: {staff.TimeIn},TimeOut: {staff.TimeOut}");
                    }
                }

        }
    }
}
