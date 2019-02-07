using MeuTrabalho.Models;
using MeuTrabalho.Repo;
using Microsoft.AspNetCore.Mvc;

namespace MeuTrabalho.Controllers
{
    public class AccountController : Controller
    {
        private ILoginRepository _login;
        public AccountController(ILoginRepository loginRepository)
        {
            _login = loginRepository;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Index(LoginViewModel model)
        {
            /// TODO: Pegar o usuário
            if (_login.UsuarioValido(model.Email, model.Password))
                return RedirectToAction("Dashboard", "Home", new { name = "" });
            else
                return View(model);
        }
    }
}
