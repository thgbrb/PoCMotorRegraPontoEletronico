using System;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Validacao;

namespace PocCMotorRegraPonto.Specifications
{
    public abstract class Specification<T>
    {
        protected abstract Func<Registro, Resultado> ExpressionDefinition();

        public Resultado IsSatisfyBy(Registro registro)
        {
            var predicate = ExpressionDefinition();
            return predicate(registro);
        }
    }
}