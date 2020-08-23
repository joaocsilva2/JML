using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TimeSheet.DTO
{
    public class UsuarioDTO
    {
        [Required(ErrorMessage = "ID é obrigatório.")]
        public int ID { get; set; }

        [Required(ErrorMessage = "ID da Empresa é obrigatório.")]
        public int? EmpresaID { get; set; }

        [Required(ErrorMessage = "ID do Cargo é obrigatório.")]
        public int? CargoID { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo deve ser de 100 caracteres.")]
        [MinLength(3, ErrorMessage = "Tamanho mínimo deve ser de 3 caracteres.")]
        [Required(ErrorMessage = "Nome é obrigatório.")]
        public string Nome { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo deve ser de 50 caracteres.")]
        public string TipoLogradouro { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo deve ser de 100 caracteres.")]
        public string Rua { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo deve ser de 50 caracteres.")]
        public string Numero { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo deve ser de 100 caracteres.")]
        public string Complemento { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo deve ser de 100 caracteres.")]
        public string Bairro { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo deve ser de 100 caracteres.")]
        public string Municipio { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo deve ser de 100 caracteres.")]
        public string Cidade { get; set; }

        [MaxLength(3, ErrorMessage = "Tamanho máximo deve ser de 3 caracteres.")]
        public string Estado { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo deve ser de 20 caracteres.")]
        public string Cep { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo deve ser de 100 caracteres.")]
        public string Pais { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo deve ser de 20 caracteres.")]
        public string TelefoneResidencial { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo deve ser de 20 caracteres.")]
        public string TelefoneCelular { get; set; }

        [MaxLength(200, ErrorMessage = "Tamanho máximo deve ser de 200 caracteres.")]
        public string EmailCooporativo { get; set; }

        [MaxLength(200, ErrorMessage = "Tamanho máximo deve ser de 200 caracteres.")]
        public string EmailPessoal { get; set; }

        [MaxLength(20, ErrorMessage = "Tamanho máximo deve ser de 20 caracteres.")]
        public string Rg { get; set; }

        [Required(ErrorMessage = "CPF é obrigatório.")]
        [MaxLength(20, ErrorMessage = "Tamanho máximo deve ser de 20 caracteres.")]
        public string Cpf { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true,DataFormatString = "{0:d}")]
        public DateTime DataNascimento { get; set; }

        [Required(ErrorMessage = "Senha é obrigatória.")]
        [MinLength(6, ErrorMessage = "Tamanho mínimo deve ser de 6 caracteres.")]
        public string Senha { get; set; }
    }
}
