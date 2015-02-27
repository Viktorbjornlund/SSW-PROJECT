using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace BL
{
    public class Books
    {
        static Books()
        {
        }

        private string _title, _isbn;
        public string Title
        {
            get { return this._title; }
        }
        public string Isbn
        {
            get { return this._isbn; }
        }
        public static List<Books> search(string query)
        {
            string sql = "SELECT BOOK.* FROM BOOK WHERE Title LIKE '%" + query + "%'";
            List<Books> results = new List<Books>();
            
        }
    }
}
