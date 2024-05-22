using System.Text.Json.Serialization;

namespace APILivros_Autor.Models
{
    public class AutorModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        [JsonIgnore]
        public ICollection<LivroModel> Livro { get; set; } = new List<LivroModel>();
    }
}
