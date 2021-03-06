using System.ComponentModel.DataAnnotations;

namespace EmpresasApi.Services.Requests
{
    public class EmpresaPutRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id da empresa.")]
        public Guid IdEmpresa { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome fantasia da empresa.")]
        public string NomeFantasia { get; set; }

        [Required(ErrorMessage = "Por favor, informe a razão social da empresa.")]
        public string RazaoSocial { get; set; }

        [Required(ErrorMessage = "Por favor, informe o cnpj da empresa.")]
        public string Cnpj { get; set; }
    }
}



