using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Miaudote.Web.Enums;

namespace Miaudote.Web.Models;

[Table("solicitacoes_adocao")]
public class SolicitacaoAdocao
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O animal é obrigatório.")]
    [Column("animal_id")]
    [Display(Name = "Animal")]
    public int AnimalId { get; set; }

    [ForeignKey(nameof(AnimalId))]
    public Animal? Animal { get; set; }

    [Required(ErrorMessage = "O nome completo é obrigatório.")]
    [StringLength(
        150,
        MinimumLength = 3,
        ErrorMessage = "O nome deve possuir entre 3 e 150 caracteres."
    )]
    [Column("nome_completo")]
    [Display(Name = "Nome completo")]
    public string NomeCompleto { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
    [StringLength(
        254,
        ErrorMessage = "O e-mail deve possuir no máximo 254 caracteres."
    )]
    [Column("email")]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O telefone é obrigatório.")]
    [Phone(ErrorMessage = "Informe um telefone válido.")]
    [StringLength(
        20,
        MinimumLength = 8,
        ErrorMessage = "O telefone deve possuir entre 8 e 20 caracteres."
    )]
    [Column("telefone")]
    [Display(Name = "Telefone")]
    public string Telefone { get; set; } = string.Empty;

    [Required(ErrorMessage = "A cidade é obrigatória.")]
    [StringLength(
        100,
        MinimumLength = 2,
        ErrorMessage = "A cidade deve possuir entre 2 e 100 caracteres."
    )]
    [Column("cidade")]
    [Display(Name = "Cidade")]
    public string Cidade { get; set; } = string.Empty;

    [Required(ErrorMessage = "O endereço é obrigatório.")]
    [StringLength(
        255,
        MinimumLength = 5,
        ErrorMessage = "O endereço deve possuir entre 5 e 255 caracteres."
    )]
    [Column("endereco")]
    [Display(Name = "Endereço")]
    public string Endereco { get; set; } = string.Empty;

    [Required(ErrorMessage = "Explique o motivo da adoção.")]
    [StringLength(
        3000,
        MinimumLength = 20,
        ErrorMessage = "O motivo deve possuir entre 20 e 3000 caracteres."
    )]
    [Column("motivo_adocao")]
    [Display(Name = "Motivo da adoção")]
    public string MotivoAdocao { get; set; } = string.Empty;

    [Required]
    [Column("status")]
    [Display(Name = "Status")]
    public StatusSolicitacao Status { get; set; }
        = StatusSolicitacao.Pendente;

    [Column("data_solicitacao")]
    [Display(Name = "Data da solicitação")]
    public DateTime DataSolicitacao { get; set; } = DateTime.Now;

    [Column("data_atualizacao")]
    [Display(Name = "Última atualização")]
    public DateTime? DataAtualizacao { get; set; }

    [StringLength(
        3000,
        ErrorMessage = "A observação deve possuir no máximo 3000 caracteres."
    )]
    [Column("observacao_administrativa")]
    [Display(Name = "Observação administrativa")]
    public string? ObservacaoAdministrativa { get; set; }
}