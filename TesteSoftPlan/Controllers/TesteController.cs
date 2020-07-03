using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using TesteSoftPlanAPI.Client;
using Microsoft.Extensions.Configuration;
using System.Net.Http;
using System.Text;

namespace TesteSoftPlan.Controllers
{
    public class TesteController : Controller
    {
        private readonly IConfiguration _config;
        private const string rotaApi = "api/calculo/";

        public TesteController(IConfiguration configuration)
        {
            _config = configuration;
        }

        public IActionResult Index()
        {
            ViewBag.LinkProjeto = GetUrlProjetoGitHub();
            return View();
        }

        public ActionResult GetTaxa()
        {
            using (var client = new TesteSfotPlanClient(_config))
            {
                var obj = new object();

                var response = client.Client.GetAsync(rotaApi + "taxajuros").Result;

                if (!response.IsSuccessStatusCode)
                {
                    obj = new { data = "", erro = "Erro ao retornar taxa:" + response.StatusCode.ToString() };
                }
                else
                    obj = new { data = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result), erro = "" };



                return new JsonResult(obj);
            }
        }

        [HttpPost]
        public ActionResult CalcularTaxa(decimal valorinicial, int meses)
        {
            using (var client = new TesteSfotPlanClient(_config))
            {
                var obj = new object();

                var value = new Dictionary<string, string>
                 {
                    { "valorinicial", valorinicial.ToString() },
                    { "meses", meses.ToString() }
                 };

                var response = client.Client.PostAsync(rotaApi + "calculajuros?valorinicial=" + valorinicial + "&meses=" + meses, null).Result;

                if (!response.IsSuccessStatusCode)
                {
                    obj = new { data = "", erro = "Erro ao retornar taxa:" + response.StatusCode.ToString() };
                }
                else
                    obj = new { data = JsonConvert.DeserializeObject<string>(response.Content.ReadAsStringAsync().Result).Replace(".", ","), erro = "" };

                return new JsonResult(obj);
            }
        }

        protected StringContent GetStringContent(object objeto)
        {
            var data = JsonConvert.SerializeObject(objeto);
            var content = new StringContent(data, Encoding.UTF8, "application/json");

            return content;
        }

        private string GetUrlProjetoGitHub()
        {
            try
            {

                using (var client = new TesteSfotPlanClient(_config))
                {
                    var link = client.Client.GetAsync(rotaApi + "showmethecode").Result;

                    if (link.IsSuccessStatusCode)
                    {
                        return JsonConvert.DeserializeObject<string>(link.Content.ReadAsStringAsync().Result);
                    }

                    return string.Empty;
                }

            }
            catch (Exception ex)
            {

                return "";
            }
        }
    }
}