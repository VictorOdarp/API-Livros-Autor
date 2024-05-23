using APILivros_Autor.Models;
using Microsoft.EntityFrameworkCore;

namespace APILivros_Autor.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        DbSet<LivroModel> Livros { get; set; }
        DbSet<AutorModel> Autores { get; set; }
     
    }
}
