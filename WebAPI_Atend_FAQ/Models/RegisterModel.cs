using System.ComponentModel.DataAnnotations;

namespace WebAPI_Atend_FAQ.Models
{
    public class RegisterModel
    {

        [Required(ErrorMessage = "Nome do Usuario é obrigatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha é obrigatorio")]
        public string Password { get; set; }

        public bool? UserAtendimento { get; set; } = false;

        public string? Funcional { get; set; }
        public string? NomeCompleto { get; set; }

    }
}
