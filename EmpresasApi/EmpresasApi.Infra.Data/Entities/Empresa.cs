namespace EmpresasApi.Infra.Data.Entities
{
    /// <summary>
    /// Entidade de banco de dados: Empresa
    /// </summary>
    public class Empresa
    {
        public Guid IdEmpresa { get; set; }
        public string NomeFantasia { get; set; }
        public string RazaoSocial { get; set; }
        public string Cnpj { get; set; }
        public DateTime DataCadastro { get; set; }
        public DateTime DataUltimaAlteracao { get; set; }
    }
}





