using eclipseworksDesafio.Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace eclipseworksDesafio.Infrastructure.Data.Context
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions<AppDbContext> options)
         : base(options)
        {
        }
        public DbSet<Usuario> Usuarios { get; set; }
        public DbSet<Tarefa> Tarefas { get; set; }
        public DbSet<Projeto> Projetos { get; set; }
        public DbSet<HistoricoTarefa> HistoricoTarefas { get; set; }
        public DbSet<Comentario> Comentarios { get; set; }


    }
}
