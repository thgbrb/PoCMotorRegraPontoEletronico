using System.Collections.Generic;
using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto.Validacao
{
    /// <summary>
    /// Validador é a classe responsável por fazer a validação dos registros.
    /// Nessa classe são adicionadas as estratégias de validação que serão executadas
    /// contra registros.
    /// </summary>
    public class Validador
    {
        //Lista com instâncias de estratégias que serão aplicadas nos registros.
        private readonly IList<IValidadorStrategy> _strategies = new List<IValidadorStrategy>();

        // Objeto registro que será validado pelas estratégias adicionadas em _strategies.
        private readonly Registro _registroCurrent;

        // Objeto registro que pode ser usado para validar batidas de turnos que iniciam em um dia e finalizam em outro.
        private readonly Registro _registroNext;

        private Validador(Registro registroCurrent, Registro registroNext = default)
        {
            _registroCurrent = registroCurrent;
            _registroNext = registroNext;
        }

        /// <summary>
        /// Validador Factory
        /// </summary>
        /// <param name="registroCurrent">Registro que será validado</param>
        /// <param name="registroNext">Caso o turno não finalize no mesmo dia que iniciou, pode ser adicionado o registro seguinte para fazer as validações</param>
        /// <returns>Instância Validador</returns>
        public static Validador Inicializar(Registro registroCurrent, Registro registroNext = default)
            => new Validador(registroCurrent, registroNext);

        /// <summary>
        /// Adicona estratégias de validadores que serão executadas contra os registros do objeto Validador.
        /// </summary>
        /// <param name="validador">Enum das estratégias de validação disponíveis.</param>
        /// <returns>Fluent Validador</returns>
        public Validador AdicionarValidador(Validadores validador)
        {
            var strategy =
                StrategySelector.ValidadoresDisponiveis(validador);

            _strategies.Add(strategy);

            return this;
        }

        /// <summary>
        /// Executa as estratégias adicionadas e retorna o resultado da execução
        /// </summary>
        /// <returns>Retorna um objeto Resultado para cada estratégias executada.</returns>
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