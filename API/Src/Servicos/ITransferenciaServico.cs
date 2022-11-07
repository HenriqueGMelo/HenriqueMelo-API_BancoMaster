namespace API.Src.Servicos
{
    public interface ITransferenciaServico
    {
        string TransferenciaPix(string chavePixOrigem, string chavePixDestino, double saldo);

        string DepositarValorContaCliente(string chavePix, double valor);
    }
}
