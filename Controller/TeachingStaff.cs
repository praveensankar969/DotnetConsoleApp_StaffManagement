using System;
using System.Collections.Generic;
using System.IO;
using DotnetConsoleApp_StaffManagement.DTO;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StaffManagement;

namespace DotnetConsoleApp_StaffManagement.Controller
{
    public class TeachingStaff : Staff
    {
        private static IConfiguration _iconfiguration;
        string filePath = @"C:\D\Work\Dotnet\StaffManagement\DotnetConsoleApp_StaffManagement\DataStore.json";
        
        public override void AddStaff()
        {
            base.AddStaff();
            Console.Write("Subject: ");
            Subject = Console.ReadLine();
            Type = "Teaching Staff";
            
            var json = File.ReadAllText(filePath);
            List<TeachingStaff> staffs = JsonConvert.DeserializeObject<List<TeachingStaff>>(json);
            staffs.Add(this);
            string jsonResult = JsonConvert.SerializeObject(staffs);
            File.WriteAllText(filePath, jsonResult);

        }

        public override void EditStaffDetail(int id, string defaultText = "")
        {
            string editOptionText = "Enter one property to edit: (UserName , Password , Subject , Experience, Phone, DateOfJoining): ";
            base.EditStaffDetail(id, editOptionText);
        }

    }
}