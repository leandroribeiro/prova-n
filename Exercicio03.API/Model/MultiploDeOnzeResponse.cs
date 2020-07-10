namespace Exercicio03.API.Model
{
    public class MultiploDeOnzeResponse
    {
        public MultiploDeOnzeResponse(string numero)
        {
            this.number = numero;
        }

        public string number { get; set; }
        public bool isMultiple { get; set; } 
    }
}