using System;
namespace DIO.BANK

{
  public class Conta
  {
    private TipoConta TipoConta { get; set; }
    private double Saldo { get; set; }
    private double Credito { get; set; }
    private string Nome { get; set; }

    public Conta() {}

    public Conta(TipoConta tipoConta, double saldo, double credito, string nome)
    {
      this.TipoConta = tipoConta;
      this.Saldo = saldo;
      this.Credito = credito;
      this.Nome = nome;
    }

    public void SacarDinheiro(double saque)
    {
      double saldoFinal = this.Saldo - saque;
      bool resultado = saldoFinal >= 0;
      if (resultado) {
        this.Saldo -= saque;
        Console.WriteLine($"Você sacou {saque}. Saldo atual: {this.Saldo}.");
      } else if (this.Credito >= saque) {
        this.Saldo -= saque;
        Console.WriteLine($"Você sacou {saque} usando crédito. Saldo atual: {this.Saldo}.");
      }
    }

    public void DepositarDinheiro(double deposito)
    {
      this.Saldo = Saldo + deposito;
    }

    public void Transferir(double valorTransferencia, Conta contaDestino)
    {
      double saldoFinal = this.Saldo - valorTransferencia;
      bool resultado = saldoFinal >= 0;
      if (resultado) {
        contaDestino.DepositarDinheiro(valorTransferencia);
        this.Saldo -= valorTransferencia;
        Console.WriteLine($"Transferência de {valorTransferencia} feita com sucesso para {contaDestino.Nome}. Saldo atual: {this.Saldo}");
      } else if (this.Credito >= valorTransferencia) {
        this.Saldo -= valorTransferencia;
        Console.WriteLine($"Transferência de {valorTransferencia} usando crédito feita com sucesso para {contaDestino.Nome}. Saldo atual: {this.Saldo}");
      } else {
        Console.WriteLine("Não há saldo ou crédito disponível para a transferência.");
      }
    }

    public override string ToString()
    {
      return $"Tipo da conta: {this.TipoConta} | Nome do cliente: {this.Nome} | Saldo da conta: {this.Saldo} | Crédito da conta: {this.Credito}";
    }

  }
}