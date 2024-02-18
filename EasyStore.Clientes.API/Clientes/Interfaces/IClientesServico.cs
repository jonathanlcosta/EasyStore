using EasyStore.Clientes.API.Clientes.Commands;
using EasyStore.Clientes.API.Clientes.Models;

namespace EasyStore.Clientes.API.Clientes.Interfaces
{
    public interface IClientesServico
    {
        Task<Cliente> InserirAsync(ClienteComando comando);
        Task<Cliente> ValidarAsync(int id);
        Cliente Instanciar(ClienteComando comando);
    }
}