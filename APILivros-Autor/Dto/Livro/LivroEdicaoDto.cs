using APILivros_Autor.Models;

namespace APILivros_Autor.Dto.Livro
{
    public class LivroEdicaoDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public AutorModel Autor { get; set; }
    }
}
