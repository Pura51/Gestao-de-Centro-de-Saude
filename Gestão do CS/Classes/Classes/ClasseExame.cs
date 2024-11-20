using System;
using CentroSaudeProject.Enums;

namespace CentroSaudeProject.Classes
{
    public class Exame
    {
        public int Id { get; private set; }
        public string Nome { get; set; }
        public DateTime Data { get; set; }
        public string Resultado { get; set; }
        public TipoExame Tipo { get; set; }

        private static int ProximoId = 1;

        public Exame(string nome, DateTime data, TipoExame tipo)
        {
            Id = ProximoId++;
            Nome = nome;
            Data = data;
            Tipo = tipo;
            Resultado = "Pendente";
        }

        public void AtualizarResultado(string resultado) => Resultado = resultado;

        public override string ToString() => $"Exame {Id}: {Nome}, Tipo: {Tipo}, Resultado: {Resultado}";
    }
}
