using System;
using System.Collections.Generic;
using System.Diagnostics;
using PocCMotorRegraPonto.Validacao.Strategies;

namespace PocCMotorRegraPonto.Validacao
{
    public enum Validadores
    {
        Estagiario = 1,
        CLT = 2,
        MenorAprendiz = 4,
        Jornada40HorasSemanais = 8
    }

    static class StrategySelector
    {
        public static IValidadorStrategy ValidadoresDisponiveis(Validadores validadores)
        {
            return validadores switch
            {
                Validadores.Estagiario => new EstagiarioStrategy(),
                Validadores.MenorAprendiz => new MenorAprendizStrategy(),
                Validadores.CLT => new CltStrategy(),
                Validadores.Jornada40HorasSemanais => new Jornada40HorasSemanaisStrategy()
            };
        }
    }
}