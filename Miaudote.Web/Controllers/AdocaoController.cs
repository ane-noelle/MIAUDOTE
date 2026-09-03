using Miaudote.Web.Data;
using Miaudote.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Miaudote.Web.Enums;

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

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Solicitar(
        SolicitacaoAdocao solicitacao)
    {
        if (!ModelState.IsValid)
        {
            solicitacao.Animal = await _contexto.Animais
                .Include(a => a.Especie)
                .Include(a => a.Cidade)
                .FirstOrDefaultAsync(a =>
                    a.Id == solicitacao.AnimalId);

            return View(solicitacao);
        }

        solicitacao.Id = 0;
        solicitacao.DataSolicitacao = DateTime.Now;

        await _contexto.SolicitacoesAdocao.AddAsync(solicitacao);

        await _contexto.SaveChangesAsync();

        TempData["Sucesso"] =
            "Solicitação enviada com sucesso!";

        return RedirectToAction(
            nameof(Solicitar),
            new { id = solicitacao.AnimalId });
    }

    public async Task<IActionResult> Solicitacoes()
    {
        var solicitacoes = await _contexto.SolicitacoesAdocao
            .AsNoTracking()
            .Include(s => s.Animal)
            .OrderByDescending(s => s.DataSolicitacao)
            .ToListAsync();

        return View(solicitacoes);
    }

    public async Task<IActionResult> Aprovar(int id)
    {
        var solicitacao = await _contexto.SolicitacoesAdocao
            .FirstOrDefaultAsync(s => s.Id == id);

        if (solicitacao == null)
        {
            return NotFound();
        }

        solicitacao.Status = StatusSolicitacao.Aprovada;
        solicitacao.DataAtualizacao = DateTime.Now;

        await _contexto.SaveChangesAsync();

        return RedirectToAction(nameof(Solicitacoes));
    }

    public async Task<IActionResult> Recusar(int id)
    {
        var solicitacao = await _contexto.SolicitacoesAdocao
            .FirstOrDefaultAsync(s => s.Id == id);

        if (solicitacao == null)
        {
            return NotFound();
        }

        solicitacao.Status = StatusSolicitacao.Recusada;
        solicitacao.DataAtualizacao = DateTime.Now;

        await _contexto.SaveChangesAsync();

        return RedirectToAction(nameof(Solicitacoes));
    }
}