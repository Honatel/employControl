using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace employesControl_V2.Models
{
    [Index("NumeroChapa", IsUnique = true, Name = "Unique_Index")]
    public class Funcionario
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O campo Nome é obrigatório")]
        [MaxLength(15, ErrorMessage = "Este campo deve conter entre 3 e 15 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 15 caracteres")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "O campo Sobrenome é obrigatório")]
        [MaxLength(30, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        [MinLength(3, ErrorMessage = "Este campo deve conter entre 3 e 30 caracteres")]
        public string Sobrenome { get; set; }

        [EmailAddress(ErrorMessage = "E-mail em formato invalido")]
        public string Email { get; set; }
        public decimal NumeroChapa { get; set; }
        public int? LiderId { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório")]
        public string Senha { get; set; }
        public string? Telefones { get; set; }
        public string? DDD { get; set; }
        public bool Lider { get; set; }
    }
}