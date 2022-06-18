using EmpresasApi.Infra.Data.Contexts;
using EmpresasApi.Infra.Data.Entities;
using EmpresasApi.Infra.Data.Interfaces;

namespace EmpresasApi.Infra.Data.Repositories
{
    public class EmpresaRepository : BaseRepository<Empresa>, IEmpresaRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public EmpresaRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Empresa Obter(string cnpj)
        {
            return _sqlServerContext.Empresa
                .Where(e => e.Cnpj.Equals(cnpj))
                .FirstOrDefault();
        }
    }
}





