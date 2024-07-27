namespace eclipseworksDesafio.Core.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNasc { get; set; }
        public bool Ativo {  get; set; }   
    }
}
