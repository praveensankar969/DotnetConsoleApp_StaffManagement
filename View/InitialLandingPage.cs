using System;

namespace helloworld
{

    public class Login
    {
        static void Main(string[] args)
        {
            
            //initial landing page
            do{
                Console.Clear();
            Console.WriteLine("\t\tStaff Management System");
            Console.WriteLine("1. Admin logon");
            Console.WriteLine("2. Teaching Staff logon");
            Console.WriteLine("3. Support Staff logon");
            Console.Write("Enter your choice now: ");
            int selectedOption = Convert.ToInt32(Console.ReadLine());
            Logon.LogonScreen(selectedOption);
            }while(Continue());

        }
        public static bool Continue(){

            Console.Write("\nDo you wish to continue to Staff Management Dashboard? (y/n) : ");
            string res = Console.ReadLine();
            return res=="y" || res=="Y" ? true:false;
        }
    }

}