using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MoneyCounterSite.Models
{
    public class User
    {
        db db = new db();
        public string UserName { get; set; }
        public string UserID { get; set; }

        public User() { }
        public User(string userName, string userID)
        {
            UserName = userName;
            UserID = userID;
        }
        
        public string getUserById(string id )
        {
            
            if (db.sc == null || db.sc.State != System.Data.ConnectionState.Open)
                db = new db();

            db.sql = "Select nameUser from Users where chatID = @chatID";
            db.command = new SqlCommand(db.sql, db.sc);
            db.command.Parameters.AddWithValue("@chatID", id);
            db.rd = db.command.ExecuteReader();
            while (db.rd.Read())
            {
                UserName =db.rd["nameUser"].ToString();
            }
            db.rd.Close();
            return UserName;
        }



        public List<User> GetFamilyMembers(string idUser)
        {
            List<User> familyMembers = new List<User>();

            if (db.sc == null || db.sc.State != System.Data.ConnectionState.Open)
                db = new db();



            db.sql = @"SELECT u.nameUser as NameUser, u.chatID as UserID  from Users u WHERE idFamily in (SELECT  f.id AS NameFamily
                        FROM Users u
                    INNER JOIN Families f ON u.idFamily = f.id WHERE u.chatID = @chatID)";
            db.command = new SqlCommand(db.sql, db.sc);
            db.command.Parameters.AddWithValue("@chatID", idUser);
            db.rd = db.command.ExecuteReader();
            while (db.rd.Read())
            {


                
                familyMembers.Add(new User(db.rd["NameUser"].ToString(), db.rd["UserID"].ToString()));


            }
            db.rd.Close();

            return familyMembers;
        }
    }
}