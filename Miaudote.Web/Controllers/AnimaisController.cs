using Miaudote.Web.Data;
using Miaudote.Web.Enums;
using Miaudote.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Miaudote.Web.Controllers;

public class AnimaisController : Controller
{
    private readonly AppDbContext _contexto;

    public AnimaisController(AppDbContext contexto)
    {
        _contexto = contexto;
    }

    public async Task<IActionResult> Index()
    {
        List<Animal> animais = await _contexto.Animais
            .AsNoTracking()
            .Include(animal => animal.Especie)
            .Include(animal => animal.Cidade)
            .Include(animal => animal.AnimaisTemperamentos)
                .ThenInclude(
                    animalTemperamento =>
                        animalTemperamento.Temperamento
                )
            .Where(
                animal =>
                    animal.Ativo &&
                    animal.Status == StatusAnimal.Disponivel
            )
            .OrderBy(animal => animal.Nome)
            .ToListAsync();

        return View(animais);
    }
}