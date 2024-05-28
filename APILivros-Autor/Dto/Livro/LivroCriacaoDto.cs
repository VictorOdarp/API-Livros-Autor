using APILivros_Autor.Models;

namespace APILivros_Autor.Dto.Livro
{
    public class LivroCriacaoDto
    {
        public string Title { get; set; }
        public AutorModel Autor { get; set; }
    }
}
