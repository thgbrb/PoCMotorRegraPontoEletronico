using System;
using System.Linq;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Validacao;

namespace PocCMotorRegraPonto.Specifications
{
    public class NumeroDeHorasDiariosDeveSerMenorOuIgualANoveHorasEMeia : Specification<Registro>
    {
        private const string ERRO = "A jornada de trabalho diária deve ser menor ou igual a 9,5 horas.";

        protected override Func<Registro, Resultado> ExpressionDefinition() =>
            marcacoes =>
            {
                var valor =
                    marcacoes.Batidas.Last().Horario - marcacoes.Batidas.First().Horario;

                var ehSucesso = valor <= 9.5m;
                
                var resultado = new Resultado(
                    valor: valor.ToString(),
                    mensagem: ehSucesso ? string.Empty : ERRO,
                    ehSucesso: ehSucesso);

                return resultado;
            };
    }
}