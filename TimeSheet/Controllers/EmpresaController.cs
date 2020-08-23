using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Data;
using Microsoft.EntityFrameworkCore;
using TimeSheet.Models;
using TimeSheet.DTO;

namespace TimeSheet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class EmpresaController : ControllerBase
    {
        public ApplicationDbContext database;
        public EmpresaController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var empresa = database.Empresas.Where(e => e.Ativo == true).FirstOrDefault(e => e.ID == id);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = id, code = Response.StatusCode });
                }
                return Ok(empresa);
            }
            catch(Exception ex)
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
                var empresa = database.Empresas.Where(e => e.Ativo == true).ToList();
                if (empresa == null || empresa.Count == 0)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", code = Response.StatusCode });
                }
                return Ok(empresa);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, code = Response.StatusCode });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] EmpresaDTO empresaDTO)
        {
            try
            {
                Empresa empresa = new Empresa();
                empresa.Nome = empresaDTO.Nome;

                empresa.TipoLogradouro = empresaDTO.TipoLogradouro;
                empresa.Rua = empresaDTO.Rua;
                empresa.Numero = empresaDTO.Numero;
                empresa.Complemento = empresaDTO.Complemento;
                empresa.Bairro = empresaDTO.Bairro;
                empresa.Municipio = empresaDTO.Municipio;
                empresa.Cidade = empresaDTO.Cidade;
                empresa.Estado = empresaDTO.Estado;
                empresa.Cep = empresaDTO.Cep;
                empresa.Pais = empresaDTO.Pais;

                empresa.Telefone = empresaDTO.Telefone;
                empresa.Email = empresaDTO.Email;
                empresa.TipoPessoa = empresaDTO.TipoPessoa;
                empresa.CpfCnpj = empresaDTO.CpfCnpj;
                empresa.InscricaoEstadual = empresaDTO.InscricaoEstadual;
                empresa.InscricaoMunicipal = empresaDTO.InscricaoMunicipal;
                empresa.DataCriacao = DateTime.Now;
                empresa.DataAlteracao = Convert.ToDateTime("1900-01-01");
                empresa.Ativo = true;
                
                database.Empresas.Add(empresa);
                database.SaveChanges();

                Response.StatusCode = 201;
                return new ObjectResult(new { message = "Create", id = empresa.ID, Code = Response.StatusCode });
            }
            catch(Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = empresaDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] EmpresaDTO empresaDTO)
        {
            try
            {
                var empresa = database.Empresas.Where(e => e.Ativo == true).FirstOrDefault(e => e.ID == empresaDTO.ID);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = empresaDTO.ID, code = Response.StatusCode });
                }
                empresa.Nome = empresaDTO.Nome;

                empresa.TipoLogradouro = empresaDTO.TipoLogradouro;
                empresa.Rua = empresaDTO.Rua;
                empresa.Numero = empresaDTO.Numero;
                empresa.Complemento = empresaDTO.Complemento;
                empresa.Bairro = empresaDTO.Bairro;
                empresa.Municipio = empresaDTO.Municipio;
                empresa.Cidade = empresaDTO.Cidade;
                empresa.Estado = empresaDTO.Estado;
                empresa.Cep = empresaDTO.Cep;
                empresa.Pais = empresaDTO.Pais;

                empresa.Telefone = empresaDTO.Telefone;
                empresa.Email = empresaDTO.Email;
                empresa.TipoPessoa = empresaDTO.TipoPessoa;
                empresa.CpfCnpj = empresaDTO.CpfCnpj;
                empresa.InscricaoEstadual = empresaDTO.InscricaoEstadual;
                empresa.InscricaoMunicipal = empresaDTO.InscricaoMunicipal;
                empresa.DataAlteracao = DateTime.Now;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Saved", id = empresa.ID, code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = empresaDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] EmpresaDTO empresaDTO)
        {
            try
            {
                var empresa = database.Empresas.Where(e => e.Ativo == true).FirstOrDefault(e => e.ID == empresaDTO.ID);
                if(empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = empresaDTO.ID, code = Response.StatusCode });
                }
                empresa.Nome = empresaDTO.Nome == null ? empresa.Nome : empresaDTO.Nome;

                empresa.TipoLogradouro = empresaDTO.TipoLogradouro == null ? empresa.TipoLogradouro : empresa.TipoLogradouro;
                empresa.Rua = empresaDTO.Rua == null ? empresa.Rua : empresaDTO.Rua;
                empresa.Numero = empresaDTO.Numero == null ? empresa.Numero : empresaDTO.Numero;
                empresa.Complemento = empresaDTO.Complemento == null ? empresa.Complemento : empresaDTO.Complemento;
                empresa.Bairro = empresaDTO.Bairro == null ? empresa.Bairro : empresaDTO.Bairro;
                empresa.Municipio = empresaDTO.Municipio == null ? empresa.Municipio : empresaDTO.Municipio;
                empresa.Cidade = empresaDTO.Cidade == null ? empresa.Cidade : empresaDTO.Cidade;
                empresa.Estado = empresaDTO.Estado == null ? empresa.Estado : empresaDTO.Estado; 
                empresa.Cep = empresaDTO.Cep == null ? empresa.Cep : empresaDTO.Cep;
                empresa.Pais = empresaDTO.Pais == null ? empresa.Pais : empresaDTO.Pais;

                empresa.Telefone = empresaDTO.Telefone == null ? empresa.Telefone : empresaDTO.Telefone;
                empresa.Email = empresaDTO.Email == null ? empresa.Email : empresaDTO.Email;
                empresa.TipoPessoa = empresaDTO.TipoPessoa == null ? empresa.TipoPessoa : empresaDTO.TipoPessoa;
                empresa.CpfCnpj = empresaDTO.CpfCnpj == null ? empresa.CpfCnpj : empresaDTO.CpfCnpj;
                empresa.InscricaoEstadual = empresaDTO.InscricaoEstadual == null ? empresa.InscricaoEstadual : empresaDTO.InscricaoEstadual;
                empresa.InscricaoMunicipal = empresaDTO.InscricaoMunicipal == null ? empresa.InscricaoMunicipal : empresaDTO.InscricaoMunicipal;
                empresa.DataAlteracao = DateTime.Now;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Saved", id = empresa.ID, code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = empresaDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var empresa = database.Empresas.Where(e => e.Ativo == true).FirstOrDefault(e => e.ID == id);
                if(empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new {message = "", id = id, code = Response.StatusCode });
                }
                empresa.DataAlteracao = DateTime.Now;
                empresa.Ativo = false;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Deleted", id = empresa.ID, code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = id, code = Response.StatusCode });
            }
        }

    }
}
