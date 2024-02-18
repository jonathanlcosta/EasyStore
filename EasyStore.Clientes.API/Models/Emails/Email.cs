using System.Text.RegularExpressions;
using EasyStore.Clientes.API.Models.Clientes;
using EasyStore.Shared.Dominio.Utils.Excecoes;
using Shared.Utils.Entidades;

namespace EasyStore.Clientes.API.Models.Emails
{
    public class Email : EntidadeBase
    {
        public virtual Cliente Cliente { get; protected set; }
        public virtual string Endereco { get; protected set; }
        public Email(string endereco, Cliente cliente)
        {
            SetEndereco(endereco);
            SetCliente(cliente);
        }

        public Email(){}

        public virtual void SetEndereco(string endereco)
        {
            var regexEmail = new Regex(@"^(?("")("".+?""@)|(([0-9a-zA-Z]((\.(?!\.))|[-!#\$%&'\*\+/=\?\^`\{\}\|~\w])*)(?<=[0-9a-zA-Z])@))(?(\[)(\[(\d{1,3}\.){3}\d{1,3}\])|(([0-9a-zA-Z][-\w]*[0-9a-zA-Z]\.)+[a-zA-Z]{2,6}))$");
            var emailValido = regexEmail.IsMatch(endereco);
            if(!emailValido) throw new RegraDeNegocioExcecao("Email inválido");

            if(endereco.Length <= 5) throw new TamanhoDeAtributoInvalidoExcecao("Endereço", 5, 254);

            Endereco = endereco;
        }

        public virtual void SetCliente(Cliente cliente)
        {
            if(cliente is null) throw new AtributoObrigatorioExcecao("Cliente");
            Cliente = cliente;
        }
        
    }
}