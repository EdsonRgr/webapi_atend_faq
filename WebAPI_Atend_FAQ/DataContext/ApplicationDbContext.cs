using Microsoft.EntityFrameworkCore;
using WebAPI_Atend_FAQ.Models;

namespace WebAPI_Atend_FAQ.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<SolicitacaoModel> Solicitacaos { get; set; }
        public DbSet<DuvidasModel> FaqDuvidas{ get; set; }
        public DbSet<UsuarioModel> Ususarios { get; set; }
    }
}
