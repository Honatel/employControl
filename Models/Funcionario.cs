using System.ComponentModel.DataAnnotations;

namespace employesControl_V2.Models
{
    public class Funcionario
    {
        [Key]
        public int id { get; set; }

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
        public int NumeroChapa { get; set; }
        public int? IdLider { get; set; }

        [Required(ErrorMessage = "O campo Password é obrigatório")]
        public string Password { get; set; }
        public string[]? Telefones { get; set; }
        public string DDD { get; set; }
        public bool isLider { get; set; }
    }
}