using EasyStore.Clientes.API.Clientes.Commands;
using EasyStore.Clientes.API.Clientes.Interfaces;
using EasyStore.Clientes.API.Clientes.Models;
using EasyStore.Clientes.API.Emails.Interfaces;
using EasyStore.Clientes.API.Enderecos.Interfaces;
using EasyStore.Clientes.API.Enderecos.Models;
using EasyStore.Clientes.API.Models.Emails;
using EasyStore.Shared.Dominio.Utils.Excecoes;

namespace EasyStore.Clientes.API.Clientes.Services
{
    public class ClientesServico : IClientesServico
    {
        private readonly IClientesRepositorio clientesRepositorio;
        private readonly IEmailsServico emailsServico;
        private readonly IEnderecosServico enderecosServico;

        public ClientesServico(IClientesRepositorio clientesRepositorio, IEmailsServico emailsServico, IEnderecosServico enderecosServico)
        {
            this.clientesRepositorio = clientesRepositorio;
            this.emailsServico = emailsServico;
            this.enderecosServico = enderecosServico;
        }

        public async Task<Cliente> InserirAsync(ClienteComando comando)
        {
            Cliente cliente = Instanciar(comando);
            Endereco endereco = enderecosServico.Instanciar(cliente, comando.Endereco);
            Email email = emailsServico.Instanciar(cliente, comando.Email);
            cliente.SetEmail(email);
            cliente.SetEndereco(endereco);
            await clientesRepositorio.InserirAsync(cliente);
            return cliente;

        }

        public Cliente Instanciar(ClienteComando comando)
        {
            return new(comando.Nome, comando.Celular);
        }

        public async Task<Cliente> ValidarAsync(int id)
        {
            Cliente cliente = await clientesRepositorio.RecuperarAsync(id);

            if (cliente is null) throw new RegraDeNegocioExcecao("Cliente não foi encontrado");

            return cliente;
        }
    }
}