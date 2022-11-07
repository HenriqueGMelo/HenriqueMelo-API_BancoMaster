using API.Src.Modelos;

namespace API.Src.Repositorios
{
    public interface IClienteRepositorio
    {
        bool CadastrarCliente(ClienteModelo cliente);

        ClienteModelo ConsultarClientePeloDocumento(long documento);

        ClienteModelo ConsultarClientePelaChavePix(string chavePix);

        bool AtualizarCliente(ClienteModelo cliente);
    }
}
