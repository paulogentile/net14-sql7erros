using MeuTrabalho.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Data;
using System.Data.SqlClient;

namespace MeuTrabalho.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            try
            {
                SqlConnection connection = new SqlConnection("Server=.;Database=MEUDB;User=sa;Password=123456;");
                SqlCommand cmd = new SqlCommand($"SELECT username FROM tbLogin WHERE email=@Email AND pwd=@Pass", connection);

                cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = model.Email;
                cmd.Parameters.Add("@Pass", SqlDbType.VarChar).Value = model.Password;

                if (connection.State == ConnectionState.Closed)
                    connection.Open();

                string username = (string)cmd.ExecuteScalar();

                if (connection.State == ConnectionState.Open)
                    connection.Close();

                return RedirectToAction("Dashboard", "Home", new { name = username});
            }
            catch(Exception ex)
            {
                return View(model);
            }
        }
    }
}
