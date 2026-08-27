using Miaudote.Web.Data;
using Miaudote.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Miaudote.Web.Controllers;

public class AdocaoController : Controller
{
    private readonly AppDbContext _contexto;

    public AdocaoController(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    [HttpGet]
    public async Task<IActionResult> Solicitar(int id)
    {
        var animal = await _contexto.Animais
            .AsNoTracking()
            .Include(a => a.Especie)
            .Include(a => a.Cidade)
            .FirstOrDefaultAsync(a =>
                a.Id == id &&
                a.Ativo);

        if (animal == null)
        {
            return NotFound();
        }

        var solicitacao = new SolicitacaoAdocao
        {
            AnimalId = animal.Id,
            Animal = animal
        };

        return View(solicitacao);
    }
}