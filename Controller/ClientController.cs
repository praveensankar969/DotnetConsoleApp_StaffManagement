using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using StaffManagement.View;
using Newtonsoft.Json;
using StaffManagement.DTO;

namespace StaffManagement.Controller
{

    public class ClientControl
    {
        private readonly HttpClient client;

        public string _staffType { get; }

        public ClientControl(HttpClient _client, string staffType)
        {
            client = _client;
            _staffType = staffType;
            client.BaseAddress = new Uri("https://localhost:5001/api/");
        }
        public void GetAllStaff()
        {
            HttpResponseMessage response = client.GetAsync(_staffType).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data Read from API success !");
                var result = response.Content.ReadAsStringAsync().Result;
                List<TeacherView> object1 = JsonConvert.DeserializeObject<List<TeacherView>>(result);
                for(int i=0;i<object1.Count;i++){
                    
                    Console.Write("Id: " + object1.ElementAt(i).Id);
                    Console.Write(" Name: " + object1.ElementAt(i).UserName); 
                    Console.Write(" Phone: " + object1.ElementAt(i).PhoneNumber);
                    Console.Write(" Experience: " + object1.ElementAt(i).Experience);
                    Console.Write(" Subject: " + object1.ElementAt(i).Subject);
                    Console.Write(" Date of Joining: " + object1.ElementAt(i).DateOfJoining);
                    Console.WriteLine("");
                }
                
            }
            else
            {
                Console.WriteLine("Data Read failed" + response.StatusCode);
                Console.WriteLine(response.ReasonPhrase);
            }

        }

        public void GetStaff(string id)
        {
            HttpResponseMessage response = client.GetAsync(_staffType+"/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data Read from API success !");
                var result = response.Content.ReadAsStringAsync().Result;
                TeacherView staffObj = JsonConvert.DeserializeObject<TeacherView>(result);
                Console.WriteLine(staffObj.UserName);
            }
            else
            {
                Console.WriteLine("Data Read failed" + response.StatusCode);
                Console.WriteLine(response.ReasonPhrase);
            }
        }

        public void AddStaff(StaffDTO staff)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(_staffType+"/addStaff", staff).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data added sucessfully");
            }
            else
            {
                Console.WriteLine("Data added failed" + response.ReasonPhrase);
            }
        }

        public void EditStaff(StaffUpdateDTO staff)
        {
            Console.WriteLine();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(staff), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PatchAsync(_staffType+"/"+staff.Id, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data edited sucessfully");
            }
            else
            {
                Console.WriteLine("Data edit failed " + response.StatusCode);
            }
        }
        public void AddStaff(TeacherDTO staff)
        {
            HttpResponseMessage response = client.PostAsJsonAsync(_staffType+"/addStaff", staff).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data added sucessfully");
            }
            else
            {
                Console.WriteLine("Data added failed" + response.ReasonPhrase);
            }
        }

        public void EditStaff(TeacherUpdateDTO staff)
        {
            Console.WriteLine();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(staff), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PatchAsync(_staffType+"/"+staff.Id, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data edited sucessfully");
            }
            else
            {
                Console.WriteLine("Data edit failed " + response.StatusCode);
            }
        }


        public void DeleteStaff(int id)
        {
            HttpResponseMessage response = client.DeleteAsync("staff/"+id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data delete sucessfully");
            }
            else
            {
                Console.WriteLine("Data delete failed" + response.ReasonPhrase);
            }
        }
    }


}