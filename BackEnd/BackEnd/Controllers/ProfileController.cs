using BackEnd.Interfaces;
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
    public class ProfileController : ControllerBase
    {
        private readonly IIncidents _incidents;

        public ProfileController(IIncidents incidents)
        {
            _incidents = incidents;
        }


        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var OngId = Request.Headers["ongsId"];
                var dados = await _incidents.ListaPorOng(OngId);
                return Ok(dados);
            }
            catch (Exception e)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, $"Falhou: \n {e.Message}");
            }

        }
    }
}
