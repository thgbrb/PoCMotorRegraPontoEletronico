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
        private readonly Registro _registroCurrent;
        private readonly Registro _registroNext;

        private Validador(Registro registroCurrent, Registro registroNext = default)
        {
            _registroCurrent = registroCurrent;
            _registroNext = registroNext;
        }

        public static Validador Inicializar(Registro registroCurrent, Registro registroNext = default)
            => new Validador(registroCurrent, registroNext);

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
                    .Executar(_registroCurrent, _registroNext);

                yield return resultado;
            }
        }
    }
}