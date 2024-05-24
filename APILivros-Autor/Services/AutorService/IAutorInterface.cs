using APILivros_Autor.Models;

namespace APILivros_Autor.Services.AutorService
{
    public interface IAutorInterface
    {
        Task<ResponseModel<List<AutorModel>>> ListarAutores();
        Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor);
        Task<ResponseModel<AutorModel>> ListarAutorPorIdLivro(int idLivro);

    }
}
