using System;
using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto.Specifications
{
    public class NumeroDeHorasDiariosDeveSerMenorOuIgualANoveHorasEMeia : Specification<Registro>
    {
        private const string ERRO = "A jornada de trabalho diária deve ser menor ou igual a 9,5 horas.";

        protected override Func<Registro, Resultado> ExpressionDefinition() =>
            marcacoes =>
            {
                var valor = marcacoes.Direita.Horario - marcacoes.Esquerda.Horario;
                var ehSucesso = valor <= 9.5m;
                var resultado = new Resultado(
                    valor: valor.ToString(),
                    mensagem: ehSucesso ? string.Empty : ERRO,
                    ehSucesso: ehSucesso);

                return resultado;
            };
    }
}