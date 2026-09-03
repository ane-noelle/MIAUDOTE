using Miaudote.Web.Data;
using Miaudote.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Miaudote.Web.Controllers;

public class ContatoController : Controller
{
    private readonly AppDbContext _contexto;

    public ContatoController(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Index(
        string Nome,
        string Email,
        string Assunto,
        string Mensagem)
    {
        Console.WriteLine($"Nome: {Nome}");
        Console.WriteLine($"Email: {Email}");
        Console.WriteLine($"Assunto: {Assunto}");
        Console.WriteLine($"Mensagem: {Mensagem}");

        var mensagemContato = new MensagemContato
        {
            Nome = Nome,
            Email = Email,
            Assunto = Assunto,
            Mensagem = Mensagem,
            DataEnvio = DateTime.Now
        };

        await _contexto.MensagensContato.AddAsync(
            mensagemContato
        );

        await _contexto.SaveChangesAsync();

        TempData["Sucesso"] =
            "Mensagem enviada com sucesso!";

        return RedirectToAction(nameof(Index));
    }
}