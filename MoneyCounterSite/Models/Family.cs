using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace MoneyCounterSite.Models
{
    public class Family
    {
        public string FamilyName { get; set; }
       
        public string idUserInit { get; set; }
        public string idUserAdd { get; set; }
        db db = new db();
        public int FamilyID;

        public Family()
        {

        }

        

        public int getIdFamily(string id)
        {

            if (db.sc == null || db.sc.State != System.Data.ConnectionState.Open)
                db = new db();



            db.sql = "Select idFamily from Users where chatID = @chatID";
            db.command = new SqlCommand(db.sql, db.sc);
            db.command.Parameters.AddWithValue("@chatID", id);
            db.rd = db.command.ExecuteReader();
            while (db.rd.Read())
            {

                if (DBNull.Value.Equals(db.rd["idFamily"]))
                {
                    FamilyID = -1;
                }
                else
                {
                    FamilyID = Convert.ToInt32(db.rd["idFamily"]);
                }


            }
            db.rd.Close();
            return FamilyID;
        }


        public string getNameFamily(string id)
        {

            if (db.sc == null || db.sc.State != System.Data.ConnectionState.Open)
                db = new db();



            db.sql = "SELECT f.NameFamily AS NameFamily FROM Users u INNER JOIN Families f ON u.idFamily = f.id where u.chatID = @chatID";
            db.command = new SqlCommand(db.sql, db.sc);
            db.command.Parameters.AddWithValue("@chatID", id);
            db.rd = db.command.ExecuteReader();
            while (db.rd.Read())
            {

                if (DBNull.Value.Equals(db.rd["NameFamily"]))
                {
                    FamilyName = "";
                }
                else
                {
                    FamilyName = db.rd["NameFamily"].ToString();
                }


            }
            db.rd.Close();
            return FamilyName;
        }



        public int CreateFamily(Family family)
        {


            if (db.sc == null || db.sc.State != System.Data.ConnectionState.Open)
                db = new db();



            db.sql = "INSERT INTO Families (NameFamily) VALUES (@NameFamily)";
            db.command = new SqlCommand(db.sql, db.sc);
            db.command.Parameters.AddWithValue("@NameFamily", family.FamilyName);

            try
            {
                db.command.ExecuteNonQuery();
            }
            catch 
            {

                return -1;
            }


            db.sql = "SELECT IDENT_CURRENT('dbo.Families') as idFamily";

            db.command = new SqlCommand(db.sql, db.sc);

            db.rd = db.command.ExecuteReader();
            while (db.rd.Read())
            {

                if (DBNull.Value.Equals(db.rd["idFamily"]))
                {
                    FamilyID = -1;
                }
                else
                {
                    FamilyID = Convert.ToInt32(db.rd["idFamily"]);
                }


            }
            db.rd.Close();


            return FamilyID;
        }


        public string AddUserInFamily(int idFamily, string idUser)
        {
            if (db.sc == null || db.sc.State != System.Data.ConnectionState.Open)
                db = new db();



            db.sql = "INSERT INTO Users (idFamily) VALUES (@idFamily) where chatID = @chatID";
            db.command = new SqlCommand(db.sql, db.sc);
            db.command.Parameters.AddWithValue("@idFamily", idFamily);
            db.command.Parameters.AddWithValue("@chatID", idUser);

            try
            {
                db.command.ExecuteNonQuery();
            }
            catch(Exception ex)
            {

                return ex.Message;
            }
            return "Good";

        }


       
    }
}