using WebAPI_Atend_FAQ.Models;

namespace WebAPI_Atend_FAQ.Service.DuvidasService
{
    public interface IDuvidasInterface
    {

        Task<ServiceResponse<List<DuvidasModel>>> GetDuvidas();
        Task<ServiceResponse<List<DuvidasModel>>> CreateDuvidas(DuvidasModel novaDuvida);
        Task<ServiceResponse<DuvidasModel>> GetDuvidaById(int Id);
        Task<ServiceResponse<List<DuvidasModel>>> UpadateDuvida(DuvidasModel editandoDuvida);
        Task<ServiceResponse<List<DuvidasModel>>> DeteleDuvida(int Id);
        Task<ServiceResponse<List<DuvidasModel>>> DesativaDuvida(int Id);

    }
}
