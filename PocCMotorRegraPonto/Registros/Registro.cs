namespace PocCMotorRegraPonto.Registros
{
    public class Registro
    {
        public Batida Esquerda;
        public Batida Direita;

        public Registro(Batida esquerda, Batida direita)
        {
            Esquerda = esquerda;
            Direita = direita;
        }
    }
}