using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding.Metadata;
using poupadev.api.Persistence;
using PoupaDev.API.Entities;
using PoupaDev.API.Models;

namespace poupadev.api.Models
{
    [ApiController]
    [Route("api/objetivos-financeiros")]
    public class ObjetivosFinanceirosController : ControllerBase
    {
        private readonly PoupaDevContext _context;
        public ObjetivosFinanceirosController(PoupaDevContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult Get()
        {
            var objetivos = _context.Objetivos;
            return Ok(objetivos);
        }

        [HttpGet("{id}")]
        public IActionResult GetPorId(int id)
        {
            var objetivo = _context.Objetivos.SingleOrDefault(o => o.Id == id);

            if (objetivo == null){
                return NotFound();}
            return Ok(objetivo);
        }

        [HttpPost]
        public IActionResult Post(ObjetivoFinanceirosInputModel model)
        {
            var objetivo = new ObjetivoFinanceiro(model.Titulo, model.Descricao, model.ValorObjetivo);
            _context.Objetivos.Add(objetivo);

            var id = objetivo.Id;
            return CreatedAtAction("GetId", new {id = id}, model);
        }

        [HttpPost("{id}/operacoes")]
        public IActionResult PostOperacao(int id, OperacaoInputModel model)
        {
            var operacao =  new Operacao(model.Valor, model.Tipo);
            var objetivo = _context.Objetivos.SingleOrDefault(o => o.Id == id);

            if(objetivo == null)
            {
                return NotFound();
            }

            objetivo.RealizarOperacao(operacao);
            
            return NoContent();
        }    
    }
}