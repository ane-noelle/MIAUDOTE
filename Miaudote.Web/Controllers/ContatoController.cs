using Microsoft.AspNetCore.Mvc;

namespace Miaudote.Web.Controllers;

public class ContatoController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}
