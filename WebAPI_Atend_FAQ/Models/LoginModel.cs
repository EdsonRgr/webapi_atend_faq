using System.ComponentModel.DataAnnotations;

namespace WebAPI_Atend_FAQ.Models
{
    public class LoginModel
    {
        [Required(ErrorMessage =  "Nome do Usuario é obrigatorio")]
        public string Username { get; set; }

        [Required(ErrorMessage = "Senha é obrigatorio")]
        public string Password { get; set; }
    }

}
