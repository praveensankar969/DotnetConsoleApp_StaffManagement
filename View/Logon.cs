using System;
using DotnetConsoleApp_StaffManagement.Controller;
using DotnetConsoleApp_StaffManagement.DTO;

namespace StaffManagement.View
{
    public static class Logon
    {
        public static void LogonScreen()
        {

            StaffCapability user = new StaffCapability();
            Console.Clear();
            Console.Write("Enter Username: ");
            string username = Console.ReadLine();
            Console.WriteLine();
            Console.Write("Enter Password: ");
            string pass = Console.ReadLine();
            var res = Service.StaffService.Login(new DotnetConsoleApp_StaffManagement.DTO.LoginDTO { UserName = username, Password = pass });

            switch (res.Type)
            {
                case "Admin":
                    {
                        if (res.Id < 1)
                        {
                            Console.WriteLine("Invalid username or password");
                            break;
                        }

                        user.AdminActions();
                        break;
                    }
                case "Teaching Staff":
                    {
                        user.TeachingStaffAction(res);
                        break;
                    }
                case "Support Staff":
                    {
                        user.SupportStaffAction(res);
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Input, Start Over!!");
                        break;
                    }
            }

        }

        public static void Register()
        {

            Console.WriteLine("Enter Staff tpye: 1. Teaching Staff, 2. Support Staff");
            int res = Convert.ToInt32(Console.ReadLine());
            switch (res)
            {
                case 1:
                    {
                        TeachingStaff obj = new TeachingStaff();
                        obj.AddStaff();
                        StaffCapability sObj = new StaffCapability();
                        int id = Service.StaffService.ComputeId() - 1;
                        sObj.TeachingStaffAction(new User { Id = id, Type = "Teaching Staff" });
                        break;
                    }
                case 2:
                    {
                        SupportStaff obj = new SupportStaff();
                        obj.AddStaff();
                        StaffCapability sObj = new StaffCapability();
                        int id = Service.StaffService.ComputeId() - 1;
                        sObj.SupportStaffAction(new User { Id = id, Type = "Support Staff" });
                        break;
                    }
            }


        }

    }
}

