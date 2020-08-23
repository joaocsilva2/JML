using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace TimeSheet.Models
{
    public class TipoDespesa
    {
        public int ID { get; set; }

        public Empresa Empresa { get; set; }

        [Column(TypeName = "nvarchar(100)")]
        public string Nome { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
