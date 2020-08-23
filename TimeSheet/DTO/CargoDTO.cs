using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimeSheet.DTO
{
    public class CargoDTO
    {
        [Required(ErrorMessage = "ID é obrigatório.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "ID da Empresa é obrigatório.")]
        public int EmpresaID { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo deve ser de 100 caracteres.")]
        [MinLength(5, ErrorMessage = "Tamanho mínimo deve ser de 3 caracteres.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

    }
}
