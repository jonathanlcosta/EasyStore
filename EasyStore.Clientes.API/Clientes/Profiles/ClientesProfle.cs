using AutoMapper;
using EasyStore.Clientes.API.Clientes.Models;
using EasyStore.Clientes.API.Clientes.Response;

namespace EasyStore.Clientes.API.Clientes.Profiles
{
    public class ClientesProfle : Profile
    {
        public ClientesProfle()
        {
            CreateMap<Cliente, ClienteResponse>();
        }
    }
}