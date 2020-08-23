using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TimeSheet.Models;

namespace TimeSheet.Data
{
    public class ApplicationDbContext :DbContext
    {
        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Cargo> Cargos { get; set; }
        public DbSet<Celula> Celulas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<TipoDespesa> TipoDespesas { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<Despesa> Despesas { get; set; }
        public DbSet<TipoStatus> TipoStatus { get; set; }
        public DbSet<ProjetoCelula> ProjetoCelulas { get; set; }
        public DbSet<UsuarioCelula> UsuarioCelulas { get; set; }
        public DbSet<Alocacao> Alocacoes { get; set; }
        public DbSet<AlocacaoAgenda> AlocacaoAgendas { get; set; }
        public DbSet<Apontamento> Apontamentos { get; set; }
        public DbSet<Log> Log { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
    }
}
