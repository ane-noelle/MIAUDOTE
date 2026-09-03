using Microsoft.AspNetCore.Mvc;

namespace Miaudote.Web.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string email, string senha)
    {
        if (email == "admin@miaudote.com.br" &&
            senha == "123456")
        {
            return RedirectToAction(
                "Index",
                "Administrador");
        }

        ViewBag.Erro = "E-mail ou senha inválidos.";

        return View();
    }
}