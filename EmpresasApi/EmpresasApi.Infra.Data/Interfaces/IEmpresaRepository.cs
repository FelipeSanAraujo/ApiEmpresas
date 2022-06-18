using EmpresasApi.Infra.Data.Entities;

namespace EmpresasApi.Infra.Data.Interfaces
{
    public interface IEmpresaRepository : IBaseRepository<Empresa>
    {
        Empresa Obter(string cnpj);
    }
}
