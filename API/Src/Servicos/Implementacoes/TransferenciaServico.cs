using API.Src.Repositorios;
using System;

namespace API.Src.Servicos.Implementacoes
{
    public class TransferenciaServico : ITransferenciaServico
    {
        private readonly IClienteRepositorio _repositorio;

        public TransferenciaServico(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public string DepositarValorContaCliente(string chavePix, double valor)
        {
            var contaCliente = _repositorio.ConsultarClientePelaChavePix(chavePix);

            if (contaCliente != null)
            {
                contaCliente.Saldo += valor;

            }
            else
            {
                throw new Exception("Cliente não existe!");
            }
            _repositorio.AtualizarCliente(contaCliente);
            return "Deposito realizado com Sucesso!";
        }

        public string TransferenciaPix(string chavePixOrigem, string chavePixDestino, double saldo)
        {
            if (string.IsNullOrEmpty(chavePixOrigem) || string.IsNullOrEmpty(chavePixDestino) || saldo <= 0)
            {
                throw new Exception("Parametros invalidos");
            }
            var clienteOrigemTransferencia = _repositorio.ConsultarClientePelaChavePix(chavePixOrigem);
            var clienteDestinoTransferencia = _repositorio.ConsultarClientePelaChavePix(chavePixDestino);

            if (clienteOrigemTransferencia != null && clienteDestinoTransferencia != null)
            {
                if (clienteOrigemTransferencia.Saldo >= saldo)
                {
                    clienteOrigemTransferencia.Saldo -= saldo;
                    clienteDestinoTransferencia.Saldo += saldo;

                    if (_repositorio.AtualizarCliente(clienteOrigemTransferencia))
                    {
                        if (_repositorio.AtualizarCliente(clienteDestinoTransferencia))
                        {
                            return "Transferência Realizada com Sucesso!";
                        }
                        else
                        {
                            clienteOrigemTransferencia.Saldo += saldo;
                            _repositorio.AtualizarCliente(clienteOrigemTransferencia);
                        }
                    }
                    return ("Sucesso!");
                }
                else
                {
                    throw new Exception("Saldo Insuficiente");
                }     
            }
            else
            {
                throw new ArgumentNullException("Chave Pix Invalida!");
            }
        }
    }
}