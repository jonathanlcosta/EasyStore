using EasyStore.Shared.Utils.Consultas;
using EasyStore.Shared.Utils.Filtros.Enumeradores;

namespace Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces
{
    public interface IRepositorioNHibernate<T> where T : class
    {
        void Inserir(T entidade);
        void Editar(T entidade);
        void Excluir(T entidade);
        T Recuperar(int id);
        IQueryable<T> Query();
        PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd);
        Task<T> RecuperarAsync(int id);
        Task<T> InserirAsync(T entidade);
        Task<T> EditarAsync(T entidade);
        Task ExcluirAsync(T entidade);
        Task<IQueryable<T>> QueryAsync();
        
    }
}