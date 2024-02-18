using EasyStore.Clientes.API.Enderecos.Models;
using FluentNHibernate.Mapping;

namespace EasyStore.Clientes.API.Enderecos.Data.Mapeamentos
{
    public class EnderecosMap : ClassMap<Endereco>
    {
        public EnderecosMap()
        {
            Schema("clienteDb");
            Table("endereco");
            Id(x => x.Id, "id");
            Map(x => x.Rua, "rua");
            Map(x => x.Numero, "numero");
            Map(x => x.Complemento, "complemento");
            Map(x => x.Bairro, "bairro");
            Map(x => x.CEP, "cep");
            Map(x => x.Cidade, "cidade");
            Map(x => x.Estado, "estado");
            References(x => x.Cliente, "idcliente");
        }
    }
}