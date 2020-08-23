using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Models
{
    public class Projeto
    {
        public int ID { get; set; }

        public Empresa Empresa { get; set; }

        public Cliente Cliente { get; set; }

        public Usuario Usuario { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataContratacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataInicio { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataPrevisaoEncerramento { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataEncerramento { get; set; }

        public bool TimeMaterial { get; set; }

        public bool Reembolsado { get; set; }

        public bool AceitaDespesas { get; set; }

        public int TotalHoras { get; set; }

        public int Almoco { get; set; }

        public int Kilometragem { get; set; }

        public double TaxaReceberConsultor { get; set; }

        public double TaxaCobrarCliente { get; set; }

        public string Comentarios { get; set; }

        public int Concluido { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
