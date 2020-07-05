using System.ComponentModel.DataAnnotations;

namespace WebAtividadeEntrevista.Models
{
    public class IncluirBeneficiarioModel
    {        
        [Required]
        public string Nome { get; set; }

        [Required]
        public string CPF { get; set; }

        [Required]
        public int ClienteId { get; set; }
    }
}