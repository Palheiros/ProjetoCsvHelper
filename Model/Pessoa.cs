namespace ProjectCsvHelper.Model
{
    public class Pessoa
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public int Telefone { get; set; }

        public Pessoa(string nome, string email, int telefone)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
        }

        public Pessoa()
        {
        }
    }
}