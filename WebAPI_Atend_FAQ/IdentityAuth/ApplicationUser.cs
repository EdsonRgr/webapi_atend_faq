using Microsoft.AspNetCore.Identity;

namespace WebAPI_Atend_FAQ.IdentityAuth
{
    public class ApplicationUser: IdentityUser
    {
        public bool? UserAtendimento { get; set; }
        public string? Funcional { get; set; }
        public string? NomeCompleto { get; set; }
    }
}
