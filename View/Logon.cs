using System;
using Microsoft.Data.Sqlite;
using StaffManagement.Controller;
using StaffManagement.DTO;
using StaffManagement.View;

namespace StaffManagement.View
{
    public static class Logon
    {
        public static void LogonScreen(int selectedOption)
        {
            AdminCapability user = new AdminCapability();
            AdminControl controller = new AdminControl();
            switch (selectedOption)
            {
                case 1:
                    {
                        Console.Clear();
                        Console.Write("Enter Username: ");
                        string username = Console.ReadLine();
                        Console.WriteLine();
                        Console.Write("Enter Password: ");
                        string pass = Console.ReadLine();
                        var res = controller.Login(new DotnetConsoleApp_StaffManagement.DTO.LoginDTO{UserName=username, Password=pass});
                        if(res.Id <1){
                            Console.WriteLine("Invalid username or password");
                            break;
                        }
                        user.AdminActions(new DotnetConsoleApp_StaffManagement.DTO.User{Id = res.Id, Admin=res.Admin});
                        break;
                    }
                case 2:
                    {
                        user.StaffAction();
                        break;
                    }
                default:
                    {
                        Console.WriteLine("Invalid Input, Start Over!!");
                        break;
                    }
            }

        }

    }
}

