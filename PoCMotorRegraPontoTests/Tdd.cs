using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using PocCMotorRegraPonto;
using PocCMotorRegraPonto.Registros;
using PocCMotorRegraPonto.Specifications;
using Xunit;
using Xunit.Extensions;

namespace PoCMotorRegraPontoTests
{
    public class Tdd
    {
        [Theory]
        [ClassData(typeof(MockRegistros))]
        public void HorarioDeUmaTuplaDeMarcacaoDeveSerMaiorQueZero(Registro registro)
        {
            Assert.True(registro.Esquerda.Horario > 0 && registro.Direita.Horario > 0);
        }

        [Theory]
        [ClassData(typeof(MockRegistros))]
        public void DeveAplicarDuasRegrasParaUmConjuntoDeMarcacoes(Registro registro)
        {
            // Arrange
            var validador = new Validador()
                .AdicionarSpecification(new IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecification())
                .AdicionarSpecification(new NumeroDeHorasDiariosDeveSerMenorOuIgualANoveHorasEMeia());

            // Act
            var resultado = validador
                .Validar(registro)
                .ToList();

            // Assert
            Assert.NotNull(resultado);
            Assert.True(resultado.Any());
        }

        public void ImprimiNaTelaOResultadoDeUmaAnalise()
        {
            // Simula o recebimento de uma lista de marcações de um colaborador.
            // Lembrando que para aplicar as regras de intervalos é necessário ter um par de marcações
            var registros = new List<Registro>()
            {
                new Registro(esquerda: new Batida(12, 01), direita: new Batida(12, 34)),
                new Registro(esquerda: new Batida(13, 01), direita: new Batida(14, 12))
            };

            var validador = new Validador()
                .AdicionarSpecification(new IntervaloNoDiaDeveSerMaiorOuIgualQueUmaHoraSpecification())
                .AdicionarSpecification(new NumeroDeHorasDiariosDeveSerMenorOuIgualANoveHorasEMeia());

            foreach (var registro in registros)
            {
                // Processa resultado (materializa) ou yield return
                var resultado = validador.Validar(registro);

                // PoC: Processando resultado
                var r = resultado.First();
                Console.WriteLine($"{r.EhSucesso} - {r.Valor} - {r.Mensagem}");
            }
        }

        [Theory]
        [ClassData(typeof(MockBatidas))] // Não vai funcionar esse mock
        public void DeveReceberUmaListaDeRegistro()
        {
            // Obtem um registro, que é composto por uma lista de batidas.

            // Cria validador e Executa validação

            // var resultado = Validador
            //     .AdicionarRegistro(registro)
            //     .AdicionarValidador(Validadores.Estagiario)
            //     .AdicionarValidador(Validadores.CLT)
            //     .AdicionarValidador(Validadores.MenorAprendiz)
            //     .OrganizarTurnos()
            //     .Validar();

            // Trata o resultado
        }
    }

    public class Cenarios
    {
        public void DeveDescobrirOTurnoDaMarcacao()
        {
        }

        public void DeveCalcularAQuantidadeDeHorasTrabalhadasNoDia()
        {
        }

        public void DeveDescobrirAPrimeiraMarcacaoDoDia()
        {
        }

        public void DeveDescobrirAUltimaMarcacaoDoDia()
        {
        }

        public void DeveRetornarErroNumeroHorasDoDiaSuperiorANoveHorasEMeia()
        {
        }

        public void DeveRetornarSucessoNumeroDeHorasDoDiaInferiorANoveHorasEMeia()
        {
        }

        public void DeveDescobrirAJornadaDoTurno()
        {
            // 6 horas
            // 8,5 horas
            // outros
        }

        public void DeveCriarValidacaoParaUmTurnoDeOitoHorasEMeia()
        {
        }
    }
}