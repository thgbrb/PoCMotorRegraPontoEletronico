using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Specifications;

namespace PocCMotorRegraPonto.Validacao.Strategies
{
    /// <inheritdocs/>
    public class Jornada40HorasSemanaisStrategy : IValidadorStrategy
    {
        /// <inheritdocs/>
        public Resultado Executar(Registro current, Registro next)
        {
            var strategy = new IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecification();

            var resultado = strategy.IsSatisfyBy(current, default);

            return resultado;
        }
    }
}