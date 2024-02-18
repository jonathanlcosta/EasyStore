using EasyStore.Clientes.API.Models.Emails;
using FluentNHibernate.Mapping;

namespace EasyStore.Clientes.API.Emails.Data.Mapeamentos
{
    public class EmailsMap : ClassMap<Email>
    {
        public EmailsMap()
        {
            Schema("clienteDb");
            Table("email");
            Id(x => x.Id, "id");
            Map(x => x.Endereco, "endereco");
            References(x => x.Cliente, "idcliente");
        }
    }
}