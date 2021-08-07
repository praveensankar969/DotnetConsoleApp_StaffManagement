using System;
using System.Collections.Generic;
using System.IO;
using DotnetConsoleApp_StaffManagement.DTO;
using Newtonsoft.Json;
using StaffManagement;

namespace DotnetConsoleApp_StaffManagement.Controller
{
    public class SupportStaff : Staff
    {
        string filePath = @"C:\D\Work\Dotnet\StaffManagement\DotnetConsoleApp_StaffManagement\DataStore.json";
        public override void AddStaff()
        {
            base.AddStaff();
            Console.Write("Subject: ");
            Subject = Console.ReadLine();
            Type = "Support Staff";
            var json = File.ReadAllText(filePath);
            List<SupportStaff> staffs = JsonConvert.DeserializeObject<List<SupportStaff>>(json);
            staffs.Add(this);
            string jsonResult = JsonConvert.SerializeObject(staffs);
            File.WriteAllText(filePath, jsonResult);
            
        }

        public override void EditStaffDetail(int id, string defaultText="")
        {
            string editOptionText = "Enter one property to edit: (UserName , Password , Subject , Experience, Phone, DateOfJoining): ";
            base.EditStaffDetail(id, editOptionText);
        }
    }
}