namespace EmpresasApi.Infra.Data.Entities
{
    /// <summary>
    /// Entidade de banco de dados: Usuario
    /// </summary>
    public class Usuario
    {
        public Guid IdUsuario { get; set; }
        public string Nome { get; set; }
        public string Login { get; set; }
        public string Senha { get; set; }
    }
}



