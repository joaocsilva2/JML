using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace TimeSheet.Migrations
{
    public partial class AddEntidades : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Empresas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TipoLogradouro = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    TipoPessoa = table.Column<string>(type: "char(1)", nullable: true),
                    CpfCnpj = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InscricaoEstadual = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    InscricaoMunicipal = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Empresas", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Cargos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Cargos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Cargos_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Celulas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Celulas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Celulas_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Clientes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TipoLogradouro = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Telefone = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    TipoPessoa = table.Column<string>(type: "char(1)", nullable: true),
                    CpfCnpj = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    PessoaContato = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TelefoneContato = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Observações = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clientes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Clientes_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Log",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    Requisicao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Log", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Log_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoDespesas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoDespesas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TipoDespesas_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "TipoStatus",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Status = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TipoStatus", x => x.ID);
                    table.ForeignKey(
                        name: "FK_TipoStatus_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Usuarios",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    CargoID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TipoLogradouro = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Rua = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Numero = table.Column<string>(type: "nvarchar(50)", nullable: true),
                    Complemento = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Bairro = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Municipio = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Cidade = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Estado = table.Column<string>(type: "nvarchar(3)", nullable: true),
                    Cep = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Pais = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    TelefoneResidencial = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    TelefoneCelular = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    EmailCooporativo = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    EmailPessoal = table.Column<string>(type: "nvarchar(200)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    Cpf = table.Column<string>(type: "nvarchar(20)", nullable: true),
                    DataNascimento = table.Column<DateTime>(type: "datetime", nullable: false),
                    Senha = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Usuarios", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Usuarios_Cargos_CargoID",
                        column: x => x.CargoID,
                        principalTable: "Cargos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Usuarios_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Projetos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    ClienteID = table.Column<int>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    DataContratacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataInicio = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataPrevisaoEncerramento = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataEncerramento = table.Column<DateTime>(type: "datetime", nullable: false),
                    TimeMaterial = table.Column<bool>(nullable: false),
                    Reembolsado = table.Column<bool>(nullable: false),
                    AceitaDespesas = table.Column<bool>(nullable: false),
                    TotalHoras = table.Column<int>(nullable: false),
                    Almoco = table.Column<int>(nullable: false),
                    Kilometragem = table.Column<int>(nullable: false),
                    TaxaReceberConsultor = table.Column<double>(nullable: false),
                    TaxaCobrarCliente = table.Column<double>(nullable: false),
                    Comentarios = table.Column<string>(nullable: true),
                    Concluido = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projetos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Projetos_Clientes_ClienteID",
                        column: x => x.ClienteID,
                        principalTable: "Clientes",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projetos_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Projetos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "UsuarioCelulas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: true),
                    CelulaID = table.Column<int>(nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UsuarioCelulas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_UsuarioCelulas_Celulas_CelulaID",
                        column: x => x.CelulaID,
                        principalTable: "Celulas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioCelulas_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_UsuarioCelulas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "AlocacaoAgendas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    ProjetoID = table.Column<int>(nullable: true),
                    GerenteID = table.Column<int>(nullable: true),
                    ConsultorID = table.Column<int>(nullable: true),
                    DataInicial = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime", nullable: false),
                    HoraInicial = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    HoraFinal = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    Descricao = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AlocacaoAgendas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_AlocacaoAgendas_Usuarios_ConsultorID",
                        column: x => x.ConsultorID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlocacaoAgendas_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlocacaoAgendas_Usuarios_GerenteID",
                        column: x => x.GerenteID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_AlocacaoAgendas_Projetos_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "Projetos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Alocacoes",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    ProjetoID = table.Column<int>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: true),
                    CargoID = table.Column<int>(nullable: true),
                    DataInicial = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataFinal = table.Column<DateTime>(type: "datetime", nullable: false),
                    ApontamentoLiberado = table.Column<int>(nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Alocacoes", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Cargos_CargoID",
                        column: x => x.CargoID,
                        principalTable: "Cargos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Projetos_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "Projetos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Alocacoes_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Apontamentos",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    ProjetoID = table.Column<int>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: true),
                    DataLancamento = table.Column<DateTime>(type: "datetime", nullable: false),
                    HoraEntrada = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    HoraIntervalo = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    HoraReentrada = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    HoraSaida = table.Column<TimeSpan>(type: "time(0)", nullable: false),
                    TipoStatusID = table.Column<int>(nullable: true),
                    Descricao = table.Column<string>(nullable: true),
                    Atividades = table.Column<string>(nullable: true),
                    Observacoes = table.Column<string>(nullable: true),
                    Verificado = table.Column<bool>(nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Apontamentos", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Apontamentos_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apontamentos_Projetos_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "Projetos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apontamentos_TipoStatus_TipoStatusID",
                        column: x => x.TipoStatusID,
                        principalTable: "TipoStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Apontamentos_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Despesas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    ProjetoID = table.Column<int>(nullable: true),
                    UsuarioID = table.Column<int>(nullable: true),
                    TipoDespesaID = table.Column<int>(nullable: true),
                    Nome = table.Column<string>(type: "nvarchar(100)", nullable: true),
                    Data = table.Column<DateTime>(type: "datetime", nullable: false),
                    Valor = table.Column<double>(nullable: false),
                    TipoStatusID = table.Column<int>(nullable: true),
                    TaxaReceberConsultor = table.Column<double>(nullable: false),
                    TaxaCobrarCliente = table.Column<double>(nullable: false),
                    Observacoes = table.Column<string>(nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Despesas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_Despesas_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Despesas_Projetos_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "Projetos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Despesas_TipoDespesas_TipoDespesaID",
                        column: x => x.TipoDespesaID,
                        principalTable: "TipoDespesas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Despesas_TipoStatus_TipoStatusID",
                        column: x => x.TipoStatusID,
                        principalTable: "TipoStatus",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Despesas_Usuarios_UsuarioID",
                        column: x => x.UsuarioID,
                        principalTable: "Usuarios",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "ProjetoCelulas",
                columns: table => new
                {
                    ID = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmpresaID = table.Column<int>(nullable: true),
                    ProjetoID = table.Column<int>(nullable: true),
                    CelulaID = table.Column<int>(nullable: true),
                    DataCriacao = table.Column<DateTime>(type: "datetime", nullable: false),
                    DataAlteracao = table.Column<DateTime>(type: "datetime", nullable: false),
                    Ativo = table.Column<bool>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjetoCelulas", x => x.ID);
                    table.ForeignKey(
                        name: "FK_ProjetoCelulas_Celulas_CelulaID",
                        column: x => x.CelulaID,
                        principalTable: "Celulas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjetoCelulas_Empresas_EmpresaID",
                        column: x => x.EmpresaID,
                        principalTable: "Empresas",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_ProjetoCelulas_Projetos_ProjetoID",
                        column: x => x.ProjetoID,
                        principalTable: "Projetos",
                        principalColumn: "ID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoAgendas_ConsultorID",
                table: "AlocacaoAgendas",
                column: "ConsultorID");

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoAgendas_EmpresaID",
                table: "AlocacaoAgendas",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoAgendas_GerenteID",
                table: "AlocacaoAgendas",
                column: "GerenteID");

            migrationBuilder.CreateIndex(
                name: "IX_AlocacaoAgendas_ProjetoID",
                table: "AlocacaoAgendas",
                column: "ProjetoID");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_CargoID",
                table: "Alocacoes",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_EmpresaID",
                table: "Alocacoes",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_ProjetoID",
                table: "Alocacoes",
                column: "ProjetoID");

            migrationBuilder.CreateIndex(
                name: "IX_Alocacoes_UsuarioID",
                table: "Alocacoes",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_EmpresaID",
                table: "Apontamentos",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_ProjetoID",
                table: "Apontamentos",
                column: "ProjetoID");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_TipoStatusID",
                table: "Apontamentos",
                column: "TipoStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Apontamentos_UsuarioID",
                table: "Apontamentos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Cargos_EmpresaID",
                table: "Cargos",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Celulas_EmpresaID",
                table: "Celulas",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Clientes_EmpresaID",
                table: "Clientes",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_EmpresaID",
                table: "Despesas",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_ProjetoID",
                table: "Despesas",
                column: "ProjetoID");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_TipoDespesaID",
                table: "Despesas",
                column: "TipoDespesaID");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_TipoStatusID",
                table: "Despesas",
                column: "TipoStatusID");

            migrationBuilder.CreateIndex(
                name: "IX_Despesas_UsuarioID",
                table: "Despesas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Log_EmpresaID",
                table: "Log",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoCelulas_CelulaID",
                table: "ProjetoCelulas",
                column: "CelulaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoCelulas_EmpresaID",
                table: "ProjetoCelulas",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_ProjetoCelulas_ProjetoID",
                table: "ProjetoCelulas",
                column: "ProjetoID");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_ClienteID",
                table: "Projetos",
                column: "ClienteID");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_EmpresaID",
                table: "Projetos",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_Projetos_UsuarioID",
                table: "Projetos",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoDespesas_EmpresaID",
                table: "TipoDespesas",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_TipoStatus_EmpresaID",
                table: "TipoStatus",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCelulas_CelulaID",
                table: "UsuarioCelulas",
                column: "CelulaID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCelulas_EmpresaID",
                table: "UsuarioCelulas",
                column: "EmpresaID");

            migrationBuilder.CreateIndex(
                name: "IX_UsuarioCelulas_UsuarioID",
                table: "UsuarioCelulas",
                column: "UsuarioID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_CargoID",
                table: "Usuarios",
                column: "CargoID");

            migrationBuilder.CreateIndex(
                name: "IX_Usuarios_EmpresaID",
                table: "Usuarios",
                column: "EmpresaID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AlocacaoAgendas");

            migrationBuilder.DropTable(
                name: "Alocacoes");

            migrationBuilder.DropTable(
                name: "Apontamentos");

            migrationBuilder.DropTable(
                name: "Despesas");

            migrationBuilder.DropTable(
                name: "Log");

            migrationBuilder.DropTable(
                name: "ProjetoCelulas");

            migrationBuilder.DropTable(
                name: "UsuarioCelulas");

            migrationBuilder.DropTable(
                name: "TipoDespesas");

            migrationBuilder.DropTable(
                name: "TipoStatus");

            migrationBuilder.DropTable(
                name: "Projetos");

            migrationBuilder.DropTable(
                name: "Celulas");

            migrationBuilder.DropTable(
                name: "Clientes");

            migrationBuilder.DropTable(
                name: "Usuarios");

            migrationBuilder.DropTable(
                name: "Cargos");

            migrationBuilder.DropTable(
                name: "Empresas");
        }
    }
}
