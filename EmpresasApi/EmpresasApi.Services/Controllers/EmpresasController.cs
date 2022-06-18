using EmpresasApi.Infra.Data.Entities;
using EmpresasApi.Infra.Data.Interfaces;
using EmpresasApi.Services.Requests;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace EmpresasApi.Services.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class EmpresasController : ControllerBase
    {
        private readonly IEmpresaRepository _empresaRepository;

        public EmpresasController(IEmpresaRepository empresaRepository)
        {
            _empresaRepository = empresaRepository;
        }

        [HttpPost]
        public IActionResult Post(EmpresaPostRequest request)
        {
            try
            {
                var empresa = new Empresa()
                {
                    IdEmpresa = Guid.NewGuid(),
                    NomeFantasia = request.NomeFantasia,
                    RazaoSocial = request.RazaoSocial,
                    Cnpj = request.Cnpj,
                    DataCadastro = DateTime.Now,
                    DataUltimaAlteracao = DateTime.Now
                };

                _empresaRepository.Inserir(empresa);

                return StatusCode(201, new { mensagem = "Empresa cadastrada com sucesso", empresa });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(EmpresaPutRequest request)
        {
            try
            {
                var empresa = _empresaRepository.ObterPorId(request.IdEmpresa);

                if (empresa == null)
                    return StatusCode(422, new { mensagem = "Empresa inválida para edição." });

                empresa.NomeFantasia = request.NomeFantasia;
                empresa.RazaoSocial = request.RazaoSocial;
                empresa.Cnpj = request.Cnpj;
                empresa.DataUltimaAlteracao = DateTime.Now;

                _empresaRepository.Alterar(empresa);

                return StatusCode(200, new { mensagem = "Empresa atualizada com sucesso", empresa });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpDelete("{idEmpresa}")]
        public IActionResult Delete(Guid idEmpresa)
        {
            try
            {
                var empresa = _empresaRepository.ObterPorId(idEmpresa);

                if (empresa == null)
                    return StatusCode(422, new { mensagem = "Empresa inválida para edição." });

                _empresaRepository.Excluir(empresa);

                return StatusCode(200, new { mensagem = "Empresa excluída com sucesso", empresa });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var empresas = _empresaRepository.Consultar();
                return StatusCode(200, empresas);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet("{idEmpresa}")]
        public IActionResult GetById(Guid idEmpresa)
        {
            try
            {
                var empresa = _empresaRepository.ObterPorId(idEmpresa);
                return StatusCode(200, empresa);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }
    }
}



