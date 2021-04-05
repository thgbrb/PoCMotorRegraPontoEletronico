using PocCMotorRegraPonto.Validacao.Strategies;

namespace PocCMotorRegraPonto.Validacao
{
    /// <summary>
    /// Enumerador de estratégias disponíveis.
    /// </summary>
    public enum Validadores
    {
        Estagiario = 1,
        CLT = 2,
        MenorAprendiz = 4,
        Jornada40HorasSemanais = 8,
        JornadaNoturna = 16
    }

    /// <summary>
    /// Gerencia a criação e seleção de estratégias de validação.
    /// </summary>
    static class StrategySelector
    {
        /// <summary>
        /// Registra e gerencia as estratégias disponíveis. Quando uma nova estratégia é criada é necessário
        /// adicionar o seu Enum em Validadores e a sua criação no switch.
        /// </summary>
        /// <param name="validadores">Enum de estratégias disponíveis.</param>
        /// <returns>Instância de uma estratégia de validação.</returns>
        public static IValidadorStrategy ValidadoresDisponiveis(Validadores validadores)
        {
            return validadores switch
            {
                Validadores.Estagiario => new EstagiarioStrategy(),
                Validadores.MenorAprendiz => new MenorAprendizStrategy(),
                Validadores.CLT => new CltStrategy(),
                Validadores.Jornada40HorasSemanais => new Jornada40HorasSemanaisStrategy(),
                Validadores.JornadaNoturna => new JornadaNoturnaStrategy()
            };
        }
    }
}