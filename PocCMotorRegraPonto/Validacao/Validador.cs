using System;
using System.Collections;
using System.Collections.Generic;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Validacao.Strategies;

namespace PocCMotorRegraPonto.Validacao
{
    public enum Validadores
    {
        Estagiario = 1,
        CLT = 2,
        MenorAprendiz = 4
    }

    public class Validador
    {
        Lazy<Dictionary<Enum, Func<IValidador>>> _validadores = new Lazy<Dictionary<Enum, Func<IValidador>>>(
            () =>
                new Dictionary<Enum, Func<IValidador>>()
                {
                    {Validadores.Estagiario, () => new EstagiarioStrategy()},
                    {Validadores.CLT, () => new CltStrategy()},
                    {Validadores.MenorAprendiz, () => new MenorAprendizStrategy()}
                }
        );

        private readonly IList<Specification<Registro>>
            _specifications = new List<Specification<Registro>>();

        private readonly IList<Func<IValidador>> _strategies = new List<Func<IValidador>>();

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

        public Validador AdicionarRegistro(Registro registro)
        {
            throw new NotImplementedException();
        }

        // Faz sentido usar enum aqui?
        public Validador AdicionarValidador(Validadores validador)
        {
            if (_validadores.Value.TryGetValue(validador, out var strategy))
                _strategies.Add(strategy);

            return this;
        }

        public Validador OrganizarTurnos()
        {
            throw new NotImplementedException();
        }

        public IList<Resultado> Executar(Registro registro)
        {
            var resultados = new List<Resultado>();
            foreach (var strategy in _strategies)
            {
                var resultado = strategy
                    .Invoke()
                    .Executar(registro);

                resultados.Add(resultado);
            }

            return resultados;
        }
    }
}