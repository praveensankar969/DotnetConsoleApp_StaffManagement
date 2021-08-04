using DotnetConsoleApp_StaffManagement.DTO;
using StaffManagement;
using StaffManagement.DTO;

namespace DotnetConsoleApp_StaffManagement.Interfaces
{
    public interface Admin
    {
        public void AddStaff(bool admin, Staff Staff);
        public void GetAllStaff(bool admin);
        public void GetStaff(bool admin, int id);
        public void EditStaff(User user, int id, StaffUpdateDTO staffDTO);
        public void DeleteStaff(User user, int id);
    }
}