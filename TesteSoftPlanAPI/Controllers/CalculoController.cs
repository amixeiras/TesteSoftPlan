﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace TesteSoftPlanAPI.Controllers
{
    [Route("api/calculo")]
    [ApiController]
    public class CalculoController : ControllerBase
    {

        // GET api/values
        [HttpGet]
        [Route("taxajuros")]
        public ActionResult<decimal> TaxaJuros()
        {
            return 0.01M;
        }

        // POST api/values
        [HttpPost]
        [Route("calculajuros")]
        public ActionResult<decimal> CalcularJuros(decimal valorinicial, int meses)
        {
            var taxa = TaxaJuros().Value;
            taxa += 1;
            decimal taxaMensal = 1;

            for (int i = 0; i < meses; i++)
            {
                taxaMensal *= taxa;
            }

            var result = valorinicial * taxaMensal;

            return Math.Truncate(100 * result) / 100;
        }

        
    }
}
