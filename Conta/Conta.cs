using System;
namespace BancoDIO
{
    public class Conta
    {
        private TipoConta TipoConta { get; set; }
        private double Saldo { get; set; }
        private double Credito { get; set; }
        private string Nome { get; set; }

        public Conta(TipoConta TipoConta, double Saldo, double Credito, string Nome)
        {
            this.TipoConta = TipoConta;
            this.Saldo = Saldo;
            this.Credito = Credito;
            this.Nome = Nome;
        }

        public bool Sacar(double ValorSAque)
        {
            if (this.Saldo - ValorSAque < (this.Credito *-1))
            {
                Console.WriteLine("Saldo insuficiente");
                return false;
            }

            this.Saldo -= ValorSAque;

            Console.WriteLine("Saldo atual R$: {} para sua conta {}.", this.Saldo, this.Nome);
            return true;

        }
        public void Depositar(double ValorDeposito)
        {
            this.Saldo += ValorDeposito;

            Console.WriteLine("Saldo Atual é de R$: {}", this.Saldo);
        }

        public void Transferir(double ValorTransferencia, Conta ContaDestino)
        {
            if (this.Sacar(ValorTransferencia))
            {
                ContaDestino.Depositar(ValorTransferencia);

            }
        }

        public override string ToString()
        {
            string Retorno = "";
            Retorno += "TipoConta" + this.TipoConta + " | ";
            Retorno += "Nome" + this.Nome + " | ";
            Retorno += "Saldo" + this.Saldo + " | ";
            Retorno += "Credito" + this.Credito;
            return Retorno;
        }
    }
}
