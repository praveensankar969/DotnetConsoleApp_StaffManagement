using System;
using DotnetConsoleApp_StaffManagement.DTO;
using Microsoft.Extensions.Configuration;
using Procedure;
using StaffManagement;
using StaffManagement.View;

namespace DotnetConsoleApp_StaffManagement.Controller
{
    public class TeachingStaff : Staff
    {
        private static IConfiguration _iconfiguration;
        public override void AddStaff()
        {
            base.AddStaff();
            Console.Write("Subject: ");
            Subject = Console.ReadLine();
            Type = "Teaching Staff";
            SQLProcedure obj = new SQLProcedure();
            obj.Insert(this);
            InitialLandingPage.LogonMain();
        }

        public override void EditStaffDetail<T>(T staff, string defaultText = "")
        {
            string editOptionText = "Enter one property to edit: (UserName , Password , Subject , Experience, PhoneNumber, DateOfJoining): ";
            base.EditStaffDetail(staff, editOptionText);
        }

    }
}