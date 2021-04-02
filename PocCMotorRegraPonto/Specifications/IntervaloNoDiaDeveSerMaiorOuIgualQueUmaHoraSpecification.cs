using System;
using System.Linq.Expressions;
using PocCMotorRegraPonto.Registros;

namespace PocCMotorRegraPonto.Specifications
{
    // Define uma regra que será aplicada para um par de marcação
    // O objetivo é que essa espeficação receba um par de marcações e aplique a regra.
    // Depois de validado a regra é devolvido um objeto que contém o resultado da validação.
    public class IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecification : Specification<Registro>
    {
        // Mensagem de erro é uma constante é faz sentido somente dentro da própria specification
        private const string ERRO = "O tempo de intervalo deve ser maior ou igual que 1 hora.";

        // Define uma função que validará as regras para um par de marcação
        protected override Func<Registro, Resultado> ExpressionDefinition() =>
            marcacoes =>
            {
                // Aplica regra nos pares de marcação
                var valor = marcacoes.Direita.Horario - marcacoes.Esquerda.Horario;

                // Define regra para indicar sucesso
                var ehSucesso = valor >= 1;

                // Cria um objeto com as informações do processamento da regra
                var resultado = new Resultado(
                    valor: valor.ToString(),
                    mensagem: ehSucesso ? string.Empty : ERRO,
                    ehSucesso: ehSucesso);

                return resultado;
            };
    }
}