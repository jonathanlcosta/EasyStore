using EasyStore.Clientes.API.Clientes.Models;
using EasyStore.Clientes.API.Enderecos.Commands;
using EasyStore.Clientes.API.Enderecos.Interfaces;
using EasyStore.Clientes.API.Enderecos.Models;

namespace EasyStore.Clientes.API.Enderecos.Services
{
    public class EnderecosServico : IEnderecosServico
    {
        public Endereco Instanciar(Cliente cliente, EnderecoComando comando)
        {
            return new(cliente, comando.Rua, comando.Numero, comando.Complemento, comando.Bairro, comando.CEP, comando.Cidade, comando.Estado);
        }
    }
}