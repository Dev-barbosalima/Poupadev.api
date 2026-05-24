using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PoupaDev.API.Models
{
    public class ObjetivoFinanceirosInputModel
    {
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public decimal? ValorObjetivo { get; set; }
    }
}