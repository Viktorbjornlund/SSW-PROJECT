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
    class Author
    {
        public Author(string firstname, string lastname, int birthyear, string About)
        {
            this._FirstName = firstname;
            this._LastName = lastname;
            this._BirthYear = birthyear;
            this._About = About;
        }
        public Author() { }
        private int _BirthYear, _Aid;
        private string _FirstName, _LastName, _About;

        
        public string FirstName
        {
            get { return this._FirstName; }
            set{this._FirstName = value;}
        }
        public string LastName
        {
            get { return this._LastName; }
            set { this._LastName = value; }
        }
        public int Aid
        {
            get { return this._Aid; }
            set { this._Aid = value; }
        }
        public int BirthYear
        {
            get { return this._BirthYear; }
            set { this._BirthYear = value; }
        }
        public string About
        {
            get { return this._About; }
            set { this._About = value; }
        }
        public List<Book> getBooks()
        {
            return Book.getByAuthor(this._Aid);
        }
        public static Author getByAid(int Aid)
        {
            Author newauthor = null;
            SqlConnection con = new SqlConnection(Settings.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM AUTHOR WHERE Aid=@Aid", con);
            SqlParameter paramAid = new SqlParameter("Aid", SqlDbType.Int);
            paramAid.Value = Aid;
            cmd.Parameters.Add(paramAid);

            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                if (dar.Read())
                {
                    newauthor = new Author();
                    newauthor.Aid = (int)dar["Aid"];
                    newauthor.BirthYear = (dar["BirthYear"] == DBNull.Value) ? 0 : Convert.ToInt32(dar["BirthYear"].ToString());
                    newauthor.FirstName = dar["FirstName"] as string;
                    newauthor.LastName = dar["LastName"] as string;
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
            return newauthor;
        }
        public static List<Author> getAll()
        {
            List<Author> results = new List<Author>();
            SqlConnection con = new SqlConnection(Settings.ConnectionString);
            SqlCommand cmd = new SqlCommand("SELECT * FROM AUTHOR", con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    Author newAuthor = new Author();
                    newAuthor.Aid = (int)dar["Aid"];
                    newAuthor.BirthYear = (dar["BirthYear"] == DBNull.Value) ? 0 : Convert.ToInt32(dar["BirthYear"].ToString());
                    newAuthor.FirstName = dar["FirstName"] as string;
                    newAuthor.LastName = dar["LastName"] as string;
                    results.Add(newAuthor);
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
