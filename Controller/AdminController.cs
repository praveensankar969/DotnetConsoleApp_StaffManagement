using System;
using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;
using StaffManagement.DTO;
using System.IO;
using DotnetConsoleApp_StaffManagement.DTO;
using DotnetConsoleApp_StaffManagement.Interfaces;

namespace StaffManagement.Controller
{
    public class AdminControl : Admin
    {
        string filePath = @"C:\D\Work\Dotnet\DotnetConsoleApp_StaffManagement\DataStore.json";
        public void GetAllStaff(bool admin)
        {
            if(admin){
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);;
            Console.WriteLine("Details of Staff are:");
            for(int i=0;i<staffs.Count;i++){
               Console.WriteLine("Name: "+ staffs[i].UserName +" \tDate of Joining: "+ staffs[i].DateOfJoining +" \tExperience: "+ staffs[i].Experience +  " \tSubject: "+ staffs[i].Subject +" \tPhone: "+ staffs[i].PhoneNumber); 
            }  
            }
            else{
                Console.WriteLine("No access");
            }
                  
        }

        public void GetStaff(bool admin, int id)
        {
           if(admin){
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            var res = staffs.FirstOrDefault(x => x.Id == id);
            Console.WriteLine("Details of Staff "+ id +" are:");
            Console.WriteLine("Name: "+ res.UserName +" \tDate of Joining: "+ res.DateOfJoining +" \tExperience: "+ res.Experience +  " \tSubject: "+ res.Subject +" \tPhone: "+ res.PhoneNumber);
           }
           else{
                Console.WriteLine("No access");
            }
        }

        public void AddStaff(bool admin,Staff staff)
        {
            if(admin){
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            staffs.Add(staff);
            string jsonResult = JsonConvert.SerializeObject(staffs);
            File.WriteAllText(filePath, jsonResult);
            }else{
                Console.WriteLine("No access");
            }
        }

        public void EditStaff(User user, int id, StaffUpdateDTO staffDTO)
        {
            if(user.Id == id || user.Admin){
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
            }else{
                Console.WriteLine("No access for edit");
            }

        }
        public void DeleteStaff(User user, int id)
        {
            if(user.Id == id || user.Admin){
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            var res = staffs.FirstOrDefault(x => x.Id == id);
            staffs.Remove(res);
            string jsonResult = JsonConvert.SerializeObject(staffs);
            File.WriteAllText(filePath, jsonResult);
            }else{
                Console.WriteLine("No access");
            }
        }

        public User Login(LoginDTO login){
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            var res = staffs.FirstOrDefault(x => x.UserName == login.UserName);
            if(res ==null){
                return new User{Id = -1, Admin=false};
            }
            else{
                if(res.Password == login.Password){
                    return new User{Id= res.Id, Admin = res.Admin};
                }  
                return new User{Id = -1, Admin=false};       
            }

        }
    }


}