using System;
using System.Collections.Generic;

namespace DIO.BANK

{
    class Program
    {
        static List<Conta> listContas = new List<Conta>();
        static void Main(string[] args)
        {   
          string opcaoUsuario = ObterOpcao();
          Console.WriteLine();  

          while (opcaoUsuario.ToUpper() != "X") {
            switch (opcaoUsuario) {
              case "1": 
                ListarContas();             
                break;
              case "2":
                InserirConta();
                break;
              case "3":
                Tranferir();
                break;
              case "4":
                Sacar();
                break;
              case "5":
                Depositar();
                break;
              case "C":
                Console.Clear();
                break;
              case "X":
                break;
              default:
                throw new ArgumentOutOfRangeException();
            }
            opcaoUsuario = ObterOpcao();
            }
        
        }

    private static void Depositar()
    {
      Console.Write("Digite o número da sua conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor do depósito: ");
      double valorDeposito = double.Parse(Console.ReadLine());

      listContas[indiceConta].DepositarDinheiro(valorDeposito);
    }

    private static void Tranferir()
    {
      Console.Write("Digite o número da sua conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o número da conta destino: ");
      int contaDestino = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser transferido: ");
      double valorTransferencia = double.Parse(Console.ReadLine());

      listContas[indiceConta].Transferir(valorTransferencia, listContas[contaDestino]);
    }

    private static void Sacar()
    {
      Console.Write("Digite o número da conta: ");
      int indiceConta = int.Parse(Console.ReadLine());

      Console.Write("Digite o valor a ser sacado: ");
      double valorSaque = double.Parse(Console.ReadLine());

      listContas[indiceConta].SacarDinheiro(valorSaque);
    }

    private static void ListarContas()
    {
      if (listContas.Count != 0) {
        foreach (Conta conta in listContas) {
          Console.WriteLine($"[{listContas.IndexOf(conta)}] - {conta}");
        }
      }
    }

    private static void InserirConta()
    {
      Console.Write("Insira o nome: ");
      string entradaNome = Console.ReadLine();
      Console.Write("Insira o tipo da conta (1: Física | 2: Jurídica): ");
      int entradaTipoConta = int.Parse(Console.ReadLine());
      Console.Write("Insira o saldo inicial: ");
      double entradaSaldo = double.Parse(Console.ReadLine());
      Console.Write("Insira o crédito inicial: ");
      double entradaCredito = double.Parse(Console.ReadLine());

      Conta novaConta = new Conta(tipoConta: (TipoConta) entradaTipoConta, saldo: entradaSaldo, credito: entradaCredito, nome: entradaNome);      
      listContas.Add(novaConta);
    }

    private static string ObterOpcao()
        {
          Console.WriteLine();  
          Console.WriteLine("1 - Listar contas");
          Console.WriteLine("2 - Criar nova conta");
          Console.WriteLine("3 - Transferir");
          Console.WriteLine("4 - Sacar");
          Console.WriteLine("5 - Depositar");
          Console.WriteLine("C - Limpar tela");
          Console.WriteLine("X - Sair");
          Console.WriteLine();  

        
          return Console.ReadLine().ToUpper();
        }
    }
}
