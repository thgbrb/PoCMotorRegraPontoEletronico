using System.Collections.Generic;
using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto.Validacao.Strategies
{
    public class MenorAprendizStrategy : IValidadorStrategy
    {
        public Resultado Executar(Registro current, Registro next)
        {
            // Define uma coleção de specifications que satisfaçam a estratégia
            // Valida as batidas do registro
            
            throw new System.NotImplementedException();
            
            // public IEnumerable<Resultado> Validar(Registro registro)
            // {
            //     foreach (var specification in _specifications)
            //     {
            //         yield return specification.IsSatisfyBy(registro);
            //     }
            // }
        }
    }
}