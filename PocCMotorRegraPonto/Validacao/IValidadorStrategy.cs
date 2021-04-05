using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto.Validacao
{
    /// <summary>
    /// Definição da estratégia de validação.
    /// </summary>
    public interface IValidadorStrategy
    {
        /// <summary>
        /// Define o método que executará a validação.
        /// </summary>
        /// <param name="current">Registro objeto atual que será validado.</param>
        /// <param name="next">Objeto do próximo registro</param>
        /// <returns>Retorna o resultado da validação de uma estratégia.</returns>
        Resultado Executar(Registro current, Registro next);
    }
}