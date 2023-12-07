using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebAPI_Atend_FAQ.DataContext;
using WebAPI_Atend_FAQ.Models;
using WebAPI_Atend_FAQ.Service.SolicitacaoService;
using WebAPI_Atend_FAQ.Service.UsuarioService;

namespace WebAPI_Atend_FAQ.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SolicitacaoController : ControllerBase
    {
        private readonly ISolicitacaoInterface _solicitacaoInterface;
        private readonly ApplicationDbContext _usuarioBd;
        public SolicitacaoController(ISolicitacaoInterface solicitacaoInterface, ApplicationDbContext usuarioBd) {

            _solicitacaoInterface = solicitacaoInterface;
            _usuarioBd = usuarioBd;

        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<SolicitacaoModel>>>> GetSolicitacao()
        {
            return Ok(await _solicitacaoInterface.GetSolicitacao());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<SolicitacaoModel>>> GetSolicitacaoById(int id)
        {
            return Ok(await _solicitacaoInterface.GetSolicitacaoById(id)); 
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<SolicitacaoModel>>>> CreateSolicitacao(SolicitacaoModel solicitacao)
        {
            return Ok(await _solicitacaoInterface.CreateSolicitacao(solicitacao));
        }

        [HttpPut("finalizaSolicitacao")]
        public async Task<ActionResult<ServiceResponse<List<SolicitacaoModel>>>> FinalizaSolicitacao(int id, string userName)
        {
            
            return Ok(await _solicitacaoInterface.FinalizaSolicitacao(id, userName));
        }

        [HttpPut("respostaSolicitacao")]
        public async Task<ActionResult<ServiceResponse<List<SolicitacaoModel>>>> RespostaSolicitacao(SolicitacaoModel editandoSolicitacao, string ?userName)
        {
            
            return Ok(await _solicitacaoInterface.UpdateSolicitacao(editandoSolicitacao, userName));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<SolicitacaoModel>>>> DeletarFuncionario(int Id)
        {
            return Ok(await _solicitacaoInterface.DeleteSolicitacao(Id));
        }

    }
}
