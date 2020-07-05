using System.ComponentModel.DataAnnotations;

namespace WebAtividadeEntrevista.Models
{
    public class AtualizarBeneficiarioModel
    {
        [Required]
        public int Id { get; set; }

        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public int ClienteId { get; set; }
    }
}