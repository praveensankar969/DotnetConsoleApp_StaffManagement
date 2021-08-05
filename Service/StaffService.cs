using System.Collections.Generic;
using System.IO;
using System.Linq;
using DotnetConsoleApp_StaffManagement.DTO;
using Newtonsoft.Json;
using StaffManagement;

namespace Service
{
    public static class StaffService
    {
        static string filePath = @"C:\D\Work\Dotnet\DotnetConsoleApp_StaffManagement\DataStore.json";
        public static int ComputeId()
        {
            var json = File.ReadAllText(filePath);
            List<Modal> staffs = JsonConvert.DeserializeObject<List<Modal>>(json);
            return staffs.Count + 1;
        }


        public static User Login(LoginDTO login)
        {
            var json = File.ReadAllText(filePath);
            List<Modal> staffs = JsonConvert.DeserializeObject<List<Modal>>(json);
            var res = staffs.FirstOrDefault(x => x.UserName == login.UserName);
            if (res == null)
            {
                return new User { Id = -1, Type="" };
            }
            else
            {
                if (res.Password == login.Password)
                {
                    return new User { Id = res.Id, Type = res.Type };
                }
                return new User { Id = -1, Type = "" };
            }
        }

    }
}