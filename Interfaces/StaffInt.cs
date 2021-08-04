using StaffManagement;
using StaffManagement.DTO;

namespace DotnetConsoleApp_StaffManagement.Interfaces
{
    public interface StaffInt
    {
        public void GetStaff(int id);
        public void AddStaff(Staff staff);
        public void EditStaff(int id, StaffUpdateDTO staffDTO);
        public void DeleteStaff(int id);

    }
}