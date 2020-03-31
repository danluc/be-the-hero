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
    public class OngsController : ControllerBase
    {
        private readonly IOngs _ongs;

        public OngsController(IOngs ongs)
        {
            _ongs = ongs;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var dados = await _ongs.Lista();
                return Ok(dados);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(string id)
        {
            try
            {
                var dados = await _ongs.BuscarPorId(id);
                return Ok(dados);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Ongs value)
        {
            try
            {
                var dados = _ongs.Salvar(value);
                return Ok(value);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }
        }

        [HttpPut]
        public async Task<IActionResult> Put([FromBody] Ongs value)
        {
            try
            {
                var dados = _ongs.Salvar(value);
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
    }
}
