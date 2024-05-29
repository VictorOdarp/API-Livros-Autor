using APILivros_Autor.Data;
using APILivros_Autor.Dto.Autor;
using APILivros_Autor.Dto.Livro;
using APILivros_Autor.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System.Diagnostics.Contracts;

namespace APILivros_Autor.Services.LivroService
{
    public class LivroService : ILivroInterface
    {
        public readonly AppDbContext _context;
        public LivroService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<ResponseModel<List<LivroModel>>> ListarLivros()
        {
            ResponseModel<List<LivroModel>> responseModel = new ResponseModel<List<LivroModel>>();

            try
            {
                if (_context.Livros.Count() == 0)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Nenhum dado encontrado!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                responseModel.Messagem = "Os Livros acima foram coletados";
                
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Messagem = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> BuscarLivroPorIdAutor(int idAutor)
        {
            ResponseModel<List<LivroModel>> responseModel = new ResponseModel<List<LivroModel>>();

            try
            {
                if(idAutor <= 0)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar dados!";
                    responseModel.Status = false;
                    return responseModel;
                }

                var livro = await _context.Livros.Include(autor => autor.Autor).Where(bancoLivro => bancoLivro.Autor.Id == idAutor).ToListAsync();

                if(livro == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Nenhum dado encontrado!";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Dados = livro;
                responseModel.Messagem = "Livros coletados pelo Autor";
                return responseModel;

            }
            catch(Exception ex)
            {
                responseModel.Messagem = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<LivroModel>> BuscarLivroPorId(int idLivro)
        {
            ResponseModel<LivroModel> responseModel = new ResponseModel<LivroModel>();

            try
            {
                if (idLivro == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar dados!";
                    responseModel.Status = false;
                    return responseModel;
                }

                LivroModel livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(bancoLivro => bancoLivro.Id == idLivro);

                if (livro == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Nenhum dado encontrado";
                    responseModel.Status = false;
                    return responseModel;
                }

                responseModel.Dados = livro;
                responseModel.Messagem = "Livro encontrado com sucesso!";

                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Messagem = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> CriarLivro(LivroCriacaoDto novoLivroDto)
        {
            ResponseModel<List<LivroModel>> responseModel = new ResponseModel<List<LivroModel>>();

            try
            {
                if (novoLivroDto == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar dados!";
                    responseModel.Status = false;
                    return responseModel;
                }

                AutorModel autorid = await _context.Autores.FirstOrDefaultAsync(bancoAutores => bancoAutores.Id == novoLivroDto.Autor.Id);

                if (autorid == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Nenhum registro de autor localizado!";
                }

                LivroModel livro = new LivroModel()
                {
                    Title = novoLivroDto.Title,
                    Autor = autorid,

                };

                _context.Add(livro);
                await _context.SaveChangesAsync();

                responseModel.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync(); 
                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Messagem = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> EditarLivro(LivroEdicaoDto editadoLivro)
        {
            ResponseModel<List<LivroModel>> responseModel = new ResponseModel<List<LivroModel>>();

            try
            {
                if (editadoLivro == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar dados!";
                    responseModel.Status = false;
                    return responseModel;
                }

                LivroModel livro = await _context.Livros.Include(a => a.Autor).FirstOrDefaultAsync(bancoLivro => bancoLivro.Id == editadoLivro.Id);

                AutorModel autor = await _context.Autores.FirstOrDefaultAsync(bancoAutor => bancoAutor.Id == editadoLivro.Autor.Id);

                if (livro == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Livro não encontrado!";
                    responseModel.Status = false;
                    return responseModel;
                }

                if (autor == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Autor não encontrado!";
                    responseModel.Status = false;
                    return responseModel;
                }

                livro.Title = editadoLivro.Title;
                livro.Autor = autor;

                _context.Update(livro);
                await _context.SaveChangesAsync();

                responseModel.Dados = await _context.Livros.Include(a => a.Autor).ToListAsync();
                responseModel.Messagem = "Livro editado com sucesso!";

                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Messagem = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<LivroModel>>> DeletarLivro(int idLivro)
        {
            ResponseModel<List<LivroModel>> responseModel = new ResponseModel<List<LivroModel>>();

            try
            {
                if (idLivro <= 0)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar dados!";
                    responseModel.Status = false;
                    return responseModel;
                }

                LivroModel livro = await _context.Livros.FirstOrDefaultAsync(bancoLivro => bancoLivro.Id == idLivro);

                if (livro == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar dados!";
                    responseModel.Status = false;
                    return responseModel;
                }

                _context.Remove(livro);
                await _context.SaveChangesAsync();

                responseModel.Dados = await _context.Livros.ToListAsync();
                responseModel.Messagem = "Livro deletado com sucesso!";

                return responseModel;
            }
            catch (Exception ex)
            {
                responseModel.Messagem = ex.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }
    }
}
