using System;
using DotnetConsoleApp_StaffManagement.DTO;
using StaffManagement;
using System.IO;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace DotnetConsoleApp_StaffManagement.Controller
{
    public class AdminStaff : Staff
    {
        string filePath = @"C:\D\Work\Dotnet\StaffManagement\DotnetConsoleApp_StaffManagement\DataStore.json";
        public override void AddStaff()
        {     
            base.AddStaff();
            Console.Write("Staff Type(Admin/Staff/Support): ");
            Type = Console.ReadLine();

            if (Type != "Admin")
            {
                Console.Write("Subject: ");
                Subject = Console.ReadLine();
            }

            var json = File.ReadAllText(filePath);
            List<AdminStaff> staffs = JsonConvert.DeserializeObject<List<AdminStaff>>(json);
            staffs.Add(this);
            string jsonResult = JsonConvert.SerializeObject(staffs);
            File.WriteAllText(filePath, jsonResult);
            
        }

        public override void EditStaffDetail(int id, string defaultText="")
        {
            string editOptionText = "Enter one property to edit: (UserName , Password , Subject , Experience, Phone, DateOfJoining, Type): ";
            base.EditStaffDetail(id, editOptionText);
        }

       
    }
}