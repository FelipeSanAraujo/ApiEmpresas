using EmpresasApi.Infra.Data.Contexts;
using EmpresasApi.Infra.Data.Entities;
using EmpresasApi.Infra.Data.Interfaces;

namespace EmpresasApi.Infra.Data.Repositories
{
    public class UsuarioRepository : BaseRepository<Usuario>, IUsuarioRepository
    {
        private readonly SqlServerContext _sqlServerContext;

        public UsuarioRepository(SqlServerContext sqlServerContext) : base(sqlServerContext)
        {
            _sqlServerContext = sqlServerContext;
        }

        public Usuario Obter(string login, string senha)
        {
            return _sqlServerContext.Usuario
                .Where(u => u.Login.Equals(login) && u.Senha.Equals(senha))
                .FirstOrDefault();
        }
    }
}
