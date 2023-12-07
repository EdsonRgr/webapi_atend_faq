using System.ComponentModel.DataAnnotations;
using WebAPI_Atend_FAQ.Enums;

namespace WebAPI_Atend_FAQ.Models
{
    public class SolicitacaoModel
    {
        [Key]
        public int Id{ get; set; }
        public string? Categoria { get; set; }
        public string? Assunto { get; set; }
        public string? Descricao { get; set; }
        public string Resposta { get; set; }
        public string ResponsavelAtendimento { get; set; }
        public string? SolicitanteAtendimento { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataResposta { get; set; }
        public DateTime DataFinalizacao { get; set; }
        public string Prioridade { get; set; }
        public bool? StatusAndamentoOuFinalizado { get; set; }
        public string? ResponsavelFinalizador { get; set; }

    }
}
