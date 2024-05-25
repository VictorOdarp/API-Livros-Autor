using APILivros_Autor.Data;
using APILivros_Autor.Dto.Autor;
using APILivros_Autor.Models;
using Microsoft.EntityFrameworkCore;

namespace APILivros_Autor.Services.AutorService
{
    public class AutorService : IAutorInterface
    {
        private readonly AppDbContext _context;
        public AutorService(AppDbContext context)
        {
            _context = context;
        }


        public async Task<ResponseModel<List<AutorModel>>> ListarAutores()
        {
            ResponseModel<List<AutorModel>> responseModel = new ResponseModel<List<AutorModel>>();

            try
            {
                if(responseModel.Dados == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Nenhum dado encontrado!";
                    responseModel.Status = false;
                }

                responseModel.Dados = await _context.Autores.ToListAsync();
            }
            catch (Exception ex)
            {
                responseModel.Messagem = ex.Message;
                responseModel.Status = false;
            }

            return responseModel;
        }

        public async Task<ResponseModel<AutorModel>> BuscarAutorPorId(int idAutor)
        {
            ResponseModel<AutorModel> responseModel = new ResponseModel<AutorModel>();

            try
            {
                if(idAutor == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar dados!";
                    responseModel.Status = false;
                }

                var autor = await _context.Autores.FirstOrDefaultAsync(X => X.Id == idAutor);

                if(autor == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Nenhum dado encontrado";
                    responseModel.Status = false;
                }

                responseModel.Dados = autor;
            }
            catch (Exception ex)
            {
                responseModel.Messagem = ex.Message;
                responseModel.Status = false;
            }

            return responseModel;
            
        }

        public async Task<ResponseModel<AutorModel>> ListarAutorPorIdLivro(int idLivro)
        {
            ResponseModel<AutorModel> responseModel = new ResponseModel<AutorModel>();

            try
            {
                if(idLivro == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar dados!";
                    responseModel.Status = false;
                }

                LivroModel livro = await _context.Livros.Include(Autor => Autor.Autor).FirstOrDefaultAsync(livroBanco => livroBanco.Id == idLivro);

                if(livro == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Nenhum dado encontrado!";
                    responseModel.Status = false;
                }

                responseModel.Dados = livro.Autor;
            }
            catch (Exception ex)
            {
                responseModel.Messagem = ex.Message;
                responseModel.Status = false;
            }

            return responseModel;
        }

        public async Task<ResponseModel<List<AutorModel>>> CriarAutor(AutorCriacaoDto novoAutorDto)
        {
            ResponseModel<List<AutorModel>> responseModel = new ResponseModel<List<AutorModel>>();

            try
            {
                var autor = new AutorModel()
                {
                    Name = novoAutorDto.Name,
                    Surname = novoAutorDto.Surname,
                };

                _context.Add(autor) ;
                await _context.SaveChangesAsync();

                responseModel.Dados = await _context.Autores.ToListAsync();
                responseModel.Messagem = "Autor criado com sucesso!";

                return responseModel;
            }
            catch(Exception e)
            {
                responseModel.Messagem = e.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> EditarAutor(AutorEdicaoDto editadoAutorDto)
        {
            ResponseModel<List<AutorModel>> responseModel = new ResponseModel<List<AutorModel>>();

            try
            {
                if (editadoAutorDto == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar Dados!";
                    responseModel.Status = false;
                }

                AutorModel autor = await _context.Autores.AsNoTracking().FirstOrDefaultAsync(autor => autor.Id == editadoAutorDto.Id);

                if (autor == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Autor não encontrado!";
                    responseModel.Status = false;
                    return responseModel;
                }

                autor.Name = editadoAutorDto.Name;
                autor.Surname = editadoAutorDto.Surname;

                _context.Update(autor);
                await _context.SaveChangesAsync();

                responseModel.Dados = await _context.Autores.ToListAsync();
                responseModel.Messagem = "Autor editado com sucesso";

                return responseModel;
            }
            catch (Exception e)
            {
                responseModel.Messagem = e.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }

        public async Task<ResponseModel<List<AutorModel>>> DeletarAutor(int idAutor)
        {
            ResponseModel<List<AutorModel>> responseModel = new ResponseModel<List<AutorModel>>();

            try
            {
                if (idAutor == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Informar dados!";
                    responseModel.Status = false;
                }

                AutorModel autor = await _context.Autores.FirstOrDefaultAsync(autorId => autorId.Id == idAutor);

                if (autor == null)
                {
                    responseModel.Dados = null;
                    responseModel.Messagem = "Nenhum autor encontrado";
                    responseModel.Status = false;
                    return responseModel;
                }

                _context.Remove(autor);
                await _context.SaveChangesAsync();

                responseModel.Dados = await _context.Autores.ToListAsync();
                responseModel.Messagem = "Autor deletado com sucesso";

                return responseModel;

            }
            catch (Exception e)
            {
                responseModel.Messagem = e.Message;
                responseModel.Status = false;
                return responseModel;
            }
        }
    }
}
