using System;

namespace StaffManagement.View
{

    public static class InitialLandingPage
    {
        public static void LogonMain()
        {

            //initial landing page
            do
            {
                Console.Clear();
                Console.WriteLine("\t\tStaff Management System");
                Console.WriteLine("1. Logon");
                Console.WriteLine("2. Signup");
                Console.Write("Enter your choice now: ");
                int selectedOption = Convert.ToInt32(Console.ReadLine());
                switch (selectedOption)
                {
                    case 1:
                        {
                            Logon.LogonScreen();
                            break;
                        }
                    case 2:
                        {
                            Logon.Register();
                            break;
                        }
                    default:
                        {
                            Console.WriteLine("Invalid choice!!");
                            break;
                        }
                }
            } while (Continue());

        }
        public static bool Continue()
        {

            Console.Write("\nDo you wish to continue to Logon Page? (y/n) : ");
            string res = Console.ReadLine();
            return res == "y" || res == "Y" ? true : false;
        }
    }

}