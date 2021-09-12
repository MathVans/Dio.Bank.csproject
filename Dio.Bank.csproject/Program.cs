using Dio.Bank.csproject.Classes;
using Dio.Bank.csproject.Enum;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dio.Bank.csproject
{
    class Program
    {
        static List<Conta> listaContas = new List<Conta>();
        static void Main(string[] args)
        {
            string opcaoUsuario = OpUsuario();

            while (opcaoUsuario.ToUpper() != "X")
            {
                switch (opcaoUsuario)
                {
                   case "1":
                       ListarContas();
                        break;
                   case "2":
                       InserirContas();
                        break;
                   case "3":
                        Transferir();
                        break;
                   case "4":
                        SacarConta();
                        break;
                   case "5":
                        Depositar();
                        break;
                   case "c":
                        Console.Clear();
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();

                }
                
                opcaoUsuario = OpUsuario();
                

            }
            Console.WriteLine("Obrigado por utilizar nossos serviços!!!");
            Console.ReadLine();
        }

        private static void Transferir()
        {
            Console.Write("\nInforme o número da sua conta: ");
            int indice = int.Parse(Console.ReadLine());

            Console.Write("\nInforme o número da conta para a transação: ");
            int indiceT = int.Parse(Console.ReadLine());


            Console.Write("\nInforme o valor do transferência:");
            double valorT = double.Parse(Console.ReadLine());

            listaContas[indice].Transferir(valorT, listaContas[indiceT]);
        }

        private static void Depositar()
        {
            Console.Write("\nInforme o número da conta: ");
            int indice = int.Parse(Console.ReadLine());


            Console.Write("\nInforme o valor do Depósito:");
            double valorDeposito = double.Parse(Console.ReadLine());

            listaContas[indice].Depositar(valorDeposito);
        }

        private static void SacarConta()
        {
            Console.Write("\nInforme o número da conta: ");
            int indice = int.Parse(Console.ReadLine());


            Console.Write("\nInforme o valor do saque:");
            double valorSaque = double.Parse(Console.ReadLine());

            listaContas[indice].Sacar(valorSaque);
        }


        private static void ListarContas()
        {
            Console.WriteLine("Listando Contas");
            if (listaContas.Count == 0)
            {
                Console.WriteLine("Nenhuma conta cadastrada");
                return;
            }
            for(int i = 0; i < listaContas.Count; i++)
            {
                Conta conta = listaContas[i];
                Console.Write("#{0}  {1}\n", i, conta);
                

            }
        }

        private static void InserirContas()
        {
            Console.WriteLine("Inserir nova conta");

            Console.WriteLine("Tipo de Conta:\n1-  Fisica\n2-  Juridica");
            int entradaTipoConta = int.Parse(Console.ReadLine());

            Console.Write("Digite o nome do Cliente:");
            string entradaNome = Console.ReadLine();

            Console.Write("Digite o Saldo do Cliente:");
            double entradaSaldo = double.Parse(Console.ReadLine());

            Console.Write("Digite o Credito do Cliente:");
            double entradaCredito = double.Parse(Console.ReadLine());

            Conta novaConta = new Conta(tipoConta: (TipoConta)entradaTipoConta, 
                                        Saldo: entradaSaldo, 
                                        Credito: entradaCredito, 
                                        Nome: entradaNome);

            listaContas.Add(novaConta);
            

        }

            private static string OpUsuario()
        {
            Console.WriteLine();
            Console.WriteLine("Dio bank ao seu dispor!!!! \nInforme a opção desejada:\n   1-  Listar Contas\n   2-  Inserir nova Conta\n   3-  Transferir\n   4-  Sacar\n   5-  Depositar\n   c-  Limpar a Tela\n   x-  Sair ");

            string opcaousuario = Console.ReadLine().ToUpper();
            Console.WriteLine();
            return opcaousuario;



        }
    }
}
