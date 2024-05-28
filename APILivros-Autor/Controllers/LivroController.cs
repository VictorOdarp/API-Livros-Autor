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
        public async Task <ActionResult<ResponseModel<List<LivroModel>>>> ListarLivros()
        {
            var livros = await  _livroInterface.ListarLivros();
            return Ok(livros);
        }
     }
}
