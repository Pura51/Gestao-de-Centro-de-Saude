using CentroSaudeProject.Enums;

namespace CentroSaudeProject.Classes
{
    public class Funcionario
    {
        public string Nome { get; set; }
        public Categoria Categoria { get; set; }

        public Funcionario(string nome, Categoria categoria)
        {
            Nome = nome;
            Categoria = categoria;
        }

        public override string ToString()
        {
            return $"{Nome} - {Categoria}";
        }
    }
}
