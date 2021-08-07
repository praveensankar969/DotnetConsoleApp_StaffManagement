using System;
using DotnetConsoleApp_StaffManagement.Controller;
using DotnetConsoleApp_StaffManagement.DTO;
using Procedure;

namespace StaffManagement.View
{
    public class StaffCapability
    {
        public void AdminActions()
        {
            AdminStaff admin = new AdminStaff();
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t Admin Dashboard");
                Console.WriteLine("1. View all Staffs");
                Console.WriteLine("2. View Staff Details");
                Console.WriteLine("3. Add New Staff");
                Console.WriteLine("4. Edit Staff Details");
                Console.WriteLine("5. Delete Staff");
                Console.WriteLine("6. Exit Application");

                Console.Write("Enter your choice now: ");
                int selectedOption = Convert.ToInt32(Console.ReadLine());

                switch (selectedOption)
                {
                    case 1:
                        {
                            Console.WriteLine("Fetching all Data\n");
                            admin.GetStaff();
                            break;
                        }
                    case 2:
                        {
                            admin.GetStaffWithID();
                            break;
                        }
                    case 3:
                        {
                            admin.AddStaff();
                            break;
                        }
                    case 4:
                        {
                            Console.WriteLine("Enter Id of staff to edit");
                            int id = Convert.ToInt32(Console.ReadLine());
                            SQLProcedure obj = new SQLProcedure();
                            AdminStaff eStaff = obj.GetDataOfId(id);
                            admin.EditStaffDetail(eStaff);
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter id of staff to delete");
                            int id = Convert.ToInt32(Console.ReadLine());
                            admin.DeleteStaff(id);
                            break;
                        }
                    case 6:
                        {
                            Environment.Exit(0);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid choice, Retuning to Dashboard");
                            break;
                        }

                }

            } while (Continue());
        }

        public void TeachingStaffAction(User user)
        {
            TeachingStaff staff = new TeachingStaff();
            staff.Id = user.Id;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t Teaching Staff Dashboard");
                Console.WriteLine("1. Add New Staff");
                Console.WriteLine("2. Edit your details");
                Console.WriteLine("3. Delete your data");
                Console.WriteLine("4. Exit Application");

                Console.Write("Enter your choice now: ");
                int selectedOption = Convert.ToInt32(Console.ReadLine());

                switch (selectedOption)
                {
                    case 1:
                        {
                            staff.AddStaff();
                            break;
                        }
                    case 2:
                        {
                            staff.EditStaffDetail(staff);
                            break;
                        }
                    case 3:
                        {
                            staff.DeleteStaff(user.Id);
                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(0);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid choice, Retuning to Dashboard");
                            break;
                        }

                }

            } while (Continue());
        }

         public void SupportStaffAction(User user)
        {
            SupportStaff staff = new SupportStaff();
            staff.Id = user.Id;
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t Support Staff Dashboard");
                Console.WriteLine("1. Add New Staff");
                Console.WriteLine("2. Edit your details");
                Console.WriteLine("3. Delete your data");
                Console.WriteLine("4. Exit Application");

                Console.Write("Enter your choice now: ");
                int selectedOption = Convert.ToInt32(Console.ReadLine());

                switch (selectedOption)
                {
                    case 1:
                        {
                            staff.AddStaff();
                            break;
                        }
                    case 2:
                        {
                            staff.EditStaffDetail(staff);
                            break;
                        }
                    case 3:
                        {
                            staff.DeleteStaff(user.Id);
                            break;
                        }
                    case 4:
                        {
                            Environment.Exit(0);
                            break;
                        }

                    default:
                        {
                            Console.WriteLine("Invalid choice, Retuning to Dashboard");
                            break;
                        }

                }

            } while (Continue());
        }

        public bool Continue()
        {

            Console.Write("\nDo you wish to continue operations in this dashboard ? (y/n): ");
            string res = Console.ReadLine();
            return res == "y" || res == "Y" ? true : false;
        }

        public static bool Continue(string edit)
        {

            Console.Write("\nDo you wish to edit another detail of this staff? (y/n) : ");
            string res = Console.ReadLine();
            return res == "y" || res == "Y" ? true : false;
        }


    }
}