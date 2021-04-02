using System;
using System.Collections.Generic;
using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto
{
    public class Validador
    {
        private readonly IList<Specification<Registro>>
            _specifications = new List<Specification<Registro>>();

        public Validador AdicionarSpecification(Specification<Registro> specification)
        {
            _specifications.Add(specification);

            return this;
        }

        public IEnumerable<Resultado> Validar(Registro registro)
        {
            foreach (var specification in _specifications)
            {
                yield return specification.IsSatisfyBy(registro);
            }
        }
    }
}