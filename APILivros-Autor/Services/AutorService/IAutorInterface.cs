using APILivros_Autor.Dto.Autor;
using APILivros_Autor.Models;

namespace APILivros_Autor.Services.AutorService
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> ListarAutorPorIdLivro(int idLivro);
        Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto novoAutorDto);
        Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto editadoAutor);
        Task<ResponseModel<List<AutorModel>>> DeletarAutor(int idAutor);

    }
}
