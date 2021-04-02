using System;

namespace PocCMotorRegraPonto
{
    public interface IMarcacao
    {
        public DirecaoMarcacao DirecaoMarcacao;
        public DateTime Data;
        public Horario Horario;
    }
}