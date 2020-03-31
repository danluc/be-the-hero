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
    public class SessionController : ControllerBase
    {
        private readonly IOngs _ongs;

        public SessionController(IOngs ongs)
        {
            _ongs = ongs;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ongs value)
        {
            try
            {
                var dados = await _ongs.BuscarPorId(value.Id);
                if(dados == null)
                {
                    return this.StatusCode(StatusCodes.Status400BadRequest, $"Ong não encontrada");
                }
                return Ok(dados);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }
        }
    }
}
