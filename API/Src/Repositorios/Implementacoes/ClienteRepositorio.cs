using API.Src.Modelos;
using LiteDB;
using System;

namespace API.Src.Repositorios.Implementacoes
{
    public class ClienteRepositorio : IClienteRepositorio
    {
        string caminhoDoBancoDeDados = AppDomain.CurrentDomain.BaseDirectory + "database.db";

        public bool AtualizarCliente(ClienteModelo cliente)
        {
            using (var db = new LiteDatabase(caminhoDoBancoDeDados))
            {
                var clienteColecao = db.GetCollection<ClienteModelo>("clientes");
                return clienteColecao.Update(cliente);
            }
        }

        public bool CadastrarCliente(ClienteModelo cliente)
        {
            using (var db = new LiteDatabase(caminhoDoBancoDeDados))
            {
                var clienteColecao = db.GetCollection<ClienteModelo>("clientes");
                var resultado = clienteColecao.Insert(cliente);

                if (resultado != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        public ClienteModelo ConsultarClientePelaChavePix(string chavePix)
        {
            using (var db = new LiteDatabase(caminhoDoBancoDeDados))
            {
                var clienteColecao = db.GetCollection<ClienteModelo>("clientes");
                return clienteColecao.FindOne(x => x.ChavePix.Equals(chavePix));
            }
        }

        public ClienteModelo ConsultarClientePeloDocumento(long documento)
        {
            using (var db = new LiteDatabase(caminhoDoBancoDeDados))
            {
                var clienteColecao = db.GetCollection<ClienteModelo>("clientes");
                return clienteColecao.FindOne(x => x.Documento.Equals(documento));
            }
        }
    }
}