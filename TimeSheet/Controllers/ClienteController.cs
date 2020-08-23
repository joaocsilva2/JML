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
    public class ClienteController : ControllerBase
    {
        public ApplicationDbContext database;

        public ClienteController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cliente = database.Clientes.Include(c => c.Empresa).Where(c => c.Ativo == true).FirstOrDefault(c => c.ID == id);
                if (cliente == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = id, code = Response.StatusCode });
                }
                return Ok(cliente);
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
                var cliente = database.Clientes.Include(c => c.Empresa).Where(c => c.Ativo == true).ToList();
                if (cliente == null || cliente.Count == 0)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", code = Response.StatusCode });
                }
                return Ok(cliente);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, code = Response.StatusCode });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                Cliente cliente = new Cliente();

                var empresa = database.Empresas.FirstOrDefault(e => e.ID == clienteDTO.EmpresaID);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Empresa Not Found", id = clienteDTO.EmpresaID, code = Response.StatusCode });
                }

                cliente.Empresa = empresa;
                cliente = AtribuiCamposDTO(cliente, clienteDTO);
                cliente.DataCriacao = DateTime.Now;
                cliente.DataAlteracao = Convert.ToDateTime("1900-01-01");
                cliente.Ativo = true;

                database.Clientes.Add(cliente);
                database.SaveChanges();

                Response.StatusCode = 201;
                return new ObjectResult(new { message = "Create", id = cliente.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = clienteDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                var cliente = database.Clientes.Include(c => c.Empresa).Where(c => c.Ativo == true).FirstOrDefault(c => c.ID == clienteDTO.ID);
                if (cliente == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = clienteDTO.EmpresaID, code = Response.StatusCode });
                }
                var empresa = database.Empresas.FirstOrDefault(e => e.ID == clienteDTO.EmpresaID);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Empresa Not Found", id = clienteDTO.EmpresaID, code = Response.StatusCode });
                }

                cliente.Empresa = empresa;
                cliente = AtribuiCamposDTO(cliente, clienteDTO);
                cliente.DataAlteracao = DateTime.Now;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Salved", id = cliente.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = clienteDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] ClienteDTO clienteDTO)
        {
            try
            {
                var cliente = database.Clientes.Include(c => c.Empresa).Where(c => c.Ativo == true).FirstOrDefault(c => c.ID == clienteDTO.ID);
                if (cliente == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = clienteDTO.EmpresaID, code = Response.StatusCode });
                }
                var empresa = database.Empresas.FirstOrDefault(e => e.ID == clienteDTO.EmpresaID);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Empresa Not Found", id = clienteDTO.EmpresaID, code = Response.StatusCode });
                }

                cliente.Empresa = clienteDTO.EmpresaID == null ? cliente.Empresa : empresa;
                cliente = AtribuiCamposDTOPatch(cliente, clienteDTO);
                cliente.DataAlteracao = DateTime.Now;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Salved", id = cliente.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = clienteDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cliente = database.Clientes.Include(c => c.Empresa).Where(c => c.Ativo == true).FirstOrDefault(c => c.ID == id);
                if (cliente == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = id, code = Response.StatusCode });
                }
                cliente.DataAlteracao = DateTime.Now;
                cliente.Ativo = false;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Deleted", id = cliente.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = id, code = Response.StatusCode });
            }
        }

        private Cliente AtribuiCamposDTO(Cliente cliente, ClienteDTO clienteDTO)
        {
            cliente.Nome = clienteDTO.Nome;

            cliente.TipoLogradouro = clienteDTO.TipoLogradouro;
            cliente.Rua = clienteDTO.Rua;
            cliente.Numero = clienteDTO.Numero;
            cliente.Complemento = clienteDTO.Complemento;
            cliente.Bairro = clienteDTO.Bairro;
            cliente.Municipio = clienteDTO.Municipio;
            cliente.Cidade = clienteDTO.Cidade;
            cliente.Estado = clienteDTO.Estado;
            cliente.Cep = clienteDTO.Cep;
            cliente.Pais = clienteDTO.Pais;

            cliente.Telefone = clienteDTO.Telefone;
            cliente.Email = clienteDTO.Email;
            cliente.TipoPessoa = clienteDTO.TipoPessoa;
            cliente.CpfCnpj = clienteDTO.CpfCnpj;
            cliente.PessoaContato = clienteDTO.PessoaContato;
            cliente.TelefoneContato = clienteDTO.TelefoneContato;
            cliente.Observacoes = clienteDTO.Observacoes;

            return cliente;
        }

        private Cliente AtribuiCamposDTOPatch(Cliente cliente, ClienteDTO clienteDTO)
        {
            cliente.Nome = clienteDTO.Nome == null ? cliente.Nome : clienteDTO.Nome;

            cliente.TipoLogradouro = clienteDTO.TipoLogradouro == null ? cliente.TipoLogradouro : clienteDTO.TipoLogradouro;
            cliente.Rua = clienteDTO.Rua == null ? cliente.Rua : clienteDTO.Rua;
            cliente.Numero = clienteDTO.Numero == null ? cliente.Numero : clienteDTO.Numero;
            cliente.Complemento = clienteDTO.Complemento == null ? cliente.Complemento : clienteDTO.Complemento;
            cliente.Bairro = clienteDTO.Bairro == null ? cliente.Bairro : clienteDTO.Bairro;
            cliente.Municipio = clienteDTO.Municipio == null ? cliente.Municipio : clienteDTO.Municipio;
            cliente.Cidade = clienteDTO.Cidade == null ? cliente.Cidade : clienteDTO.Cidade;
            cliente.Estado = clienteDTO.Estado == null ? cliente.Estado : clienteDTO.Estado;
            cliente.Cep = clienteDTO.Cep == null ? cliente.Cep : clienteDTO.Cep;
            cliente.Pais = clienteDTO.Pais == null ? cliente.Pais : clienteDTO.Pais;

            cliente.Telefone = clienteDTO.Telefone == null ? cliente.Telefone : clienteDTO.Telefone;
            cliente.Email = clienteDTO.Email == null ? cliente.Email : clienteDTO.Email;
            cliente.TipoPessoa = clienteDTO.TipoPessoa == null ? cliente.TipoPessoa : clienteDTO.TipoPessoa;
            cliente.CpfCnpj = clienteDTO.CpfCnpj == null ? cliente.CpfCnpj : clienteDTO.CpfCnpj;
            cliente.PessoaContato = clienteDTO.PessoaContato == null ? cliente.PessoaContato : clienteDTO.PessoaContato;
            cliente.TelefoneContato = clienteDTO.TelefoneContato == null ? cliente.TelefoneContato : clienteDTO.TelefoneContato;
            cliente.Observacoes = clienteDTO.Observacoes == null ? cliente.Observacoes : clienteDTO.Observacoes;

            return cliente;
        }

    }
}
