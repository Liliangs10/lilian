using Microsoft.EntityFrameworkCore;
using RazorMVCApp.Models;

namespace RazorMVCApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Tag> Tags { get; set; }
        public DbSet<Noticia> Noticias { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<NoticiaTag> NoticiaTags { get; set; }
        public DbSet<TesteModelo> TesteModelos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //modelBuilder.Entity<NoticiaTag>()
            //    .HasKey(nt => new { nt.NoticiaId, nt.TagId });

            //modelBuilder.Entity<NoticiaTag>()
            //    .HasOne(nt => nt.Noticia)
            //    .WithMany(n => n.NoticiaTags)
            //    .HasForeignKey(nt => nt.NoticiaId);

            //modelBuilder.Entity<NoticiaTag>()
            //    .HasOne(nt => nt.Tag)
            //    .WithMany(t => t.NoticiaTags)
            //    .HasForeignKey(nt => nt.TagId);
        }
    }
}
