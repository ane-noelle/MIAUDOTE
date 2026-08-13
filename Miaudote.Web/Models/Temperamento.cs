using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miaudote.Web.Models;

[Table("temperamentos")]
public class Temperamento
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do temperamento é obrigatório.")]
    [StringLength(
        60,
        ErrorMessage = "O temperamento deve possuir no máximo 60 caracteres."
    )]
    [Column("nome")]
    [Display(Name = "Temperamento")]
    public string Nome { get; set; } = string.Empty;

    [Column("ativo")]
    [Display(Name = "Ativo")]
    public bool Ativo { get; set; } = true;
    public ICollection<AnimalTemperamento> AnimaisTemperamentos { get; set; }
    = new List<AnimalTemperamento>();
}