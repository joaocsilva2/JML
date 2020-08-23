using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using TimeSheet.Enum;

namespace TimeSheet.DTO
{
    public class EmpresaDTO
    {
        [Required(ErrorMessage = "ID é obrigatório.")]
        public int ID { get; set; }

        [MaxLength(100, ErrorMessage = "Tamanho máximo deve ser de 100 caracteres.")]
        [MinLength(5, ErrorMessage = "Tamanho mínimo deve ser de 5 caracteres.")]
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
        public string Telefone { get; set; }

        [MaxLength(200, ErrorMessage = "Tamanho máximo deve ser de 200 caracteres.")]
        public string Email { get; set; }

        [MaxLength(1, ErrorMessage = "Tamanho máximo deve ser de 1 caracter.")]
        [EnumDataType(typeof(Validacao.TipoPessoa), ErrorMessage = "Valores válidos 'F' e 'J'")]
        public string TipoPessoa { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo deve ser de 50 caracteres.")]
        public string CpfCnpj { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo deve ser de 50 caracteres.")]
        public string InscricaoEstadual { get; set; }

        [MaxLength(50, ErrorMessage = "Tamanho máximo deve ser de 50 caracteres.")]
        public string InscricaoMunicipal { get; set; }
    }
}
