using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace TimeSheet.Models
{
    public class Despesa
    {
        public int ID { get; set; }

        public Empresa Empresa { get; set; }

        public Projeto Projeto { get; set; }

        public Usuario Usuario { get; set; }

        public TipoDespesa TipoDespesa { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime Data { get; set; }

        public double Valor { get; set; }

        public TipoStatus TipoStatus { get; set; }

        public double TaxaReceberConsultor { get; set; }

        public double TaxaCobrarCliente { get; set; }

        public string Observacoes { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
