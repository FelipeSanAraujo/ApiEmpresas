using EmpresasApi.Infra.Data.Interfaces;
using EmpresasApi.Infra.Data.Utils;
using EmpresasApi.Services.Requests;
using EmpresasApi.Services.Security;
using Microsoft.AspNetCore.Mvc;

namespace EmpresasApi.Services.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly TokenCreator _tokenCreator;

        public LoginController(IUsuarioRepository usuarioRepository, TokenCreator tokenCreator)
        {
            _usuarioRepository = usuarioRepository;
            _tokenCreator = tokenCreator;
        }

        [HttpPost]
        public IActionResult Post(LoginPostRequest request)
        {
            try
            {
                var criptografia = new Criptografia();

                var usuario = _usuarioRepository.Obter(request.Login, criptografia.GetMD5(request.Senha));

                if (usuario != null)
                {
                    return StatusCode(200,
                        new
                        {
                            mensagem = "Usuário autenticado com sucesso!",
                            accessToken = _tokenCreator.GenerateToken(usuario.Login)
                        });
                }
                else
                {
                    return StatusCode(400, new { mensagem = "Acesso negado, login ou senha inválidos." });
                }
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}





