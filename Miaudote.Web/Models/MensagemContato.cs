using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Miaudote.Web.Models;

[Table("mensagens_contato")]
public class MensagemContato
{
    [Key]
    [Column("id")]
    public int Id { get; set; }

    [Required(ErrorMessage = "O nome é obrigatório.")]
    [StringLength(
        150,
        MinimumLength = 3,
        ErrorMessage = "O nome deve possuir entre 3 e 150 caracteres."
    )]
    [Column("nome")]
    [Display(Name = "Nome")]
    public string Nome { get; set; } = string.Empty;

    [Required(ErrorMessage = "O e-mail é obrigatório.")]
    [EmailAddress(ErrorMessage = "Informe um e-mail válido.")]
    [StringLength(
        254,
        ErrorMessage = "O e-mail deve possuir no máximo 254 caracteres."
    )]
    [Column("email")]
    [Display(Name = "E-mail")]
    public string Email { get; set; } = string.Empty;

    [Required(ErrorMessage = "O assunto é obrigatório.")]
    [StringLength(
        150,
        MinimumLength = 3,
        ErrorMessage = "O assunto deve possuir entre 3 e 150 caracteres."
    )]
    [Column("assunto")]
    [Display(Name = "Assunto")]
    public string Assunto { get; set; } = string.Empty;

    [Required(ErrorMessage = "A mensagem é obrigatória.")]
    [StringLength(
        2000,
        MinimumLength = 10,
        ErrorMessage = "A mensagem deve possuir entre 10 e 2000 caracteres."
    )]
    [Column("mensagem")]
    [Display(Name = "Mensagem")]
    public string Mensagem { get; set; } = string.Empty;

    [Column("respondida")]
    [Display(Name = "Respondida")]
    public bool Respondida { get; set; }

    [Column("data_envio")]
    [Display(Name = "Data de envio")]
    public DateTime DataEnvio { get; set; } = DateTime.Now;

    [Column("data_resposta")]
    [Display(Name = "Data da resposta")]
    public DateTime? DataResposta { get; set; }
}