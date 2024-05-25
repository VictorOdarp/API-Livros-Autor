using APILivros_Autor.Dto.Autor;
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

        [HttpGet("BuscarPorAutorId/{idAutor}")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> BuscarAutorPorId(int idAutor)
        {
            var autor = await _autorInterface.BuscarAutorPorId(idAutor);
            return Ok(autor);
        }

        [HttpGet("BuscarPorLivroId/{idLivro}")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> BuscarAutorPorLivroId(int idLivro)
        {
            var autorLivro = await _autorInterface.ListarAutorPorIdLivro(idLivro);
            return Ok(autorLivro);
        }

        [HttpPost("CriarAutor")]
        public async Task<ActionResult<ResponseModel<List<AutorModel>>>> CriarAutor(AutorCriacaoDto autorCriacao)
        {
            var autores = await _autorInterface.CriarAutor(autorCriacao);
            return Ok(autores);
        }

        [HttpPut("EditarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> EditarAutor(AutorEdicaoDto autorEdicao)
        {
            var autores = await _autorInterface.EditarAutor(autorEdicao);
            return Ok(autores);
        }

        [HttpDelete("DeletarAutor")]
        public async Task<ActionResult<ResponseModel<AutorModel>>> DeletarAutor(int idAutor)
        {
            var autor = await _autorInterface.DeletarAutor(idAutor);
            return Ok(autor);
        }
    }
}
