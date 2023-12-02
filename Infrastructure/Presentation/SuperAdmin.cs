namespace ADO_Project.Infrastructure.Presentation
{
    public class SuperAdmin
    {
        public void MainMenu()
        {
            bool stop = false;
            while (!stop)
            {
                Console.WriteLine("Enter 1 for Company Mgt\nEnter 2 for Attendance Register\nEnter 3 For Profile Mgt\nEnter 4 For StaffAttendance Mgt\nEnter 0 To Quit");
                int option = int.Parse(Console.ReadLine());
                if (option == 1)
                {
                    CompanyMenu companyMenu = new CompanyMenu();
                    companyMenu.MainMenu();
                }
                else if (option == 2)
                {
                    StaffMenu staffMenu = new StaffMenu();
                    staffMenu.MainMenu();
                }
                else if (option == 3)
                {
                    ProfileMenu profileMenu = new ProfileMenu();
                    profileMenu.MainMenu();
                }
                else if(option == 4)
                {
                    AttendanceDetails attendanceDetails = new AttendanceDetails();
                    attendanceDetails.MainMenu();
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
           
    }
}
