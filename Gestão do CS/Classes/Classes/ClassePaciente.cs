

namespace CentroSaudeProject.Classes
{
    public class Paciente
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
        public char Sexo { get; set; }
        public List<Consulta> Consultas { get; private set; } = new List<Consulta>();

        private static int ProximoId = 1;

        public Paciente(string nome, int idade, char sexo)
        {
            Id = ProximoId++;
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
        }

        public void AdicionarConsulta(Consulta consulta) => Consultas.Add(consulta);

        public List<Consulta> ObterConsultas() => Consultas;

        public override string ToString() => $"Paciente {Id}: {Nome}, {Idade} anos, Sexo: {Sexo}";
    }
}
