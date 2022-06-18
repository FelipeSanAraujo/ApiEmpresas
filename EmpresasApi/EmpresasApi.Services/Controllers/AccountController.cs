using EmpresasApi.Infra.Data.Entities;
using EmpresasApi.Infra.Data.Interfaces;
using EmpresasApi.Infra.Data.Utils;
using EmpresasApi.Services.Requests;
using Microsoft.AspNetCore.Mvc;

namespace EmpresasApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public AccountController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        [HttpPost]
        public IActionResult Post(AccountPostRequest request)
        {
            try
            {
                var criptografia = new Criptografia();

                var usuario = new Usuario()
                {
                    IdUsuario = Guid.NewGuid(),
                    Nome = request.Nome,
                    Login = request.Login,
                    Senha = criptografia.GetMD5(request.Senha)
                };

                _usuarioRepository.Inserir(usuario);

                return StatusCode(201, new { mensagem = $"Parabéns {usuario.Nome}, sua conta foi criada com sucesso." });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}



