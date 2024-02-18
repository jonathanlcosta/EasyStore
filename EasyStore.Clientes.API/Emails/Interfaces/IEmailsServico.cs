using EasyStore.Clientes.API.Clientes.Models;
using EasyStore.Clientes.API.Emails.Commands;
using EasyStore.Clientes.API.Models.Emails;

namespace EasyStore.Clientes.API.Emails.Interfaces
{
    public interface IEmailsServico
    {
        Email Instanciar(Cliente cliente, EmailComando comando);
    }
}