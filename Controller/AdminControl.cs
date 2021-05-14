using System;
using helloworld.DataBaseManipulatios;
using Microsoft.Data.Sqlite;

namespace helloworld.Controller{
    public class AdminControl{
        string tableName;

        public AdminControl(string tableName)
        {
            this.tableName = tableName+"Table";
        }

        public void ViewAllStaffs(){
            ViewTable obj = new ViewTable();
            try{
                obj.ViewDataTable(tableName);}
                 catch(SqliteException e){
                    Console.WriteLine("Action failed with error code" + e.ErrorCode);
                }
        }

        public void ViewStaff(string name){
            ViewTable obj = new ViewTable();
            string query = "Select * from "+tableName+" where Username = \""+name+"\"";
            try{
                obj.ViewDataTableWithQuery(query);}
                 catch(SqliteException e){
                   Console.WriteLine("Action failed with error code" + e.ErrorCode);
                }
            
        }

        public void AddStaff(int id, string username, string password, string subject, string experience="0", string phone="nil"){
            UpdateTable obj = new UpdateTable();
            string query = "INSERT INTO "+tableName+" VALUES('"+ id+"','"+username+"','"+password+"','"+subject+"','"+experience+"','"+phone+"');";
            try{
                obj.ExecuteQuery(query);}
                catch(SqliteException e){
                   Console.WriteLine("Action failed with error code" + e.ErrorCode);
                }
            
        }
         public void EditStaff(int id, string prop, string propValue){
            UpdateTable obj = new UpdateTable();
            string query = "UPDATE "+tableName+" SET "+ prop+" = '"+propValue+"' where Id = "+id+"";
            try{
                obj.ExecuteQuery(query);}
                catch(SqliteException e){
                   Console.WriteLine("Action failed with error code" + e.ErrorCode);
                }
            
        }

         public void DeleteStaff(int id){
            UpdateTable obj = new UpdateTable();
            string query = "DELETE FROM "+ tableName+" WHERE Id="+id;
            try{
                obj.ExecuteQuery(query);}
                catch(SqliteException e){
                   Console.WriteLine("Action failed with error code" + e.ErrorCode);
                }
            
        }
    }
}