using APILivros_Autor.Dto.Livro;
using APILivros_Autor.Models;
using APILivros_Autor.Services.LivroService;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace APILivros_Autor.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LivroController : ControllerBase
    {
        public readonly ILivroInterface _livroInterface;

        public LivroController(ILivroInterface livroInterface)
        {
            _livroInterface = livroInterface;
        }

        [HttpGet("ListarLivros")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await  _livroInterface.ListarLivros();
            return Ok(livros);
        }

        [HttpGet("BuscarLivroPorIDAutor")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> BuscarLivroPorIdAutor(int id)
        {
            var livro = await _livroInterface.BuscarLivroPorIdAutor(id);
            return Ok(livro);

        }

        [HttpGet("BuscarLivroPorId")]
        public async Task<ActionResult<ResponseModel<LivroModel>>> BuscarLivroPorId(int id)
        {
            var livro = await _livroInterface.BuscarLivroPorId(id);
            return Ok(livro);

        }

        [HttpPost("CriarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> CriarLivro(LivroCriacaoDto livroCriacao)
        {
            var livro = await _livroInterface.CriarLivro(livroCriacao);
            return Ok(livro);
        }

        [HttpPut("EditarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> EditarLivro(LivroEdicaoDto livroEdicao)
        {
            var livro = await _livroInterface.EditarLivro(livroEdicao);
            return Ok(livro);
        }

        [HttpDelete("DeletarLivro")]
        public async Task<ActionResult<ResponseModel<List<LivroModel>>>> DeletarLivro(int id)
        {
            var livro = await _livroInterface.DeletarLivro(id);
            return Ok(livro);
        }


     }
}
