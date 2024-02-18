using AutoMapper;
using EasyStore.Clientes.API.Clientes.Interfaces;
using EasyStore.Clientes.API.Clientes.Models;
using EasyStore.Clientes.API.Clientes.Response;
using MediatR;
using Shared.Utils.Transacoes.Interfaces;

namespace EasyStore.Clientes.API.Clientes.Commands.CriarCliente
{
    public class CriarClienteComandoHandler : IRequestHandler<ClienteComando, ClienteResponse>
    {
        private readonly IClientesServico clientesServico;
        private readonly IClientesRepositorio tarefasRepositorio;
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public CriarClienteComandoHandler(IClientesServico clientesServico, IClientesRepositorio tarefasRepositorio, IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.clientesServico = clientesServico;
            this.tarefasRepositorio = tarefasRepositorio;
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }

        public async Task<ClienteResponse> Handle(ClienteComando request, CancellationToken cancellationToken)
        {
            try
            {
                unitOfWork.BeginTransaction();
                Cliente cliente = await clientesServico.InserirAsync(request);
                unitOfWork.Commit();
                return mapper.Map<ClienteResponse>(cliente);
            }
            catch
            {
                unitOfWork.Rollback();
                throw;
            }
        }
    }
}