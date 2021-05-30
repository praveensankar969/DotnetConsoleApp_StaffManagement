using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using helloworld.View;
using Newtonsoft.Json;
using StaffManagement.DTO;

namespace StaffManagement.Controller
{

    public class ClientControl
    {
        private readonly HttpClient client;

        public ClientControl(HttpClient _client)
        {
            client = _client;
            client.BaseAddress = new Uri("https://localhost:5001/api/");
        }
        public void GetAllStaff()
        {
            HttpResponseMessage response = client.GetAsync("staff").Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data Read from API success !");
                var result = response.Content.ReadAsStringAsync().Result;
                List<StaffView> object1 = JsonConvert.DeserializeObject<List<StaffView>>(result);
                Console.Write("Name: " + object1.ElementAt(0).UserName);
                Console.Write(" Phone: " + object1.ElementAt(0).PhoneNumber);
            }
            else
            {
                Console.WriteLine("Data Read failed" + response.StatusCode);
                Console.WriteLine(response.ReasonPhrase);
            }

        }

        public void GetStaff(string id)
        {
            HttpResponseMessage response = client.GetAsync("staff/" + id).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data Read from API success !");
                var result = response.Content.ReadAsStringAsync().Result;
                StaffView staffObj = JsonConvert.DeserializeObject<StaffView>(result);
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
            HttpResponseMessage response = client.PostAsJsonAsync("/staff", staff).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data added sucessfully");
            }
            else
            {
                Console.WriteLine("Data added failed");
            }
        }

        public void EditStaff(StaffUpdateDTO staff)
        {
            Console.WriteLine();
            HttpContent httpContent = new StringContent(JsonConvert.SerializeObject(staff), Encoding.UTF8, "application/json");
            HttpResponseMessage response = client.PatchAsync("/staff/"+staff.Id, httpContent).Result;
            if (response.IsSuccessStatusCode)
            {
                Console.WriteLine("Data added sucessfully");
            }
            else
            {
                Console.WriteLine("Data added failed " + response.StatusCode);
            }
        }


    }


}