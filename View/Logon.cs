using System;
using Service;
using Microsoft.Data.Sqlite;
using StaffManagement.View;
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
                case "Staff":
                    {
                        user.StaffAction(res);
                        break;
                    }
                case "Support":
                    {
                        user.StaffAction(res);
                        break;
                    }    
                default:
                    {
                        Console.WriteLine("Invalid Input, Start Over!!");
                        break;
                    }
            }

        }

        public static void Register(){
            NonAdminStaff obj = new NonAdminStaff(); 
            obj.AddStaff();
            StaffCapability sObj = new StaffCapability();
            int id = Service.StaffService.ComputeId()-1;
            sObj.StaffAction(new User{Id=id, Type="Staff"});
        }

    }
}

