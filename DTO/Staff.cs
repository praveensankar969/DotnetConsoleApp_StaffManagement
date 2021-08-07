
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using Procedure;

namespace StaffManagement

{
    public abstract class Staff
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        private int _experience;
        public int Experience
        {
            get
            {
                return _experience;
            }
            set
            {
                if (value > 30)
                {
                    throw new Exception("Experience cannot be greater than 30");
                }
                else if (value < 0)
                {
                    throw new Exception("Experience cannot be less than 0");
                }
                else
                {
                    _experience = value;
                }
            }
        }
        private DateTime _date;
        public DateTime DateOfJoining
        {
            get
            {
                return _date;
            }
            set
            {
                if (value > DateTime.Now)
                {
                    throw new Exception("Joining Date cannot be in future");
                }
                else
                {
                    _date = value;
                }
            }
        }
        private string _phone;
        public string PhoneNumber
        {
            get
            {
                return _phone;
            }
            set
            {
                if (value.Length > 10 || value.Length < 10)
                {
                    throw new Exception("Phone number should be 10 digits");
                }
                else
                {
                    _phone = value;
                }
            }
        }
        public string Subject { get; set; }
        public string Type { get; set; }


        public void GetStaff()
        {
            SQLProcedure obj = new SQLProcedure();
            obj.GetAllData();
        }
        public void GetStaffWithID()
        {
            Console.Write("Enter Id of staff to view : ");
            int id = Convert.ToInt32(Console.ReadLine());
            SQLProcedure obj = new SQLProcedure();
            obj.GetDataOfId(id);
        }
        public virtual void AddStaff()
        {
            Console.WriteLine("Enter details of new staff");

            Console.Write("UserName: ");
            UserName = Console.ReadLine();

            Console.Write("Password: ");
            Password = Console.ReadLine();

            Console.Write("Experience: ");
            int exp;
            while (!int.TryParse(Console.ReadLine(), out exp))
            {
                Console.Write("This is an invalid input, please enter a number");
            }
            try
            {
                Experience = exp;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Experience: ");
                Experience = Convert.ToInt32(Console.ReadLine());
            }
            Console.Write("Phone: ");
            try
            {
                PhoneNumber = Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("Phone: ");
                PhoneNumber = Console.ReadLine();
            }

            Console.Write("Date of Joining: ");
            try
            {
                DateOfJoining = DateTime.Parse(Console.ReadLine());
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.Write("DateOfJoining: ");
                DateOfJoining = DateTime.Parse(Console.ReadLine());

            }


        }
        public virtual void EditStaffDetail<T>(T classObj, string text)
        {
            do
            {
                int exp;
                bool flag = false;
                Console.Write(text);
                var property = Console.ReadLine();
                var propInfo = classObj.GetType().GetProperty(property);
                if (propInfo == null)
                {
                    Console.WriteLine("Wrong PropertyName");
                    break;
                }


                if (property == "Experience")
                {
                    do
                    {
                        flag = true;
                        Console.Write("Enter new value: ");
                        while (!int.TryParse(Console.ReadLine(), out exp))
                        {
                            Console.Write("This is an invalid input, please enter a number: ");
                        }
                        try
                        {
                            propInfo.SetValue(classObj, exp);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            flag = false;

                        }
                    } while (!flag);

                }
                else if (property == "DateOfJoining")
                {

                    do
                    {
                        flag = true;
                        Console.Write("Enter new value: ");
                        var value = DateTime.Parse(Console.ReadLine());
                        try
                        {
                            propInfo.SetValue(classObj, value);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            flag = false;
                        }
                    }
                    while (!flag);
                }
                else
                {
                    do
                    {
                        flag = true;
                        Console.Write("Enter new value: ");
                        var value = Console.ReadLine();
                        try
                        {
                            propInfo.SetValue(classObj, value);

                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                            flag = false;
                        }
                    }
                    while (!flag);
                }
            } while (Continue("edit"));

            SQLProcedure obj = new SQLProcedure();
            obj.Update(classObj);

        }
        public void DeleteStaff(int id)
        {
            SQLProcedure obj = new SQLProcedure();
            obj.DeleteDataOfId(id);
        }


        public static bool Continue(string edit)
        {

            Console.Write("\nDo you wish to edit another detail of this staff? (y/n) : ");
            string res = Console.ReadLine();
            return res == "y" || res == "Y" ? true : false;
        }

    }
}