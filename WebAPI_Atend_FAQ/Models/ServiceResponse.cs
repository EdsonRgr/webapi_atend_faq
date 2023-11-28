namespace WebAPI_Atend_FAQ.Models
{
    public class ServiceResponse<T>
    {
        public T? Dados { get; set; }
        public String Mensagem { get; set; }
        public bool Sucesso { get; set; } = true;

    }
}
