using Autoglass.Autoplay.Dominio.Utils.Repositorios.Interfaces;
using EasyStore.Shared.Utils.Consultas;
using EasyStore.Shared.Utils.Filtros.Enumeradores;
using NHibernate;
using System.Linq.Dynamic.Core;
using System.Linq.Dynamic.Core.Exceptions;
using EasyStore.Shared.Dominio.Utils.Excecoes;
using NHibernate.Linq;

namespace Shared.Utils.Repositorios
{
    public class RepositorioNHibernate<T> : IRepositorioNHibernate<T> where T : class
    {
        protected readonly ISession session;

        public RepositorioNHibernate(ISession session)
        {
            this.session = session;
        }

        public void Editar(T entidade)
        {
            session.Update(entidade);
        }

        public void Excluir(T entidade)
        {
            session.Delete(entidade);
        }

        public void Inserir(T entidade)
        {
            session.Save(entidade);
        }

        public IQueryable<T> Query()
        {
            return session.Query<T>();
        }

        public PaginacaoConsulta<T> Listar(IQueryable<T> query, int qt, int pg, string cpOrd, TipoOrdenacaoEnum tpOrd)
        {
            try
            {
                query = query.OrderBy(cpOrd + " " + tpOrd.ToString());
                return Paginar(query, qt, pg);
            }
            catch (ParseException)
            {
                throw new RegraDeNegocioExcecao("Deu erro no tipo de ordenação");
            }
        }

        public T Recuperar(int id)
        {
            return session.Get<T>(id);
        }

        private static PaginacaoConsulta<T> Paginar(IQueryable<T> query, int qt, int pg)
        {
            return new PaginacaoConsulta<T>
            {
                Registros = query.Skip((pg - 1) * qt).Take(qt).ToList(),
                Total = query.LongCount(),
            };
        }

        public async Task<T> RecuperarAsync(int id)
        {
            return await session.GetAsync<T>(id);
        }

        public async Task<T> InserirAsync(T entidade)
        {
            await session.SaveAsync(entidade);
            return entidade;
        }

        public async Task<T> EditarAsync(T entidade)
        {
            await session.UpdateAsync(entidade);
            return entidade;
        }

        public async Task ExcluirAsync(T entidade)
        {
            await session.DeleteAsync(entidade);
        }

        public async Task<IQueryable<T>> QueryAsync()
        {
            List<T> resultado = await session.Query<T>().ToListAsync();
            return resultado.AsQueryable();
        }

    }
}