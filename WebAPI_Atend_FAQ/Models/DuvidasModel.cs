using System.ComponentModel.DataAnnotations;

namespace WebAPI_Atend_FAQ.Models
{
    public class DuvidasModel
    {
        [Key]
        public int Id { get; set; }
        public String Categoria { get; set; }
        public String Titulo { get; set; }
        public String Conteudo { get; set; }
        public DateTime DataCriacao { get; set; } = DateTime.Now.ToLocalTime();
        public DateTime DataAlteracao { get; set; } = DateTime.Now.ToLocalTime();
        public String Criacao {  get; set; }
        public bool Ativo { get; set; } = true;     



    }
}
