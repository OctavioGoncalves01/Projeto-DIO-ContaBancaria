using System;
using System.Collections.Generic;

namespace BancoDIO
{
    class Program
    {
        static List<Conta> ListaConta = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = ObterOpcaoUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                    case "1":
                        ListarContas();
                        break;
                    case "2":
                        InserirConta();
                        break;
                    case "3":
                        Transferir();
                        break;
                    case "4":
                        Sacar();
                        break;
                    case "5":
                        Depositar();
                        break;
                    case "6":
                        Console.Clear();
                        break;
                    
                    default:
                    throw new ArgumentOutOfRangeException();
                }

                opcaoUsuario = ObterOpcaoUsuario();
            }
            
            Console.WriteLine("Obrigado por utilizar nossos serviços");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.WriteLine("Digite a conta origem:  ");
            int IndiceContaOrigem = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite a conta destino:  ");
            int IndiceContaDestino = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o valor da transferencia:  R$");
            double ValorTransferencia = double.Parse(Console.ReadLine());

            ListaConta[IndiceContaOrigem].Transferir(ValorTransferencia, ListaConta[IndiceContaDestino]);

        }
        private static void Sacar()
        {
            Console.Write("Digite o numero da conta:  ");
            int IndiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de seque:  R$");
            double ValorSAque = double.Parse(Console.ReadLine());

            ListaConta[IndiceConta].Sacar(ValorSAque);
        }

        private static void Depositar()
        {
            Console.Write("Digite o numero da conta:  ");
            int IndiceConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o valor de deposito:  R$");
            double ValorDeposito = double.Parse(Console.ReadLine());

            ListaConta[IndiceConta].Sacar(ValorDeposito);
        }        
        private static void InserirConta()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Digite 1 para Conta Fisica ou 2 para Conta Juridica: ");
            int EntradatipoConta = int.Parse(Console.ReadLine());

            Console.WriteLine("Digite o nome do cliente: ");
            string EntradaNome = Console.ReadLine();

            Console.WriteLine("Digite o Saldo inicial: ");
            double EntradaSaldo = double.Parse(Console.ReadLine());

            Console.WriteLine("Digite o credito R$: ");
            double EntradaCredito = double.Parse(Console.ReadLine());

            Conta NovaConta = new Conta(TipoConta: (TipoConta)EntradatipoConta,
                                        Saldo: EntradaSaldo,
                                        Credito: EntradaCredito,
                                        Nome: EntradaNome);
            ListaConta.Add(NovaConta);

        }

        private static void ListarContas()
        {
            Console.WriteLine("Listar Contas");
            
            if (ListaConta.Count == 0)
            {
                Console.WriteLine("Não existe contas!!");
                return;
            }

            for (int i =0; i < ListaConta.Count; i++)
            {
                Conta conta = ListaConta[i];
                Console.WriteLine(">{0}", i);
                Console.WriteLine(conta);
            }
        }

        private static string ObterOpcaoUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio Banco Bem vindo!!");
            Console.WriteLine("Informe a opção desejada:  ");

            Console.WriteLine("1- Listar contas: ");
            Console.WriteLine("2- Incerir nova conta:  ");
            Console.WriteLine("3- Transferir: ");
            Console.WriteLine("4- Sacar:  ");
            Console.WriteLine("5- Depositar:  ");
            Console.WriteLine("6- Lipar tudo");
            Console.WriteLine("X- Encerrar consulta:  ");
            Console.WriteLine();

            string opcaoUsuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaoUsuario;
        }
    }
}
