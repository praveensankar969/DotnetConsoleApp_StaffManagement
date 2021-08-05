//not used here
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotnetConsoleApp_StaffManagement.DTO;
using DotnetConsoleApp_StaffManagement.Interfaces;
using Newtonsoft.Json;

namespace StaffManagement
{
    public abstract class Staff 
    {
        string filePath = @"C:\D\Work\Dotnet\DotnetConsoleApp_StaffManagement\DataStore.json";

        public List<Modal> GetStaff()
        {
            Console.Write("Enter Id of staff to view : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var json = File.ReadAllText(filePath);
            List<Modal> staffs = JsonConvert.DeserializeObject<List<Modal>>(json);
            return staffs;
        }
        public void GetStaffWithID()
        {
            Console.Write("Enter Id of staff to view : ");
            int id = Convert.ToInt32(Console.ReadLine());
            var json = File.ReadAllText(filePath);
            List<Modal> staffs = JsonConvert.DeserializeObject<List<Modal>>(json);
            var res = staffs.FirstOrDefault(x => x.Id == id);
            Console.WriteLine("Details of Staff " + id + " are:");
            Console.WriteLine("Name: " + res.UserName + " \tDate of Joining: " + res.DateOfJoining + " \tExperience: " + res.Experience + " \tSubject: " + res.Subject + " \tPhone: " + res.PhoneNumber + " \tType: " + res.Type);
        }
        public abstract void AddStaff();
        public abstract void EditStaffDetail(int id);
        public void DeleteStaff(int id)
        {
            var json = File.ReadAllText(filePath);
            List<Modal> staffs = JsonConvert.DeserializeObject<List<Modal>>(json);
            var res = staffs.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                Console.WriteLine("No Data to delete");
            }
            else
            {
                staffs.Remove(res);
                string jsonResult = JsonConvert.SerializeObject(staffs);
                File.WriteAllText(filePath, jsonResult);
            }
        }
    }
}