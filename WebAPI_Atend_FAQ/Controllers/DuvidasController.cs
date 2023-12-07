using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebAPI_Atend_FAQ.Models;
using WebAPI_Atend_FAQ.Service.DuvidasService;
using WebAPI_Atend_FAQ.Service.SolicitacaoService;

namespace WebAPI_Atend_FAQ.Controllers
{
    
    [Route("api/[controller]")]
    [ApiController]
    public class DuvidasController : ControllerBase
    {
        private readonly IDuvidasInterface _duvidasInterface;
        public DuvidasController(IDuvidasInterface duvidasInterface)
        {

            _duvidasInterface = duvidasInterface;

        }


        [HttpGet]
        public async Task<ActionResult<ServiceResponse<List<DuvidasModel>>>> GetDuvidas()
        {
            return Ok(await _duvidasInterface.GetDuvidas());
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ServiceResponse<List<DuvidasModel>>>> GetDuvidasById(int id)
        {
            return Ok(await _duvidasInterface.GetDuvidaById(id));
        }


        [HttpPost]
        public async Task<ActionResult<ServiceResponse<List<DuvidasModel>>>> CreateSolicitacao(DuvidasModel duvidaFaq)
        {
            return Ok(await _duvidasInterface.CreateDuvidas(duvidaFaq));
        }

        [HttpPut("desativaDuvida")]
        public async Task<ActionResult<ServiceResponse<List<SolicitacaoModel>>>> DesativaDuvida(int id)
        {
            return Ok(await _duvidasInterface.DesativaDuvida(id));
        }

        [HttpPut()]
        public async Task<ActionResult<ServiceResponse<List<SolicitacaoModel>>>> UpadateDuvida(DuvidasModel editandoDuvida)
        {
            return Ok(await _duvidasInterface.UpadateDuvida(editandoDuvida));
        }

        [HttpDelete]
        public async Task<ActionResult<ServiceResponse<List<SolicitacaoModel>>>> DeleteDuvida(int id)
        {
            return Ok(await _duvidasInterface.DeteleDuvida(id));
        }

    }
}
