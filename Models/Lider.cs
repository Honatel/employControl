using System.ComponentModel.DataAnnotations;

namespace employesControl_V2.Models
{
    public class Lider
    {
        [Key]
        public int id { get; set; }

        public int? IdFuncionario { get; set; }

        public bool? Ativo { get; set; }
    }
}