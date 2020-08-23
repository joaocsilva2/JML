using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;


namespace TimeSheet.Models
{
    public class AlocacaoAgenda
    {
        public int ID { get; set; }

        public Empresa Empresa { get; set; }

        public Projeto Projeto { get; set; }

        public Usuario Gerente { get; set; }

        public Usuario Consultor { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataInicial { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataFinal { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan HoraInicial { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan HoraFinal { get; set; }

        public string Descricao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }

    }
}
