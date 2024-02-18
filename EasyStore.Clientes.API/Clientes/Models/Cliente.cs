using EasyStore.Clientes.API.Enderecos.Models;
using EasyStore.Clientes.API.Models.Emails;
using EasyStore.Shared.Dominio.Utils.Excecoes;
using EasyStore.Shared.Utils.Enumeradores;
using Shared.Utils.Entidades;

namespace EasyStore.Clientes.API.Clientes.Models
{
    public class Cliente : EntidadeBase
    {
        public virtual string Nome { get; protected set; }
        public virtual Email Email { get; protected set; }
        public virtual string Celular { get; protected set; }
        public virtual AtivoInativoEnum Ativo { get; protected set; }
        public virtual Endereco Endereco { get; protected set; }
        public Cliente(string nome, string celular)
        {
            SetNome(nome);
            SetAtivo(AtivoInativoEnum.Ativo);
            SetCelular(celular);
        }

        public Cliente(){}

        public virtual void SetEmail(Email email)
        {
            if(email is null) throw new AtributoObrigatorioExcecao("Email");

            Email = email;
        }

        public virtual void SetCelular(string celular)
        {
            if(string.IsNullOrWhiteSpace(celular)) throw new AtributoObrigatorioExcecao("Celular");

            Celular = celular;
        }

        public virtual void SetNome(string nome)
        {
            if(string.IsNullOrWhiteSpace(nome)) throw new AtributoObrigatorioExcecao("Nome");

            Nome = nome;
        }

        public virtual void SetAtivo(AtivoInativoEnum ativo)
        {
            Ativo = ativo;
        }

        public virtual void SetEndereco(Endereco endereco)
        {
            if(endereco is null) throw new AtributoObrigatorioExcecao("Endereço");

            Endereco = endereco;
        }
    }
}