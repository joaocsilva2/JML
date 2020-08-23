using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace TimeSheet.Models
{
    public class Cliente
    {
        public int ID { get; set; }

        public Empresa Empresa { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string TipoLogradouro { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Rua { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string Numero { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Complemento { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Bairro { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Municipio { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Cidade { get; set; }

        [Column(TypeName = "nvarchar(3)")]
        public string Estado { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Cep { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Pais { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string Telefone { get; set; }

        [Column(TypeName = "nvarchar(200)")]
        public string Email { get; set; }

        [Column(TypeName = "char(1)")]
        public string TipoPessoa { get; set; }

        [Column(TypeName = "nvarchar(50)")]
        public string CpfCnpj { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string PessoaContato { get; set; }

        [Column(TypeName = "nvarchar(20)")]
        public string TelefoneContato { get; set; }

        public string Observacoes { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }

    }
}
