namespace DotnetConsoleApp_StaffManagement.DTO
{
    public class StaffDTO
    {
    public string UserName { get; set; } 
    public string Password { get; set; }

    public string  Subject { get; set; }

    public int Experience { get; set; }

    public string DateOfJoining { get; set; }

    public string PhoneNumber { get; set; }

    public bool Admin {get; set;}
    }
}