using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MeuTrabalho.Controllers
{
    public class HomeController : Controller, IDisposable
    {
        SqlConnection connection;

        public HomeController()
        {
            this.connection = new SqlConnection("Server=.;Database=MEUDB;User=sa;Password=123456;");
        }

        public IActionResult Index()
        {
            return RedirectToActionPermanent("Index", "Account");
        }

        public IActionResult Dashboard(string name)
        {
            if( name == null )
            {
                throw new ArgumentNullException(name);
            }

            ViewBag.Name = name;
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            try
            {
                if (this.connection.State == System.Data.ConnectionState.Closed)
                    this.connection.Open();

                SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('about')", this.connection);
                sql.ExecuteNonQuery();

                if (this.connection.State == System.Data.ConnectionState.Open)
                    this.connection.Close();
            }
            catch(Exception ex)
            {
                ViewData["Message"] = "ERROR ABOUT";
            }

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            try
            {
                if (this.connection.State == ConnectionState.Closed)
                    this.connection.Open();

                SqlCommand sql = new SqlCommand("INSERT tbLog VALUES ('contact')", this.connection);
                sql.ExecuteNonQuery();

                if (this.connection.State == ConnectionState.Open)
                    this.connection.Close();
            }
            catch(Exception ex)
            {
                return RedirectToAction("Error");
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }
    }
}
