using System;
using Microsoft.Data.Sqlite;
using StaffManagement.DTO;
using StaffManagement.View;

namespace StaffManagement.View
{
    public static class Logon
    {
        public static void LogonScreen(int selectedOption)
        {
            AdminCapability user = new AdminCapability();
            switch (selectedOption){
                case 1:{
                     user.AdminActions("staff");
                     break;
                }
                case 2:{
                    user.AdminActions("teacher");
                    break;
                }
                default:{
                    Console.WriteLine("Invalid Input, Start Over");
                    break;
                }
            }

        }
    
    }
}

