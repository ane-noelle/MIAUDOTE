using Microsoft.AspNetCore.Mvc;

namespace Miaudote.Web.Controllers;

public class InstitucionalController : Controller
{
    public IActionResult Sobre()
    {
        return View();
    }

    public IActionResult ComoFunciona()
    {
        return View();
    }
}