using System.ComponentModel.DataAnnotations;
using WebAPI_Atend_FAQ.Enums;

namespace WebAPI_Atend_FAQ.Models
{
    public class SolicitacaoModel
    {
        [Key]
        public int Id{ get; set; }
        public String Categoria { get; set; }
        public String Assunto { get; set; }
        public String Descricao { get; set; }
        public String? Resposta { get; set; }
        public String? ResponsavelAtendimento { get; set; }
        public String SolicitanteAtendimento { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime? DataResposta { get; set; }
        public DateTime? DataFinalizacao { get; set; }
        public String? Prioridade { get; set; }
        public bool? StatusAndamentoOuFinalizado { get; set; }
        public String? ResponsavelFinalizador { get; set; }

    }
}
