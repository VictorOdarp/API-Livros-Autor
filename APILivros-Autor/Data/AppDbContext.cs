using APILivros_Autor.Models;
using Microsoft.EntityFrameworkCore;

namespace APILivros_Autor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<LivroModel> Livros { get; set; }
        public DbSet<AutorModel> Autores { get; set; }
     
    }
}
