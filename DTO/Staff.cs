
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;

namespace StaffManagement

{
    public abstract class Staff
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        private int _experience;
        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value > 30)
                {
                    throw new Exception("Experience cannot be greater than 30");
                }
                else if (value < 0)
                {
                    throw new Exception("Experience cannot be less than 0");
                }
                else
                {
                    _experience = value;
                }
            }
        }
        private DateTime _date;
        public DateTime DateOfJoining
        {
            get
            {
                return _date;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception("Joining Date cannot be in future");
                }
                else
                {
                    _date = value;
                }
            }
        }
        private string _phone;
        public string PhoneNumber
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value.Length > 10 || value.Length < 10)
                {
                    throw new Exception("Phone number should be 10 digits");
                }
                else
                {
                    _phone = value;
                }
            }
        }
        public string Subject { get; set; }
        public string Type;


        public List<Staff> GetStaff()
        {
            var json = File.ReadAllText(@"C:\D\Work\Dotnet\StaffManagement\DotnetConsoleApp_StaffManagement\DataStore.json");
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            return staffs;
        }
        public void GetStaffWithID()
        {
            Console.Write("Enter Id of staff to view : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var json = File.ReadAllText(@"C:\D\Work\Dotnet\StaffManagement\DotnetConsoleApp_StaffManagement\DataStore.json");
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            var res = staffs.FirstOrDefault(x => x.Id == id);
            Console.WriteLine("Details of Staff " + id + " are:");
            Console.WriteLine("Name: " + res.UserName + " \tDate of Joining: " + res.DateOfJoining + " \tExperience: " + res.Experience + " \tSubject: " + res.Subject + " \tPhone: " + res.PhoneNumber + " \tType: " + res.Type);
        }
        public virtual void AddStaff()
        {
            int id = Service.StaffService.ComputeId();

            Console.WriteLine("Enter details of new staff");

            Id = id;

            Console.Write("UserName: ");
            UserName = Console.ReadLine();

            Console.Write("Password: ");
            Password = Console.ReadLine();

            Console.Write("Experience: ");
            int exp;
            while (!int.TryParse(Console.ReadLine(), out exp))
            {
                Console.Write("This is an invalid input, please enter a number");
            }
            try
            {
                Experience = exp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Experience: ");
                Experience = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Phone: ");
            try
            {
                PhoneNumber = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Phone: ");
                PhoneNumber = Console.ReadLine();
            }

            Console.Write("Date of Joining: ");
            try
            {
                DateOfJoining = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("DateOfJoining: ");
                DateOfJoining = DateTime.Parse(Console.ReadLine());

            }


        }
        public virtual void EditStaffDetail(int id, string text)
        {
            do
            {
                var json = File.ReadAllText(@"C:\D\Work\Dotnet\StaffManagement\DotnetConsoleApp_StaffManagement\DataStore.json");
                List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
                var res = staffs.FirstOrDefault(x => x.Id == id);

                if (res != null)
                {
                    int exp;
                    Console.Write(text);
                    var property = Console.ReadLine();
                    var propInfo = res.GetType().GetProperty(property);
                    if (propInfo == null)
                    {
                        Console.WriteLine("Wrong PropertyName");
                        break;
                    }
                    Console.Write("Enter new value: ");
                    if (property == "Experience")
                    {
                        while (!int.TryParse(Console.ReadLine(), out exp))
                        {
                            Console.Write("This is an invalid input, please enter a number: ");
                        }
                        try
                        {
                            propInfo.SetValue(res, exp);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);

                        }

                    }
                    else if (property == "DateOfJoining")
                    {
                        var value = DateTime.Parse(Console.ReadLine());
                        try
                        {
                            propInfo.SetValue(res, value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                    else
                    {
                        var value = Console.ReadLine();
                        try
                        {
                            propInfo.SetValue(res, value);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }

                    string jsonResult = JsonConvert.SerializeObject(staffs);
                    File.WriteAllText(@"C:\D\Work\Dotnet\StaffManagement\DotnetConsoleApp_StaffManagement\DataStore.json", jsonResult);
                }
                else
                {
                    Console.WriteLine("No Data to Edit");
                    break;
                }
            } while (Continue("edit"));
        }
        public void DeleteStaff(int id)
        {
            var json = File.ReadAllText(@"C:\D\Work\Dotnet\StaffManagement\DotnetConsoleApp_StaffManagement\DataStore.json");
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            var res = staffs.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                Console.WriteLine("No Data to delete");
            }
            else
            {
                staffs.Remove(res);
                string jsonResult = JsonConvert.SerializeObject(staffs);
                File.WriteAllText(@"C:\D\Work\Dotnet\StaffManagement\DotnetConsoleApp_StaffManagement\DataStore.json", jsonResult);
            }
        }








        public static bool Continue(string edit)
        {

            Console.Write("\nDo you wish to edit another detail of this staff? (y/n) : ");
            string res = Console.ReadLine();
            return res == "y" || res == "Y" ? true : false;
        }

    }
}