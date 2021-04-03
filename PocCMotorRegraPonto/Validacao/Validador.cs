using System;
using System.Collections;
using System.Collections.Generic;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Specifications;
using PocCMotorRegraPonto.Validacao.Strategies;

namespace PocCMotorRegraPonto.Validacao
{
    public class Validador
    {
        private readonly IList<IValidadorStrategy> _strategies = new List<IValidadorStrategy>();
        private Registro _registro;

        private Validador(Registro registro)
            => _registro = registro;

        public static Validador Inicializar(Registro registro)
            => new Validador(registro);

        public Validador AdicionarValidador(Validadores validador)
        {
            var strategy =
                StrategySelector.ValidadoresDisponiveis(validador);

            _strategies.Add(strategy);

            return this;
        }

        public IEnumerable<Resultado> Executar()
        {
            foreach (var strategy in _strategies)
            {
                var resultado = strategy
                    .Executar(_registro);

                yield return resultado;
            }
        }
    }
}