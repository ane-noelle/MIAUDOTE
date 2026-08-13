using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miaudote.Web.Models;

[Table("cidades")]
public class Cidade
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome da cidade é obrigatório.")]
    [StringLength(
        100,
        ErrorMessage = "O nome da cidade deve possuir no máximo 100 caracteres."
    )]
    [Column("nome")]
    [Display(Name = "Cidade")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A UF é obrigatória.")]
    [StringLength(
        2,
        MinimumLength = 2,
        ErrorMessage = "A UF deve possuir exatamente 2 letras."
    )]
    [Column("uf")]
    [Display(Name = "UF")]
    public string Uf { get; set; } = string.Empty;

    [Column("ativa")]
    [Display(Name = "Ativa")]
    public bool Ativa { get; set; } = true;
}