using BackEnd.Interfaces;
using BackEnd.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BackEnd.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IncidentsController : ControllerBase
    {
        private readonly IIncidents _incidents;

        public IncidentsController(IIncidents incidents)
        {
            _incidents = incidents;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var dados = await _incidents.Lista();
                return Ok(dados);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            try
            {
                var dados = await _incidents.BuscarPorId(id);
                return Ok(dados);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Incidents value)
        {
            try
            {
                var OngId = Request.Headers["ongsId"];
                if (OngId.FirstOrDefault() == null)
                {
                    return this.StatusCode(StatusCodes.Status401Unauthorized, "Não autorizado");
                }
                value.OngsId = OngId;
                var dados = _incidents.Salvar(value);
                return Ok(dados);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Incidents value)
        {
            try
            {
                var OngId = Request.Headers["ongsId"];
                var hasDados = await _incidents.BuscarHasOng(value.Id, OngId);
                if (hasDados == null)
                {
                    return this.StatusCode(StatusCodes.Status401Unauthorized, "Não autorizado");
                }
                value.OngsId = OngId;
                var dados = _incidents.Salvar(value);
                if (dados)
                {
                    return Ok(value);
                }
                return Ok(dados);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            try
            {
                var OngId = Request.Headers["ongsId"];
                var hasDados = await _incidents.BuscarHasOng(id, OngId);
                if (hasDados == null)
                {
                    return this.StatusCode(StatusCodes.Status401Unauthorized, "Não autorizado");
                }
                var res = _incidents.Deletar(hasDados);
                return Ok(res);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }
        }
    }
}
