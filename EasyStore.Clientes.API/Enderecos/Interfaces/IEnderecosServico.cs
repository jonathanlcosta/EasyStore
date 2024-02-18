using EasyStore.Clientes.API.Clientes.Models;
using EasyStore.Clientes.API.Enderecos.Commands;
using EasyStore.Clientes.API.Enderecos.Models;

namespace EasyStore.Clientes.API.Enderecos.Interfaces
{
    public interface IEnderecosServico
    {
        Endereco Instanciar(Cliente cliente, EnderecoComando comando);
    }
}