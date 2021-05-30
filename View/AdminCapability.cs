using System;
using System.Net.Http;
using StaffManagement.DTO;
using StaffManagement.Controller;

namespace StaffManagement.View
{

    public class AdminCapability
    {

        public void AdminActions(string staffType)
        {

            
            ClientControl client = new ClientControl(new HttpClient());
            do
            {
                Console.Clear();
                Console.WriteLine("\t\t" + staffType + " Dashboard");
                Console.WriteLine("1. View all Staffs");
                Console.WriteLine("2. View Staff Details");
                Console.WriteLine("3. Add Staff Details");
                Console.WriteLine("4. Edit Staff Details");
                Console.WriteLine("5. Delete Staff");
                Console.WriteLine("6.Exit Application");


                Console.Write("Enter your choice now: ");
                int selectedOption = Convert.ToInt32(Console.ReadLine());

                switch (selectedOption)
                {
                    case 1:
                        {
                            Console.WriteLine("Fetching all Data\n");
                            client.GetAllStaff();                           
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter Id of staff to view : ");
                            string id = Console.ReadLine();
                            client.GetStaff(id);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter details of staff");
                            StaffDTO staff = new StaffDTO();
                            Console.Write("ID: ");
                            staff.Id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("UserName: ");
                            staff.UserName = Console.ReadLine();

                            Console.Write("Password: ");
                            staff.Password = Console.ReadLine();

                            Console.Write("Subject: ");
                            staff.Subject = Console.ReadLine();

                            Console.Write("Experience: ");
                            staff.Experience = Convert.ToInt32(Console.ReadLine());

                            Console.Write("Phone: ");
                            staff.PhoneNumber = Console.ReadLine();

                            client.AddStaff(staff);
                            break;
                        }
                    case 4:
                        {
                            StaffUpdateDTO staffUpdateDTO= new StaffUpdateDTO();
                            //limiting to one edit at a time
                            Console.WriteLine("Enter details of staff to edit details");
                            Console.Write("Enter Id of staff: ");
                            staffUpdateDTO.Id = Convert.ToInt32(Console.ReadLine());
                            do
                            {
                                Console.Write("Enter property to edit: (Username , Password , Subject , Experience, Phone): ");
                                staffUpdateDTO.Property = Console.ReadLine();
                                Console.Write("Enter new value: ");
                                staffUpdateDTO.PropertyValue = Console.ReadLine();
                                client.EditStaff(staffUpdateDTO);
                            } while (Continue());
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter details of staff to delete");
                            Console.Write("Enter Id of staff: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            //obj.DeleteStaff(id);
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

            } while (Continue(staffType));
        }

        public bool Continue(string staffType)
        {

            Console.Write("\nDo you wish to continue with " + staffType + " dashboard ? (y/n): ");
            string res = Console.ReadLine();
            return res == "y" || res == "Y" ? true : false;
        }

        public static bool Continue()
        {

            Console.Write("\nDo you wish to edit another detail of this staff? (y/n) : ");
            string res = Console.ReadLine();
            return res == "y" || res == "Y" ? true : false;
        }


    }
}