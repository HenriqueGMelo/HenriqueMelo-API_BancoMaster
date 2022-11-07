using API.Src.Modelos;
using API.Src.Repositorios;
using System;

namespace API.Src.Servicos.Implementacoes
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;

        public ClienteServico(IClienteRepositorio repositorio)
        {
            _repositorio = repositorio;
        }

        public ClienteModelo CadastrarCliente(ClienteModelo cliente, bool chavePixAleatoria)
        {
            ClienteModelo clienteRetorno = null;

            if (cliente.Documento > 0)
            {
                if (cliente.Nome == null || string.IsNullOrEmpty(cliente.Nome))
                {
                    throw new Exception("Informe o Nome para cadastro!");
                }
                if (chavePixAleatoria && string.IsNullOrEmpty(cliente.ChavePix))
                {
                    cliente.ChavePix = Guid.NewGuid().ToString();
                }
                var chaveUtilizada = _repositorio.ConsultarClientePelaChavePix(cliente.ChavePix);

                if (!string.IsNullOrEmpty(cliente.ChavePix) && chaveUtilizada == null)
                {
                    var clienteExiste = _repositorio.ConsultarClientePeloDocumento(cliente.Documento);

                    if (clienteExiste == null)
                    {
                        var clienteCadastrado = _repositorio.CadastrarCliente(cliente);

                        if (clienteCadastrado)
                        {
                            clienteRetorno = _repositorio.ConsultarClientePeloDocumento(cliente.Documento);
                        }
                    }
                    else throw new Exception("Cliente já cadastrado");
                }
                else
                {
                    throw new Exception("Chave pix já utilizada ou não informada / Observação: chave pix aleatoria não foi solicitada!");
                }
            }
            else
            {
                throw new Exception("Documento não pode ser 0");
            }
            return clienteRetorno;
        }

        public ClienteModelo ConsultarCliente(int documento)
        {
            var cliente = _repositorio.ConsultarClientePeloDocumento(documento);

            if (cliente == null)
            {
                throw new Exception("Cliente não encontrado!");
            }
            return cliente;
        }
    }
}