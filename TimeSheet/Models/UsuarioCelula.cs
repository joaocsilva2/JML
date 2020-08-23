using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace TimeSheet.Models
{
    public class UsuarioCelula
    {
        public int ID { get; set; }

        public Empresa Empresa { get; set; }

        public Usuario Usuario { get; set; }

        public Celula Celula { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }

    }
}
