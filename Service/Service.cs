using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dominio.Interface;

namespace Service
{
    public class Service : IService, IDisposable
    {
        private readonly IRepository _repository;

        public Service(IRepository repository)
        {
            _repository = repository;
        }

        public decimal Calculo(decimal valorinicial, int meses)
        {
            return _repository.Calculo(valorinicial, meses);
        }

        public string GetUrlProject()
        {
            return _repository.GetUrlProject();
        }

        public decimal TaxaJuros()
        {
            return _repository.TaxaJuros();
        }

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }
    }
}
