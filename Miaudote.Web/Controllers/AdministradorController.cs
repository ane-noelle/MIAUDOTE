using Miaudote.Web.Data;
using Miaudote.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Miaudote.Web.Controllers;

public class AdministradorController : Controller
{
    private readonly AppDbContext _contexto;

    public AdministradorController(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<IActionResult> Index()
    {
        ViewBag.TotalAnimais =
            await _contexto.Animais.CountAsync();

        ViewBag.Pendentes =
            await _contexto.SolicitacoesAdocao
                .CountAsync(s =>
                    s.Status == StatusSolicitacao.Pendente);

        ViewBag.Aprovadas =
            await _contexto.SolicitacoesAdocao
                .CountAsync(s =>
                    s.Status == StatusSolicitacao.Aprovada);

        ViewBag.Recusadas =
            await _contexto.SolicitacoesAdocao
                .CountAsync(s =>
                    s.Status == StatusSolicitacao.Recusada);

        return View();
    }
}