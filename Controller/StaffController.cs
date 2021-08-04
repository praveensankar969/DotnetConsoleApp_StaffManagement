using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotnetConsoleApp_StaffManagement.Interfaces;
using Newtonsoft.Json;
using StaffManagement;
using StaffManagement.DTO;

namespace DotnetConsoleApp_StaffManagement.Controller
{
    public class StaffController : StaffInt
    {
        string filePath = @"C:\D\Work\Dotnet\DotnetConsoleApp_StaffManagement\DataStore.json";

        public void GetStaff(int id)
        {
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            var res = staffs.FirstOrDefault(x => x.Id == id);
            Console.WriteLine("Details of Staff " + id + " are:");
            Console.WriteLine("Name: " + res.UserName + " \tDate of Joining: " + res.DateOfJoining + " \tExperience: " + res.Experience + " \tSubject: " + res.Subject + " \tPhone: " + res.PhoneNumber);
        }

        public void AddStaff(Staff staff)
        {
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            staffs.Add(staff);
            string jsonResult = JsonConvert.SerializeObject(staffs);
            File.WriteAllText(filePath, jsonResult);
        }

        public void EditStaff(int id, StaffUpdateDTO staffDTO)
        {
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            var res = staffs.FirstOrDefault(x => x.Id == id);
            if (res != null)
            {
                res.UserName = staffDTO.UserName ?? res.UserName;
                res.DateOfJoining = staffDTO.DateOfJoining ?? res.DateOfJoining;
                res.Password = staffDTO.Password ?? res.Password;
                res.PhoneNumber = staffDTO.PhoneNumber ?? res.PhoneNumber;
                res.Subject = staffDTO.Subject ?? res.Subject;
                if (res.Admin)
                {
                    res.Admin = staffDTO.Admin;
                }
            }
            string jsonResult = JsonConvert.SerializeObject(staffs);
            File.WriteAllText(filePath, jsonResult);

        }
        public void DeleteStaff(int id)
        {
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            var res = staffs.FirstOrDefault(x => x.Id == id);
            staffs.Remove(res);
            string jsonResult = JsonConvert.SerializeObject(staffs);
            File.WriteAllText(filePath, jsonResult);
        }
    }
}
