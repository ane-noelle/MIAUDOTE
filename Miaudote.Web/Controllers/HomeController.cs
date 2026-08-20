using System.Diagnostics;
using Miaudote.Web.Data;
using Miaudote.Web.Enums;
using Miaudote.Web.Models;
using Miaudote.Web.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Miaudote.Web.Controllers;

public class HomeController : Controller
{
    private readonly AppDbContext _contexto;
    private readonly ILogger<HomeController> _logger;

    public HomeController(
        AppDbContext contexto,
        ILogger<HomeController> logger)
    {
        _contexto = contexto;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        var animais = await _contexto.Animais
            .AsNoTracking()
            .Include(animal => animal.Especie)
            .Include(animal => animal.Cidade)
            .Include(animal => animal.AnimaisTemperamentos)
                .ThenInclude(animalTemperamento =>
                    animalTemperamento.Temperamento)
            .Where(animal =>
                animal.Ativo &&
                animal.Status == StatusAnimal.Disponivel)
            .OrderByDescending(animal => animal.DataCadastro)
            .ThenBy(animal => animal.Nome)
            .ToListAsync();

        var quantidadeAdocoesConcluidas =
            await _contexto.SolicitacoesAdocao
                .AsNoTracking()
                .CountAsync(solicitacao =>
                    solicitacao.Status ==
                    StatusSolicitacao.Concluida);

        var viewModel = new HomeIndexViewModel
        {
            Animais = animais,
            QuantidadeAnimaisDisponiveis = animais.Count,
            QuantidadeAdocoesConcluidas =
                quantidadeAdocoesConcluidas
        };

        return View(viewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(
        Duration = 0,
        Location = ResponseCacheLocation.None,
        NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel
            {
                RequestId =
                    Activity.Current?.Id ??
                    HttpContext.TraceIdentifier
            }
        );
    }
}