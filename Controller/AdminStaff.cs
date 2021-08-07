using System;
using StaffManagement;
using Procedure;

namespace DotnetConsoleApp_StaffManagement.Controller
{
    public class AdminStaff : Staff
    {
        
        public override void AddStaff()
        {     
            base.AddStaff();
            Console.Write("Staff Type(Admin/Staff/Support): ");
            Type = Console.ReadLine();

            if (Type != "Admin")
            {
                Console.Write("Subject: ");
                Subject = Console.ReadLine();
            }

            SQLProcedure obj = new SQLProcedure();
            obj.Insert(this);
            
        }

        public override void EditStaffDetail<T>(T staff, string defaultText="")
        {   
            string editOptionText = "Enter one property name to edit: (UserName , Password , Subject , Experience, PhoneNumber, DateOfJoining, Type): ";
            base.EditStaffDetail(staff, editOptionText);
        }
       
    }
}