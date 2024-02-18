using EasyStore.Clientes.API.Clientes.Models;
using EasyStore.Shared.Utils.Enumeradores;
using FluentNHibernate.Mapping;

namespace EasyStore.Clientes.API.Clientes.Data.Mapeamentos
{
    public class ClientesMap : ClassMap<Cliente>
    {
        public ClientesMap()
        {
            Schema("clienteDb");
            Table("cliente");
            Id(x => x.Id, "id");
            Map(x => x.Nome, "nome");
            Map(x => x.Celular, "celular");
            Map(x => x.Ativo, "ativo").CustomType<AtivoInativoEnum>();
            HasOne(x => x.Endereco).PropertyRef(x => x.Cliente).Cascade.DeleteOrphan();
            HasOne(x => x.Email).PropertyRef(x => x.Cliente).Cascade.DeleteOrphan();
        }
    }
}