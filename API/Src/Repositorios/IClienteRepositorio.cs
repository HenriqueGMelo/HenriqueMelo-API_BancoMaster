using API.Src.Modelos;

namespace API.Src.Repositorios
{
    public interface IClienteRepositorio
    {
        bool CadastrarCliente(ClienteModelo cliente);

        ClienteModelo ConsultarClientePeloDocumento(int documento);

        ClienteModelo ConsultarClientePelaChavePix(string chavePix);

        bool AtualizarCliente(ClienteModelo cliente);
    }
}
