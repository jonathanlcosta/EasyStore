using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using EasyStore.Clientes.API.Clientes.Models;

namespace EasyStore.Clientes.API.Clientes.Interfaces
{
    public interface IClientesRepositorio : IRepositorioNHibernate<Cliente>
    {
        Cliente RecuperarClientePorEmail(string email);
    }
}