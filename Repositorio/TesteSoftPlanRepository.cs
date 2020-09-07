using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio;

namespace Repositorio
{
    public class TesteSoftPlanRepository : Dominio.Interface.IRepository, IDisposable
    {
        private const string UrlGit = "https://github.com/amixeiras/TesteSoftPlan";
        public decimal Calculo(decimal valorinicial, int meses)
        {
            var taxa = TaxaJuros();
            taxa += 1;
            decimal taxaMensal = 1;

            for (int i = 0; i < meses; i++)
            {
                taxaMensal *= taxa;
            }

            var result = valorinicial * taxaMensal;

            return Math.Truncate(100 * result) / 100;
        }

        public string GetUrlProject()
        {
            return UrlGit;
        }

        public decimal TaxaJuros()
        {
            return 0.01M;
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
