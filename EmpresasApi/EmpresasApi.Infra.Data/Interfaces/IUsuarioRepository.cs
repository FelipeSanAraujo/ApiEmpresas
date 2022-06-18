using EmpresasApi.Infra.Data.Entities;

namespace EmpresasApi.Infra.Data.Interfaces
{
    public interface IUsuarioRepository : IBaseRepository<Usuario>
    {
        Usuario Obter(string login, string senha);
    }
}
