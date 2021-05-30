using System;
using StaffManagement.View;

namespace StaffManagement{ 
    public class Startup{ 
        public static void Main(string[] args){ 
           
            InitialLandingPage logon = new InitialLandingPage();
            logon.LogonMain();
        }
    }
}