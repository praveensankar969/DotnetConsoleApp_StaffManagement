using DotnetConsoleApp_StaffManagement.DTO;
using StaffManagement;

namespace DotnetConsoleApp_StaffManagement.Interfaces
{
    public interface Admin
    {
        public void AddStaff();
        public void GetAllStaff();
        public void GetStaff(int id);
        public void EditStaff(int id);
        public void DeleteStaff(int id);
    }
}