using Microsoft.EntityFrameworkCore;
using WebAPI_Atend_FAQ.DataContext;
using WebAPI_Atend_FAQ.Models;

namespace WebAPI_Atend_FAQ.Service.SolicitacaoService
{

    public class SolicitacaoService : ISolicitacaoInterface
    {

        private readonly ApplicationDbContext _context;

        public SolicitacaoService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<SolicitacaoModel>>> CreateSolicitacao(SolicitacaoModel solicitacao)
        {
            ServiceResponse<List<SolicitacaoModel>> serviceResponse = new ServiceResponse<List<SolicitacaoModel>>();

            try
            {

                if (solicitacao == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                solicitacao.DataFinalizacao = null;
                solicitacao.StatusAndamentoOuFinalizado = null;
                _context.Add(solicitacao);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.Solicitacaos.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<SolicitacaoModel>>> DeleteSolicitacao(int Id)
        {
            ServiceResponse<List<SolicitacaoModel>> serviceResponse = new ServiceResponse<List<SolicitacaoModel>>();

            try
            {
                SolicitacaoModel solicitacao = _context.Solicitacaos.FirstOrDefault(x => x.Id == Id);


                if (solicitacao == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Solicitação não encontrada!";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }


                _context.Solicitacaos.Remove(solicitacao);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Solicitacaos.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SolicitacaoModel>>> FinalizaSolicitacao(int Id, string nome)
        {
            ServiceResponse<List<SolicitacaoModel>> serviceResponse = new ServiceResponse<List<SolicitacaoModel>>();

            try
            {
                SolicitacaoModel solicitacao = _context.Solicitacaos.FirstOrDefault(x => x.Id == Id);

                if (solicitacao == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Solicitaçao não localizada";
                    serviceResponse.Sucesso = false;
                }

                solicitacao.ResponsavelFinalizador = nome;
                solicitacao.StatusAndamentoOuFinalizado = true;
                solicitacao.DataFinalizacao = DateTime.Now.ToLocalTime();

                _context.Solicitacaos.Update(solicitacao);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Solicitacaos.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SolicitacaoModel>>> GetSolicitacao()
        {
            ServiceResponse<List<SolicitacaoModel>> serviceResponse = new ServiceResponse<List<SolicitacaoModel>>();

            try
            {
                serviceResponse.Dados = _context.Solicitacaos.ToList();
                if (serviceResponse.Dados.Count == 0)
                {
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                }


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<SolicitacaoModel>> GetSolicitacaoById(int Id)
        {
            ServiceResponse<SolicitacaoModel> serviceResponse = new ServiceResponse<SolicitacaoModel>();

            try
            {
                SolicitacaoModel solicitacao = _context.Solicitacaos.FirstOrDefault(x => x.Id == Id);

                if (solicitacao == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = solicitacao;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<SolicitacaoModel>>> UpdateSolicitacao(SolicitacaoModel editandoSolicitacao, string nome)
        {
            ServiceResponse<List<SolicitacaoModel>> serviceResponse = new ServiceResponse<List<SolicitacaoModel>>();

            try
            {
                SolicitacaoModel solicitacao = _context.Solicitacaos.AsNoTracking().FirstOrDefault(x => x.Id == editandoSolicitacao.Id);

                if (solicitacao == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                    serviceResponse.Sucesso = false;
                }


                solicitacao.ResponsavelAtendimento = nome;
                solicitacao.DataResposta = DateTime.Now.ToLocalTime();


                _context.Solicitacaos.Update(editandoSolicitacao);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.Solicitacaos.ToList();

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }
    }
}
