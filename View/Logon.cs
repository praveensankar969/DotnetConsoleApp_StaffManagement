using System;
using DotnetConsoleApp_StaffManagement.Controller;
using DotnetConsoleApp_StaffManagement.DTO;
using Procedure;

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
            SQLProcedure obj = new SQLProcedure();
            User res = obj.Login(username, pass);

            switch (res.Type)
            {
                case "Admin":
                    {
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
                        Console.WriteLine("Wrong username or password");
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
                        break;
                    }
                case 2:
                    {
                        SupportStaff obj = new SupportStaff();
                        obj.AddStaff();
                        break;
                    }
            }


        }

    }
}

