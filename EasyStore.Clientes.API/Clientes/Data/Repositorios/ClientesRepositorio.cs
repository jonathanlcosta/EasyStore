using EasyStore.Clientes.API.Clientes.Interfaces;
using EasyStore.Clientes.API.Clientes.Models;
using Shared.Utils.Repositorios;

namespace EasyStore.Clientes.API.Clientes.Data.Repositorios
{
    public class ClientesRepositorio : RepositorioNHibernate<Cliente>, IClientesRepositorio
    {
        public ClientesRepositorio(NHibernate.ISession session) : base(session)
        {
        }

        public Cliente RecuperarClientePorEmail(string email)
        {
           Cliente cliente = Query().Where(x => x.Email.Endereco == email).FirstOrDefault();
           return cliente;
        }
    }
}