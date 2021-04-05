using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;

namespace PocCMotorRegraPonto.Registros
{
    /// <summary>
    /// Cria um registro de marcação do ponto. Um registro é composto por uma coleção de batidas.
    /// </summary>
    public class Registro
    {
        /// <summary>
        /// É o número máximo de batidas que podem ser adicionadas no ponto em um dia de acordo com as regras da CLT.
        /// </summary>
        const byte NUMERO_MAXIMO_BATIDAS_NO_DIA = 8;

        /// <summary>
        /// Coleção de batidas do registro.
        /// </summary>
        private IList<Batida> _batidas = new List<Batida>(NUMERO_MAXIMO_BATIDAS_NO_DIA);

        /// <summary>
        /// Marca o objeto como construído.
        /// </summary>
        private bool isBuilt;

        /// <summary>
        /// Coleção de batidas de um registro válido.
        /// </summary>
        private IImmutableList<Batida> batidasInternal;

        private Registro()
        {
        }

        /// <summary>
        /// Marca o registo como  válido.
        /// </summary>
        public bool EhValido;

        /// <inheritdocs />
        public IImmutableList<Batida> Batidas
        {
            get => isBuilt
                ? batidasInternal
                : throw new InvalidOperationException("Objeto registro não foi construido. Execute Build().");
            set => batidasInternal = value;
        }

        /// <summary>
        /// Factory Registro.
        /// </summary>
        /// <returns>Retorna uma instância de Registro.</returns>
        public static Registro Criar()
            => new Registro();

        /// <summary>
        /// Adiciona uma batida na coleção que será validada posteriormente. 
        /// </summary>
        /// <param name="batida">Objeto batida.</param>
        /// <returns>Fluent Registro.</returns>
        public Registro AdicionarBatida(Batida batida)
        {
            _batidas.Add(batida);

            return this;
        }

        /// <summary>
        /// Adiciona uma coleção de batidas que serão posteriormente validadas.
        /// </summary>
        /// <param name="batidas">Coleção de batidas</param>
        /// <returns>Fluent Build.</returns>
        /// <exception cref="ArgumentNullException">Coleção de batidas não pode ser nula.</exception>
        /// <exception cref="ArgumentException">Coleção de batidas deve ter no mínimo uma batida.</exception>
        public Registro AdicionarBatidas(IList<Batida> batidas)
        {
            if (batidas == null)
                throw new ArgumentNullException();

            if (!batidas.Any())
                throw new ArgumentException();

            foreach (var batida in batidas)
                _batidas.Add(batida);

            return this;
        }

        /// <summary>
        /// Constrói e valida o registro. Um registro deve ter pares de batidas, ou seja, a coleção de batidas
        /// deve sempre ter um número par de itens. As estratégias de validações acontecem na comparação de pares de registros.
        /// Ex.: Intervalos de descanço, jornada diária, entre outros.
        /// </summary>
        /// <returns>Fluent Registro construído.</returns>
        public Registro Build()
        {
            var registro = new BitArray(NUMERO_MAXIMO_BATIDAS_NO_DIA);

            for (short i = 0; i < _batidas.Count; i++)
                registro[i] = _batidas[i].IsInicializada;

            var registroByte = new byte[NUMERO_MAXIMO_BATIDAS_NO_DIA];
            registro.CopyTo(registroByte, 0);

            var registroInt16 = BitConverter
                .ToUInt16(registroByte, 0);

            var quantidade = BitOperations
                .PopCount(registroInt16);

            EhValido = (quantidade ^ 1) == quantidade + 1;

            if (EhValido)
                batidasInternal = _batidas
                    .OrderBy(x => x.Horario)
                    .ToImmutableList();

            isBuilt = true;

            return this;
        }
    }
}