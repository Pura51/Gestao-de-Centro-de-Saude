using CentroSaudeProject.Enums;

namespace CentroSaudeProject.Classes
{
    public class Funcionario
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Categoria Categoria { get; set; }

        private static int ProximoId = 1;

        public Funcionario(string nome, int idade, Categoria categoria)
        {
            Id = ProximoId++;
            Nome = nome;
            Idade = idade;
            Categoria = categoria;
        }

        public override string ToString() => $"Funcionário {Id}: {Nome}, {Categoria}";
    }
}
