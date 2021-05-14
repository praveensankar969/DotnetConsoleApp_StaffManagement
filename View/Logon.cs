using System;
using Microsoft.Data.Sqlite;

namespace helloworld
{
    public static class Logon
    {
        public static void LogonScreen(int selectedOption)
        {
            AdminCapability user = new AdminCapability();
            switch (selectedOption){
                case 1:{
                     user.AdminActions("Admin");
                     break;
                }
                case 2:{
                    user.AdminActions("Staff");
                    break;
                }
                case 3:{
                    user.AdminActions("Support");
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

