namespace PocCMotorRegraPonto
{
    public class Resultado
    {
        public string Valor { get; set; }
        public string Mensagem { get; set; }
        public bool EhSucesso { get; set; }

        public Resultado(string valor, string mensagem, bool ehSucesso)
        {
            Valor = valor;
            Mensagem = mensagem;
            EhSucesso = ehSucesso;
        }
    }
}