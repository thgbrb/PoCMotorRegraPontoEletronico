using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.Immutable;
using System.Linq;
using System.Numerics;

namespace PocCMotorRegraPonto.Registros
{
    public class Registro
    {
        const byte TAMANHO_MAXIMO_BATIDAS = 8;
        private IList<Batida> _batidas = new List<Batida>(TAMANHO_MAXIMO_BATIDAS);
        private bool isBuilt;
        private IImmutableList<Batida> batidasInternal;

        private Registro()
        {
        }

        public bool EhValido;

        public IImmutableList<Batida> Batidas
        {
            get => isBuilt
                ? batidasInternal
                : throw new InvalidOperationException("Objeto registro não foi construido. Execute Build().");
            set => batidasInternal = value;
        }

        public static Registro Criar()
            => new Registro();

        public Registro AdicionarBatida(Batida batida)
        {
            _batidas.Add(batida);

            return this;
        }

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

        public Registro Build()
        {
            var registro = new BitArray(TAMANHO_MAXIMO_BATIDAS);

            for (short i = 0; i < _batidas.Count; i++)
                registro[i] = _batidas[i].IsInicializada;

            var registroByte = new byte[TAMANHO_MAXIMO_BATIDAS];
            registro.CopyTo(registroByte, 0);

            var registroInt16 = BitConverter
                .ToUInt16(registroByte, 0);

            EhValido = BitOperations
                .PopCount(registroInt16) % 2 == 0;

            if (EhValido)
                batidasInternal = _batidas
                    .OrderBy(x => x.Horario)
                    .ToImmutableList();

            isBuilt = true;

            return this;
        }
    }
}