using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations.Schema;

namespace TimeSheet.Models
{
    public class Apontamento
    {
        public int ID { get; set; }

        public Empresa Empresa { get; set; }

        public Projeto Projeto { get; set; }
        
        public Usuario Usuario { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataLancamento { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan HoraEntrada { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan HoraIntervalo { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan HoraReentrada { get; set; }

        [Column(TypeName = "time(0)")]
        public TimeSpan HoraSaida { get; set; }

        public TipoStatus TipoStatus { get; set; }

        public string Descricao { get; set; }

        public string Atividades { get; set; }

        public string Observacoes { get; set; }

        public bool Verificado { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataCriacao { get; set; }

        [Column(TypeName = "datetime")]
        public DateTime DataAlteracao { get; set; }

        public bool Ativo { get; set; }
    }
}
