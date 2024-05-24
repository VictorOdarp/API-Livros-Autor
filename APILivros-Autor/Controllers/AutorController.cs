using APILivros_Autor.Models;
using APILivros_Autor.Services.AutorService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILivros_Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutorController : ControllerBase
    {
        private readonly IAutorInterface _autorInterface;
        public AutorController(IAutorInterface autorInterface)
        {
            _autorInterface = autorInterface;
        }

        [HttpGet("ListarAutores")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> ListarAutores()
        {
            var list = await _autorInterface.ListarAutores();
            return Ok(list);

        }

        [HttpGet("BuscarPorAutorId")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarPorLivroId")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> BuscarAutorPorLivroId(int idLivro)
        {
            var autorLivro = await _autorInterface.ListarAutorPorIdLivro(idLivro);
            return Ok(autorLivro);
        }
    }
}
