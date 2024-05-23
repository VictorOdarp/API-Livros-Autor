using System.Diagnostics.Contracts;

namespace APILivros_Autor.Models
{
    public class LivroModel
    {
        public int Id {  get; set; }
        public string Title { get; set; }
        public AutorModel Autor { get; set; }
    }
}