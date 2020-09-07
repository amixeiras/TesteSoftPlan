using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Dominio.Interface;
using Microsoft.AspNetCore.Mvc;

namespace TesteSoftPlanAPI.Controllers
{

    //Caminho da API
    [Route("api/calculo")]
    [ApiController]
    public class CalculoController : ControllerBase
    {
        private readonly IService iService;

        public CalculoController(IService service) =>
            iService = service;

        // GET api/values
        [HttpGet]
        [Route("taxajuros")]
        public ActionResult<decimal> TaxaJuros()
        {
            try
            {
                return iService.TaxaJuros();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }

        }

        // POST api/values
        [HttpPost]
        [Route("calculajuros")]
        public ActionResult<decimal> CalcularJuros(decimal valorinicial, int meses)
        {
            try
            {
                return iService.Calculo(valorinicial, meses);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("showmethecode")]
        public ActionResult<string> GetUrlProject()
        {
            try
            {
                return iService.GetUrlProject();
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
