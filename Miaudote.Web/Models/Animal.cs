using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Miaudote.Web.Enums;

namespace Miaudote.Web.Models;

[Table("animais")]
public class Animal
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome do animal é obrigatório.")]
    [StringLength(
        100,
        ErrorMessage = "O nome deve possuir no máximo 100 caracteres."
    )]
    [Column("nome")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "A espécie é obrigatória.")]
    [Column("especie_id")]
    [Display(Name = "Espécie")]
    public int EspecieId { get; set; }

    [ForeignKey(nameof(EspecieId))]
    public Especie? Especie { get; set; }

    [StringLength(
        100,
        ErrorMessage = "A raça deve possuir no máximo 100 caracteres."
    )]
    [Column("raca")]
    [Display(Name = "Raça")]
    public string? Raca { get; set; }

    [Required(ErrorMessage = "A idade aproximada é obrigatória.")]
    [Range(
        0,
        360,
        ErrorMessage = "A idade aproximada deve estar entre 0 e 360 meses."
    )]
    [Column("idade_aproximada_meses")]
    [Display(Name = "Idade aproximada em meses")]
    public int IdadeAproximadaMeses { get; set; }

    [Required(ErrorMessage = "O porte é obrigatório.")]
    [Column("porte")]
    [Display(Name = "Porte")]
    public PorteAnimal Porte { get; set; }

    [Required(ErrorMessage = "O gênero é obrigatório.")]
    [Column("genero")]
    [Display(Name = "Gênero")]
    public GeneroAnimal Genero { get; set; }

    [Required(ErrorMessage = "A cidade é obrigatória.")]
    [Column("cidade_id")]
    [Display(Name = "Cidade")]
    public int CidadeId { get; set; }

    [ForeignKey(nameof(CidadeId))]
    public Cidade? Cidade { get; set; }

    [Required(ErrorMessage = "A descrição do animal é obrigatória.")]
    [StringLength(
        3000,
        MinimumLength = 10,
        ErrorMessage = "A descrição deve possuir entre 10 e 3000 caracteres."
    )]
    [Column("descricao")]
    [Display(Name = "Descrição")]
    public string Descricao { get; set; } = string.Empty;

    [Column("vacinado")]
    [Display(Name = "Vacinado")]
    public bool Vacinado { get; set; }

    [Column("castrado")]
    [Display(Name = "Castrado")]
    public bool Castrado { get; set; }

    [StringLength(
        255,
        ErrorMessage = "O nome do arquivo deve possuir no máximo 255 caracteres."
    )]
    [Column("nome_arquivo_imagem")]
    [Display(Name = "Imagem")]
    public string? NomeArquivoImagem { get; set; }

    [Required(ErrorMessage = "O status do animal é obrigatório.")]
    [Column("status")]
    [Display(Name = "Status")]
    public StatusAnimal Status { get; set; } = StatusAnimal.Disponivel;

    [Column("ativo")]
    [Display(Name = "Ativo")]
    public bool Ativo { get; set; } = true;

    [Column("data_cadastro")]
    [Display(Name = "Data de cadastro")]
    public DateTime DataCadastro { get; set; } = DateTime.Now;

    [Column("data_atualizacao")]
    [Display(Name = "Última atualização")]
    public DateTime? DataAtualizacao { get; set; }

    public ICollection<AnimalTemperamento> AnimaisTemperamentos { get; set; }
        = new List<AnimalTemperamento>();
}