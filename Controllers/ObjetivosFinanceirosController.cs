using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PoupaDev.API.Models;

namespace poupadev.api.Models
{
    [ApiController]
    [Route("api/objetivos-financeiros")]
    public class ObjetivosFinanceirosController : ControllerBase
    {
        [HttpGet]
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            return Ok();
        }

        [HttpPost]
        public IActionResult Post(ObjetivoFinanceirosInputModel model)
        {
            return Ok();
        }

        [HttpPost("{id}/operacoes")]
        public IActionResult PostOperacao(int id, OperacaoInputModel model)
        {
            return NoContent();
        }    
    }
}