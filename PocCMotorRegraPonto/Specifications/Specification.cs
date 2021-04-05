using System;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Validacao;

namespace PocCMotorRegraPonto.Specifications
{
    /// <summary>
    /// Define uma regra que será aplicada para um par de marcação
    /// O objetivo é que essa espeficação receba um par de marcações e aplique a regra.
    /// Depois de validado a regra é devolvido um objeto que contém o resultado da validação.
    /// </summary>
    /// <typeparam name="T">Aplica uma especificação no objeto T.</typeparam>
    public abstract class Specification<T>
    {
        /// <summary>
        /// Define a expressão que será aplicada.
        /// </summary>
        /// <returns>Retorna a uma função a expressão que será aplicada.</returns>
        protected abstract Func<Registro, Registro, Resultado> ExpressionDefinition();

        /// <summary>
        /// Aplica a expressão nos objetos de registro.
        /// </summary>
        /// <param name="current">Registro atual.</param>
        /// <param name="next">Próximo registro, usado para casos onde a expressão trata dois registros (ex.: turno noturno).</param>
        /// <returns>Retorna o resultado da especificação.</returns>
        public Resultado IsSatisfyBy(Registro current, Registro next)
        {
            var predicate = ExpressionDefinition();
            return predicate(current, next);
        }
    }
}