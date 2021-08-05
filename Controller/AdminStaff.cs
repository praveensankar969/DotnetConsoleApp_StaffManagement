using System;
using DotnetConsoleApp_StaffManagement.DTO;
using StaffManagement;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;
using System.Linq;
using DotnetConsoleApp_StaffManagement.Interfaces;

namespace DotnetConsoleApp_StaffManagement.Controller
{
    public class AdminStaff : Staff, Actions
    {
        string filePath = @"C:\D\Work\Dotnet\DotnetConsoleApp_StaffManagement\DataStore.json";
        public override void AddStaff()
        {
            int id = Service.StaffService.ComputeId();

            Console.WriteLine("Enter details of new staff");
            var staff = new Modal();
            staff.Id = id;

            Console.Write("UserName: ");
            staff.UserName = Console.ReadLine();

            Console.Write("Password: ");
            staff.Password = Console.ReadLine();

            Console.Write("Experience: ");
            int exp;
            while (!int.TryParse(Console.ReadLine(), out exp))
            {
                Console.Write("This is an invalid input, please enter a number");
            }
            staff.Experience = exp;

            Console.Write("Phone: ");
            staff.PhoneNumber = Console.ReadLine();

            Console.Write("Date of Joining: ");
            staff.DateOfJoining = Console.ReadLine();

            Console.Write("Staff Type(Admin/Staff/Support): ");
            staff.Type = Console.ReadLine();

            if (staff.Type != "Admin")
            {
                Console.Write("Subject: ");
                staff.Subject = Console.ReadLine();
            }

            var json = File.ReadAllText(filePath);
            List<Modal> staffs = JsonConvert.DeserializeObject<List<Modal>>(json);
            staffs.Add(staff);
            string jsonResult = JsonConvert.SerializeObject(staffs);
            File.WriteAllText(filePath, jsonResult);
        }

        public override void EditStaffDetail(int id)
        {
            do
            {
                var json = File.ReadAllText(filePath);
                List<Modal> staffs = JsonConvert.DeserializeObject<List<Modal>>(json);
                var res = staffs.FirstOrDefault(x => x.Id == id);

                if (res != null)
                {
                    int exp;
                    Console.Write("Enter one property to edit: (UserName , Password , Subject , Experience, Phone, DateOfJoining, Type): ");
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
                        propInfo.SetValue(res, exp);
                    }
                    else{
                        var value = Console.ReadLine();
                        propInfo.SetValue(res, value);
                    }   
                    
                    string jsonResult = JsonConvert.SerializeObject(staffs);
                    File.WriteAllText(filePath, jsonResult);
                }
                else
                {
                    Console.WriteLine("No Data to Edit or wrong ID");
                    break;
                }
            } while (Continue("edit"));
        }

        public static bool Continue(string edit)
        {

            Console.Write("\nDo you wish to edit another detail of this staff? (y/n) : ");
            string res = Console.ReadLine();
            return res == "y" || res == "Y" ? true : false;
        }
    }
}