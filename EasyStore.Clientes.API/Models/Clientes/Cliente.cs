using EasyStore.Clientes.API.Models.Emails;
using EasyStore.Shared.Utils.Enumeradores;
using Shared.Utils.Entidades;

namespace EasyStore.Clientes.API.Models.Clientes
{
    public class Cliente : EntidadeBase
    {
        public Email Email { get; set; }
        public string Celular { get; set; }
        public AtivoInativoEnum Ativo { get; set; }
        public string Endereco { get; set; }
    }
}