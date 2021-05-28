using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Text;
using helloworld.Controller;
using helloworld.View;
using Newtonsoft.Json;
using System.Linq;


namespace helloworld
{

    public class AdminCapability
    {

        public void AdminActions(string staffType)
        {

            AdminControl obj = new AdminControl(staffType);
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
                            var client = new HttpClient();
                            HttpWebRequest request = (HttpWebRequest)WebRequest.Create("https://localhost:5001/api/staff");
                            try
                            {
                                WebResponse response = request.GetResponse();
                                using (Stream responseStream = response.GetResponseStream())
                                {
                                    StreamReader reader = new StreamReader(responseStream, Encoding.UTF8);
                                    List<StaffView> object1 = JsonConvert.DeserializeObject<List<StaffView>>(reader.ReadToEnd());
                                    Console.WriteLine("Data Read Success");
                                    Console.Write("Name: " + object1.ElementAt(0).UserName);
                                    Console.Write(" Phone: " + object1.ElementAt(0).PhoneNumber);
                                }
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine("Error reading data from API: " + e.Message);
                            }
                            break;
                        }
                    case 2:
                        {
                            Console.Write("Enter user name of staff to view : ");
                            string name = Console.ReadLine();
                            obj.ViewStaff(name);
                            break;
                        }
                    case 3:
                        {
                            Console.WriteLine("Enter details of staff");

                            Console.Write("ID: ");
                            int id = Convert.ToInt32(Console.ReadLine());

                            Console.Write("UserName: ");
                            string name = Console.ReadLine();

                            Console.Write("Password: ");
                            string pass = Console.ReadLine();

                            Console.Write("Subject: ");
                            string subject = Console.ReadLine();

                            Console.Write("Experience: ");
                            string exp = Console.ReadLine();

                            Console.Write("Phone: ");
                            string phn = Console.ReadLine();

                            obj.AddStaff(id, name, pass, subject, exp, phn);
                            break;
                        }
                    case 4:
                        {
                            //limiting to one edit at a time
                            Console.WriteLine("Enter details of staff to edit details");
                            Console.Write("Enter Id of staff: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            do
                            {
                                Console.Write("Enter property to edit: (Username , Password , Subject , Experience, Phone): ");
                                string prop = Console.ReadLine();
                                Console.Write("Enter new value: ");
                                string propValue = Console.ReadLine();
                                obj.EditStaff(id, prop, propValue);
                            } while (Continue());
                            break;
                        }
                    case 5:
                        {
                            Console.WriteLine("Enter details of staff to delete");
                            Console.Write("Enter Id of staff: ");
                            int id = Convert.ToInt32(Console.ReadLine());
                            obj.DeleteStaff(id);
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