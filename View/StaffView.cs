using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace helloworld.View{
     public class StaffView{
    
    public int Id { get; set; }
    public string UserName { get; set; } 
    public string Password { get; set; }

    public string  Subject { get; set; }

    public int Experience { get; set; }

    public string DateOfJoining { get; set; }

    public string PhoneNumber { get; set; }

   }
}