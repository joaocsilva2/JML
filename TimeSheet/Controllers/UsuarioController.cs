using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Data;
using TimeSheet.DTO;
using TimeSheet.Models;

namespace TimeSheet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        public ApplicationDbContext database;

        public UsuarioController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var usuario = database.Usuarios.Include(u => u.Empresa).Include(u => u.Cargo).Where(u => u.Ativo == true).FirstOrDefault(u => u.ID == id);
                if (usuario == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = id, code = Response.StatusCode });
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = id, code = Response.StatusCode });
            }
        }

        [HttpGet]
        public IActionResult Get()
        {
            try 
            { 
                var usuario = database.Usuarios.Include(u => u.Empresa).Include(u => u.Cargo).Where(u => u.Ativo == true).ToList();
                if (usuario == null || usuario.Count == 0)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", code = Response.StatusCode });
                }
                return Ok(usuario);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, code = Response.StatusCode });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                Usuario usuario = new Usuario();

                var empresa = database.Empresas.FirstOrDefault(e => e.ID == usuarioDTO.EmpresaID);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Empresa Not Found", id = usuarioDTO.EmpresaID, code = Response.StatusCode });
                }
                var cargo = database.Cargos.FirstOrDefault(e => e.ID == usuarioDTO.CargoID);
                if (cargo == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Cargo Not Found", id = usuarioDTO.CargoID, code = Response.StatusCode });
                }

                usuario.Empresa = empresa;
                usuario.Cargo = cargo;
                usuario = AtribuiCamposDTO(usuario,usuarioDTO);
                usuario.DataCriacao = DateTime.Now;
                usuario.DataAlteracao = Convert.ToDateTime("1900-01-01");
                usuario.Ativo = true;

                database.Usuarios.Add(usuario);
                database.SaveChanges();

                Response.StatusCode = 201;
                return new ObjectResult(new { message = "Create", id = usuario.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = usuarioDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = database.Usuarios.Include(u => u.Empresa).Include(u => u.Cargo).Where(u => u.Ativo == true).FirstOrDefault(u => u.ID == usuarioDTO.ID);
                if (usuario == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = usuarioDTO.EmpresaID, code = Response.StatusCode });
                }
                var empresa = database.Empresas.FirstOrDefault(e => e.ID == usuarioDTO.EmpresaID);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Empresa Not Found", id = usuarioDTO.EmpresaID, code = Response.StatusCode });
                }
                var cargo = database.Cargos.FirstOrDefault(e => e.ID == usuarioDTO.CargoID);
                if (cargo == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Cargo Not Found", id = usuarioDTO.CargoID, code = Response.StatusCode });
                }

                usuario.Empresa = empresa;
                usuario.Cargo = cargo;
                usuario = AtribuiCamposDTO(usuario, usuarioDTO);
                usuario.DataAlteracao = DateTime.Now;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Salved", id = usuario.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = usuarioDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] UsuarioDTO usuarioDTO)
        {
            try
            {
                var usuario = database.Usuarios.Include(u => u.Empresa).Include(u => u.Cargo).Where(u => u.Ativo == true).FirstOrDefault(u => u.ID == usuarioDTO.ID);
                if (usuario == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = usuarioDTO.EmpresaID, code = Response.StatusCode });
                }
                var empresa = database.Empresas.FirstOrDefault(e => e.ID == usuarioDTO.EmpresaID);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Empresa Not Found", id = usuarioDTO.EmpresaID, code = Response.StatusCode });
                }
                var cargo = database.Cargos.FirstOrDefault(e => e.ID == usuarioDTO.CargoID);
                if (cargo == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Cargo Not Found", id = usuarioDTO.CargoID, code = Response.StatusCode });
                }

                usuario.Empresa = usuarioDTO.EmpresaID == null ? usuario.Empresa : empresa;
                usuario.Cargo = usuarioDTO.CargoID == null ? usuario.Cargo : cargo;
                usuario = AtribuiCamposDTOPatch(usuario, usuarioDTO);
                usuario.DataAlteracao = DateTime.Now;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Salved", id = usuario.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = usuarioDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var usuario = database.Usuarios.Include(u => u.Empresa).Include(u => u.Cargo).Where(u => u.Ativo == true).FirstOrDefault(u => u.ID == id);
                if (usuario == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = id, code = Response.StatusCode });
                }
                usuario.DataAlteracao = DateTime.Now;
                usuario.Ativo = false;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Deleted", id = usuario.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = id, code = Response.StatusCode });
            }
        }

        private Usuario AtribuiCamposDTO(Usuario usuario, UsuarioDTO usuarioDTO)
        {
            usuario.Nome = usuarioDTO.Nome;

            usuario.TipoLogradouro = usuarioDTO.TipoLogradouro;
            usuario.Rua = usuarioDTO.Rua;
            usuario.Numero = usuarioDTO.Numero;
            usuario.Complemento = usuarioDTO.Complemento;
            usuario.Bairro = usuarioDTO.Bairro;
            usuario.Municipio = usuarioDTO.Municipio;
            usuario.Cidade = usuarioDTO.Cidade;
            usuario.Estado = usuarioDTO.Estado;
            usuario.Cep = usuarioDTO.Cep;
            usuario.Pais = usuarioDTO.Pais;

            usuario.TelefoneResidencial = usuarioDTO.TelefoneResidencial;
            usuario.TelefoneCelular = usuarioDTO.TelefoneCelular;
            usuario.EmailCooporativo = usuarioDTO.EmailCooporativo;
            usuario.EmailPessoal = usuarioDTO.EmailPessoal;
            usuario.Rg = usuarioDTO.Rg;
            usuario.Cpf = usuarioDTO.Cpf;
            usuario.DataNascimento = usuarioDTO.DataNascimento;

            usuario.Senha = usuarioDTO.Senha;

            return usuario;
        }

        private Usuario AtribuiCamposDTOPatch(Usuario usuario, UsuarioDTO usuarioDTO)
        {
            usuario.Nome = usuarioDTO.Nome == null ? usuario.Nome : usuarioDTO.Nome;

            usuario.TipoLogradouro = usuarioDTO.TipoLogradouro == null ? usuario.TipoLogradouro : usuarioDTO.TipoLogradouro;
            usuario.Rua = usuarioDTO.Rua == null ? usuario.Rua : usuarioDTO.Rua;
            usuario.Numero = usuarioDTO.Numero == null ? usuario.Numero : usuarioDTO.Numero;
            usuario.Complemento = usuarioDTO.Complemento == null ? usuario.Complemento : usuarioDTO.Complemento;
            usuario.Bairro = usuarioDTO.Bairro == null ? usuario.Bairro : usuarioDTO.Bairro;
            usuario.Municipio = usuarioDTO.Municipio == null ? usuario.Municipio : usuarioDTO.Municipio;
            usuario.Cidade = usuarioDTO.Cidade == null ? usuario.Cidade : usuarioDTO.Cidade;
            usuario.Estado = usuarioDTO.Estado == null ? usuario.Estado : usuarioDTO.Estado;
            usuario.Cep = usuarioDTO.Cep == null ? usuario.Cep : usuarioDTO.Cep;
            usuario.Pais = usuarioDTO.Pais == null ? usuario.Pais : usuarioDTO.Pais;

            usuario.TelefoneResidencial = usuarioDTO.TelefoneResidencial == null ? usuario.TelefoneResidencial : usuarioDTO.TelefoneResidencial;
            usuario.TelefoneCelular = usuarioDTO.TelefoneCelular == null ? usuario.TelefoneCelular : usuarioDTO.TelefoneCelular;
            usuario.EmailCooporativo = usuarioDTO.EmailCooporativo == null ? usuario.EmailCooporativo : usuarioDTO.EmailCooporativo;
            usuario.EmailPessoal = usuarioDTO.EmailPessoal == null ? usuario.EmailPessoal : usuarioDTO.EmailPessoal;
            usuario.Rg = usuarioDTO.Rg == null ? usuario.Rg : usuarioDTO.Rg;
            usuario.Cpf = usuarioDTO.Cpf == null ? usuario.Cpf : usuarioDTO.Cpf;
            usuario.DataNascimento = usuarioDTO.DataNascimento == null ? usuario.DataNascimento : usuario.DataNascimento;

            usuario.Senha = usuarioDTO.Senha == null ? usuario.Senha : usuarioDTO.Senha;

            return usuario;
        }

    }
}
