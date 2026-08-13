using System.ComponentModel.DataAnnotations.Schema;

namespace Miaudote.Web.Models;

[Table("animais_temperamentos")]
public class AnimalTemperamento
{
    [Column("animal_id")]
    public int AnimalId { get; set; }

    [ForeignKey(nameof(AnimalId))]
    public Animal? Animal { get; set; }

    [Column("temperamento_id")]
    public int TemperamentoId { get; set; }

    [ForeignKey(nameof(TemperamentoId))]
    public Temperamento? Temperamento { get; set; }
}