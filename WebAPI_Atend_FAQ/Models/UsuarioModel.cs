using System.ComponentModel.DataAnnotations;

namespace WebAPI_Atend_FAQ.Models
{
    public class UsuarioModel
    {
        [Key]
        public int Id { get; set; }
        public String Nome { get; set; }
        public String Funcional {  get; set; }
        public String Senha {  get; set; }
        public bool? UserAtendimento { get; set; }
    }
}
