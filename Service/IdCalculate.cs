using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using StaffManagement;

namespace DotnetConsoleApp_StaffManagement.Service
{
    public static class IdCalculate
    {
        public static int ComputeId(){
            string filePath = @"C:\D\Work\Dotnet\DotnetConsoleApp_StaffManagement\DataStore.json";
            var json = File.ReadAllText(filePath);
            List<Staff> staffs = JsonConvert.DeserializeObject<List<Staff>>(json);
            return staffs.Count + 1;
        }
    }
}