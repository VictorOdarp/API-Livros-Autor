using APILivros_Autor.Dto.Autor;
using APILivros_Autor.Models;
using APILivros_Autor.Dto.Livro;

namespace APILivros_Autor.Services.LivroService
{
    public interface ILivroInterface
    {
        Task<ResponseModel<List<LivroModel>>> ListarLivros();
        Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor);
        Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro);
        Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto criarLivro);
        Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto editadoLivro);
        Task<ResponseModel<List<LivroModel>>> DeletarLivro(int idLivro);
    }
}
