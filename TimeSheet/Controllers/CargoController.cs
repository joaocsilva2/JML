using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TimeSheet.Data;
using TimeSheet.Models;
using TimeSheet.DTO;
using System.Runtime.CompilerServices;
using Microsoft.EntityFrameworkCore;

namespace TimeSheet.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    public class CargoController : ControllerBase
    {
        public ApplicationDbContext database;

        public CargoController(ApplicationDbContext database)
        {
            this.database = database;
        }

        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var cargo = database.Cargos.Include(c => c.Empresa).Where(c => c.Ativo == true).FirstOrDefault(c => c.ID == id);
                if (cargo == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = id, code = Response.StatusCode });
                }
                return Ok(cargo);
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
                
                var cargo = database.Cargos.Include(c => c.Empresa).Where(c => c.Ativo == true).ToList();
                if (cargo == null || cargo.Count == 0)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", code = Response.StatusCode });
                }
                return Ok(cargo);
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, code = Response.StatusCode });
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] CargoDTO cargoDTO)
        {
            try
            {
                Cargo cargo = new Cargo();

                var empresa = database.Empresas.Where(c => c.Ativo == true).FirstOrDefault(e => e.ID == cargoDTO.EmpresaID);
                if(empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Empresa Not Found", id = cargoDTO.EmpresaID, code = Response.StatusCode });
                }
                cargo.Empresa = empresa;
                cargo.Nome = cargoDTO.Nome;
                cargo.DataCriacao = DateTime.Now;
                cargo.DataAlteracao = Convert.ToDateTime("1900-01-01");
                cargo.Ativo = true;

                database.Cargos.Add(cargo);
                database.SaveChanges();

                Response.StatusCode = 201;
                return new ObjectResult(new { message = "Create", id = cargo.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = cargoDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpPut]
        public IActionResult Put([FromBody] CargoDTO cargoDTO)
        {
            try
            {
                var cargo = database.Cargos.Where(c => c.Ativo == true).FirstOrDefault(c => c.ID == cargoDTO.ID);
                if (cargo == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = cargoDTO.EmpresaID, code = Response.StatusCode });
                }
                var empresa = database.Empresas.FirstOrDefault(e => e.ID == cargoDTO.EmpresaID);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Empresa Not Found", id = cargoDTO.EmpresaID, code = Response.StatusCode });
                }
                cargo.Empresa = empresa;
                cargo.Nome = cargoDTO.Nome;
                cargo.DataAlteracao = DateTime.Now;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Salved", id = cargo.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = cargoDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpPatch]
        public IActionResult Patch([FromBody] CargoDTO cargoDTO)
        {
            try
            {
                var cargo = database.Cargos.Where(c => c.Ativo == true).FirstOrDefault(c => c.ID == cargoDTO.ID);
                if (cargo == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = cargoDTO.EmpresaID, code = Response.StatusCode });
                }
                var empresa = database.Empresas.FirstOrDefault(e => e.ID == cargoDTO.EmpresaID);
                if (empresa == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Empresa Not Found", id = cargoDTO.EmpresaID, code = Response.StatusCode });
                }
                cargo.Empresa = empresa;
                cargo.Nome = cargoDTO.Nome == null ? cargo.Nome : cargoDTO.Nome;
                cargo.DataAlteracao = DateTime.Now;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Salved", id = cargo.ID, Code = Response.StatusCode });
            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = cargoDTO.ID, code = Response.StatusCode });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                var cargo = database.Cargos.Where(c => c.Ativo == true).FirstOrDefault(c => c.ID == id);
                if (cargo == null)
                {
                    Response.StatusCode = 404;
                    return new ObjectResult(new { message = "Not Found", id = id, code = Response.StatusCode });
                }
                cargo.DataAlteracao = DateTime.Now;
                cargo.Ativo = false;

                database.SaveChanges();

                Response.StatusCode = 200;
                return new ObjectResult(new { message = "Deleted", id = cargo.ID, Code = Response.StatusCode });

            }
            catch (Exception ex)
            {
                Response.StatusCode = 400;
                return new ObjectResult(new { message = ex.Message + " " + ex.InnerException.Message, id = id, code = Response.StatusCode });
            }

        }

    }
}
