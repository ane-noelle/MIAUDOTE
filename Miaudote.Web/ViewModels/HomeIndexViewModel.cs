using Miaudote.Web.Models;

namespace Miaudote.Web.ViewModels;

public class HomeIndexViewModel
{
    public List<Animal> Animais { get; set; } = new();

    public int QuantidadeAnimaisDisponiveis { get; set; }

    public int QuantidadeAdocoesConcluidas { get; set; }
}