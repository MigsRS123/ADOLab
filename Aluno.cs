public class Aluno
{
    public int Id { get; set; }
    public string Nome { get; set; } = string.Empty;
    public int Idade { get; set; }
    public string Email { get; set; } = string.Empty;
    public DateTime DataNascimento { get; set; }

    public Aluno() { }

    public Aluno(int id, string nome, int idade, string email, DateTime dataNascimento)
    {
        Id = id;
        Nome = nome;
        Idade = idade;
        Email = email;
        DataNascimento = dataNascimento;
    }
}
