using EasyStore.Clientes.API.Clientes.Response;
using EasyStore.Clientes.API.Emails.Commands;
using EasyStore.Clientes.API.Enderecos.Commands;
using MediatR;

namespace EasyStore.Clientes.API.Clientes.Commands
{
    public class ClienteComando : IRequest<ClienteResponse>
    {
        public string Nome { get; set; }
        public virtual EmailComando Email { get; set; }
        public virtual string Celular { get; set; }
        public virtual EnderecoComando Endereco { get; set; }
    }
}