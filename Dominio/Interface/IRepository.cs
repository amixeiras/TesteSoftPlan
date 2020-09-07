using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dominio.Interface
{
    public interface IRepository
    {
        decimal Calculo(decimal valorinicial, int meses);

        decimal TaxaJuros();

        string GetUrlProject();
    }
}
