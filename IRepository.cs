public interface IRepository<T>
{
    string ConnectionString { get; set; }
    void GarantirEsquema();
    int Inserir(string nome, int idade, string email, DateTime dataNascimento);
    List<T> Listar();
    int Atualizar(int id, string nome, int idade, string email, DateTime dataNascimento);
    int Excluir(int id);
    List<T> Buscar(string propriedade, object valor);
}
