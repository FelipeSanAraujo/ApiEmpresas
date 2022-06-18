using EmpresasApi.Infra.Data.Contexts;
using EmpresasApi.Infra.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace EmpresasApi.Infra.Data.Repositories
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity>
        where TEntity : class
    {
        private readonly SqlServerContext _sqlServerContext;

        public BaseRepository(SqlServerContext sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public void Inserir(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Added;
            _sqlServerContext.SaveChanges();
        }

        public void Alterar(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Modified;
            _sqlServerContext.SaveChanges();
        }

        public void Excluir(TEntity entity)
        {
            _sqlServerContext.Entry(entity).State = EntityState.Deleted;
            _sqlServerContext.SaveChanges();
        }

        public List<TEntity> Consultar()
        {
            return _sqlServerContext.Set<TEntity>().ToList();
        }

        public TEntity ObterPorId(Guid id)
        {
            return _sqlServerContext.Set<TEntity>().Find(id);
        }
    }
}



