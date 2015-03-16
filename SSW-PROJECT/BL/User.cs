using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;
using System.Web;

namespace BL
{
    public class User
    {
        public User(string username, string password, string firstname, string lastname, string email, string tel)
        {
            this._UserName = username;
            this._Password = password;
            this._FirstName = firstname;
            this._LastName = lastname;
            this._Email = email;
            this._Tel = tel;
        }
        public User() { }
        private int _Uid;
        private string _UserName, _Password, _FirstName, _LastName, _Email, _Tel;

        public string UserName
        {
            get { return this._UserName; }
            set { this._UserName = value; }
        }
        public int Uid
        {
            get { return this._Uid; }
            set { this._Uid = value; }
        }
        public string Password
        {
            get { return this._Password; }
            set { this._Password = value; }
        }
        public string FirstName
        {
            get { return this._FirstName; }
            set { this._FirstName = value; }
        }
        public string LastName
        {
            get { return this._LastName; }
            set { this._LastName = value; }
        }
        public string Email
        {
            get { return this._Email; }
            set { this._Email = value; }
        }
        public string Tel
        {
            get { return this._Tel; }
            set { this._Tel = value; }
        }

        public User getUser(string userName)
        {
            User oneUser = new User();
            SqlConnection con = new SqlConnection(Settings.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT " + userName + " FROM BORROWER", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                oneUser.Uid = (int)dar["Uid"];
                oneUser.UserName = dar["UserName"] as string;
                oneUser.Password = dar["Password"] as string;
                oneUser.FirstName = dar["FirstName"] as string;
                oneUser.LastName = dar["LastName"] as string;
                oneUser.Email = dar["Email"] as string;
                oneUser.Tel = dar["Tel"] as string;
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return oneUser;
        }

        public static List<User> getAll()
        {
            List<User> results = new List<User>();
            SqlConnection con = new SqlConnection(Settings.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM BORROWER", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    User newUser = new User();
                    newUser.Uid = (int)dar["Uid"];
                    newUser.UserName = dar["UserName"] as string;
                    newUser.Password = dar["Password"] as string;
                    newUser.FirstName = dar["FirstName"] as string;
                    newUser.LastName = dar["LastName"] as string;
                    newUser.Email = dar["Email"] as string;
                    newUser.Tel = dar["Tel"] as string;
                    results.Add(newUser);
                }
            }
            catch (Exception er)
            {
                throw er;
            }
            finally
            {
                con.Close();
            }
            return results;
        }
    }
}
