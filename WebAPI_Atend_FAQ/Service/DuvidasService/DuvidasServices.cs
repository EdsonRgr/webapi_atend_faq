using Microsoft.EntityFrameworkCore;
using WebAPI_Atend_FAQ.DataContext;
using WebAPI_Atend_FAQ.Models;

namespace WebAPI_Atend_FAQ.Service.DuvidasService
{
    public class DuvidasServices : IDuvidasInterface
    {

        private readonly ApplicationDbContext _context;

        public DuvidasServices(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<ServiceResponse<List<DuvidasModel>>> CreateDuvidas(DuvidasModel novaDuvida)
        {
            ServiceResponse<List<DuvidasModel>> serviceResponse = new ServiceResponse<List<DuvidasModel>>();

            try
            {

                if (novaDuvida == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Informar Dados";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }

                _context.Add(novaDuvida);
                await _context.SaveChangesAsync();


                serviceResponse.Dados = _context.FaqDuvidas.ToList();



            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DuvidasModel>>> DesativaDuvida(int Id)
        {

            ServiceResponse<List<DuvidasModel>> serviceResponse = new ServiceResponse<List<DuvidasModel>>();

            try
            {
                DuvidasModel duvida = _context.FaqDuvidas.FirstOrDefault(x => x.Id == Id);

                if (duvida == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Duvida não localizada";
                    serviceResponse.Sucesso = false;
                }


                if (duvida.Ativo == false)
                {
                    duvida.Ativo = true;
                }else
                {
                    duvida.Ativo = false;
                }
                

                duvida.DataAlteracao = DateTime.Now.ToLocalTime();

                _context.FaqDuvidas.Update(duvida);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.FaqDuvidas.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;

        }

        public async Task<ServiceResponse<List<DuvidasModel>>> DeteleDuvida(int Id)
        {
            ServiceResponse<List<DuvidasModel>> serviceResponse = new ServiceResponse<List<DuvidasModel>>();

            try
            {
                DuvidasModel duvida = _context.FaqDuvidas.FirstOrDefault(x => x.Id == Id);


                if (duvida == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Solicitação não encontrada";
                    serviceResponse.Sucesso = false;
                    return serviceResponse;
                }


                _context.FaqDuvidas.Remove(duvida);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.FaqDuvidas.ToList();


            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<DuvidasModel>> GetDuvidaById(int Id)
        {
            ServiceResponse<DuvidasModel> serviceResponse = new ServiceResponse<DuvidasModel>();

            try
            {
                DuvidasModel duvida = _context.FaqDuvidas.FirstOrDefault(x => x.Id == Id);

                if (duvida == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                    serviceResponse.Sucesso = false;
                }

                serviceResponse.Dados = duvida;

            }
            catch (Exception ex)
            {
                serviceResponse.Mensagem = ex.Message;
                serviceResponse.Sucesso = false;
            }

            return serviceResponse;
        }

        public async Task<ServiceResponse<List<DuvidasModel>>> GetDuvidas()
        {
            ServiceResponse<List<DuvidasModel>> serviceResponse = new ServiceResponse<List<DuvidasModel>>();

            try
            {
                serviceResponse.Dados = _context.FaqDuvidas.ToList();
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

        public async Task<ServiceResponse<List<DuvidasModel>>> UpadateDuvida(DuvidasModel editandoDuvida)
        {
            ServiceResponse<List<DuvidasModel>> serviceResponse = new ServiceResponse<List<DuvidasModel>>();

            try
            {
                DuvidasModel duvida = _context.FaqDuvidas.AsNoTracking().FirstOrDefault(x => x.Id == editandoDuvida.Id);

                if (duvida == null)
                {
                    serviceResponse.Dados = null;
                    serviceResponse.Mensagem = "Nenhum dado encontrado!";
                    serviceResponse.Sucesso = false;
                }


                duvida.DataAlteracao = DateTime.Now.ToLocalTime();


                _context.FaqDuvidas.Update(editandoDuvida);
                await _context.SaveChangesAsync();

                serviceResponse.Dados = _context.FaqDuvidas.ToList();

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
