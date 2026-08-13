using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miaudote.Web.Models;

[Table("especies")]
public class Especie
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da espécie é obrigatório.")]
    [StringLength(
        50,
        ErrorMessage = "O nome da espécie deve possuir no máximo 50 caracteres."
    )]
    [Column("nome")]
    [Display(Name = "Nome da espécie")]
    public string Nome { get; set; } = string.Empty;

    [Column("ativa")]
    [Display(Name = "Ativa")]
    public bool Ativa { get; set; } = true;
}