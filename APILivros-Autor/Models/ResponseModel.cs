namespace APILivros_Autor.Models
{
    public class ResponseModel<T>
    {
        public T? Dados { get; set; }
        public string Messagem { get; set; } = string.Empty;
        public bool Status { get; set; } = true;
    }
}
