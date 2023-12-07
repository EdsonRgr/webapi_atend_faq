using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebAPI_Atend_FAQ.IdentityAuth;
using WebAPI_Atend_FAQ.Models;

namespace WebAPI_Atend_FAQ.DataContext
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
        }

        public DbSet<SolicitacaoModel> Solicitacaos { get; set; }
        public DbSet<DuvidasModel> FaqDuvidas{ get; set; }
        public DbSet<UsuarioModel> Ususarios { get; set; }
    }
}
