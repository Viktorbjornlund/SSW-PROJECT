using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.ComponentModel.DataAnnotations;

namespace BL
{
    public class Book
    {
        static Book()
        {
        }

        private string _title, _isbn, _publicationYear, _pages;
        public string Title
        {
            get { return this._title; }
        }
        public string Isbn
        {
            get { return this._isbn; }
        }
        public string PublicationYear
        {
            get { return this._publicationYear; }
        }
        public string Pages
        {
            get { return this._pages; }
        }
        public List<Book> search(string query)
        {
            string sql = "SELECT BOOK.* FROM BOOK WHERE Title LIKE '%" + query + "%'";
            List<Book> results = new List<Book>();
            SqlConnection con = new SqlConnection(Settings.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    Book book = new Book();
                    book._title = dar["Title"] as string;
                    book._isbn = dar["Isbn"] as string;
                    book._publicationYear = dar["PublicationYear"] as string;
                    book._pages = dar["Pages"] as string;
                    results.Add(book);
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
        public List<Book> getAll()
        {
            string sql = "SELECT * FROM BOOK";
            List<Book> results = new List<Book>();
            SqlConnection con = new SqlConnection(Settings.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    Book book = new Book();
                    book._title = dar["Title"] as string;
                    book._isbn = dar["Isbn"] as string;
                    book._publicationYear = dar["PublicationYear"] as string;
                    book._pages = dar["Pages"] as string;
                    results.Add(book);
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
        public static List<Book> getByAuthor(int authorID)
        {
            string sql = "SELECT BOOK.* FROM BOOK " +
                "INNER JOIN BOOK_AUTHOR ON BOOK_AUTHOR.ISBN=BOOK.ISBN " +
                "WHERE BOOK_AUTHOR.Aid=" + authorID;
            List<Book> results = new List<Book>();
            SqlConnection con = new SqlConnection(Settings.ConnectionString);
            SqlCommand cmd = new SqlCommand(sql, con);
            try
            {
                con.Open();
                SqlDataReader dar = cmd.ExecuteReader();
                while (dar.Read())
                {
                    Book book = new Book();
                    book._title = dar["Title"] as string;
                    book._isbn = dar["Isbn"] as string;
                    book._publicationYear = dar["PublicationYear"] as string;
                    book._pages = dar["Pages"] as string;
                    results.Add(book);
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
