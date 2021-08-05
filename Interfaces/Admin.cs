using System.Collections.Generic;
using DotnetConsoleApp_StaffManagement.DTO;
using StaffManagement;

namespace DotnetConsoleApp_StaffManagement.Interfaces
{
    public interface Actions
    {
        public void AddStaff();
        public List<Modal> GetStaff();
        public void GetStaffWithID();
        public void EditStaffDetail(int id);
        public void DeleteStaff(int id);
    }
}