using EasyStore.Clientes.API.Clientes.Models;
using EasyStore.Clientes.API.Emails.Commands;
using EasyStore.Clientes.API.Emails.Interfaces;
using EasyStore.Clientes.API.Models.Emails;

namespace EasyStore.Clientes.API.Emails.Services
{
    public class EmailsServico : IEmailsServico
    {
        public Email Instanciar(Cliente cliente, EmailComando comando)
        {
            return new(comando.Endereco, cliente);
        }
    }
}