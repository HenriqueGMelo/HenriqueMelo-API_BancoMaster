using API.Src.Modelos;

namespace API.Src.Servicos
{
    public interface IClienteServico
    {
        ClienteModelo CadastrarCliente(ClienteModelo cliente, bool chavePixAleatoria);

        ClienteModelo ConsultarCliente(long documento);
    }
}
