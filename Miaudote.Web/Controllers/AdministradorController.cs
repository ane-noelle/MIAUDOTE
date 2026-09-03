using Miaudote.Web.Data;
using Miaudote.Web.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Miaudote.Web.Models;

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

    public async Task<IActionResult> Mensagens()
    {
        var mensagens = await _contexto.MensagensContato
            .AsNoTracking()
            .OrderByDescending(m => m.DataEnvio)
            .ToListAsync();

        return View(mensagens);
    }
    public async Task<IActionResult> Animais()
{
    var animais = await _contexto.Animais
        .AsNoTracking()
        .Include(a => a.Especie)
        .Include(a => a.Cidade)
        .OrderBy(a => a.Nome)
        .ToListAsync();

    return View(animais);
}
public async Task<IActionResult> EditarAnimal(int id)
{
    var animal = await _contexto.Animais
        .Include(a => a.Especie)
        .Include(a => a.Cidade)
        .FirstOrDefaultAsync(a => a.Id == id);

    if (animal == null)
    {
        return NotFound();
    }

    return View(animal);
}

[HttpPost]
public async Task<IActionResult> EditarAnimal(Animal animal)
{
    var animalBanco = await _contexto.Animais
        .FirstOrDefaultAsync(a => a.Id == animal.Id);

    if (animalBanco == null)
    {
        return NotFound();
    }

    animalBanco.Nome = animal.Nome;
    animalBanco.Raca = animal.Raca;
    animalBanco.Descricao = animal.Descricao;
    animalBanco.DataAtualizacao = DateTime.Now;

    await _contexto.SaveChangesAsync();

    return RedirectToAction(nameof(Animais));
}
public async Task<IActionResult> ExcluirAnimal(int id)
{
    var animal = await _contexto.Animais
        .FirstOrDefaultAsync(a => a.Id == id);

    if (animal == null)
    {
        return NotFound();
    }

    _contexto.Animais.Remove(animal);

    await _contexto.SaveChangesAsync();

    return RedirectToAction(nameof(Animais));
}
}