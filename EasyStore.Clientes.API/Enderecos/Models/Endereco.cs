using EasyStore.Clientes.API.Clientes.Models;
using Shared.Utils.Entidades;

namespace EasyStore.Clientes.API.Enderecos.Models
{
    public class Endereco : EntidadeBase
    {
        public virtual Cliente Cliente { get; protected set; }
        public virtual string Rua { get; protected set; }
        public virtual string Numero { get; protected set; }
        public virtual string Complemento { get; protected set; }
        public virtual string Bairro { get; protected set; }
        public virtual string CEP { get; protected set; }
        public virtual string Cidade { get; protected set; }
        public virtual string Estado { get; protected set; }
        public Endereco(Cliente cliente, string rua, string numero, string complemento, string bairro, string cEP, string cidade, string estado)
        {
            SetCliente(cliente);
            SetRua(rua);
            SetNumero(numero);
            SetComplemento(complemento);
            SetBairro(bairro);
            SetCep(cEP);
            SetCidade(cidade);
            SetEstado(estado);
        }

        protected Endereco(){}

        private void SetEstado(string estado)
        {
            Estado = estado;
        }

        private void SetCidade(string cidade)
        {
            Cidade = cidade;
        }

        private void SetCep(string cEP)
        {
            CEP = cEP;
        }

        private void SetBairro(string bairro)
        {
            Bairro = bairro;
        }

        private void SetComplemento(string complemento)
        {
            Complemento = complemento;
        }

        private void SetNumero(string numero)
        {
            Numero = numero;
        }

        private void SetRua(string rua)
        {
            Rua = rua;
        }

        private void SetCliente(Cliente cliente)
        {
            Cliente = cliente;
        }
    }
}