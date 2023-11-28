using WebAPI_Atend_FAQ.Models;

namespace WebAPI_Atend_FAQ.Service.SolicitacaoService
{
    public interface ISolicitacaoInterface
    {
        Task<ServiceResponse<List<SolicitacaoModel>>> GetSolicitacao();
        Task<ServiceResponse<List<SolicitacaoModel>>> CreateSolicitacao(SolicitacaoModel solicitacao);
        Task<ServiceResponse<SolicitacaoModel>> GetSolicitacaoById(int Id);
        Task<ServiceResponse<List<SolicitacaoModel>>> UpdateSolicitacao(SolicitacaoModel solicitacao, string nome);
        Task<ServiceResponse<List<SolicitacaoModel>>> DeleteSolicitacao(int Id);
        Task<ServiceResponse<List<SolicitacaoModel>>> FinalizaSolicitacao(int Id, string nome );
    }
}
