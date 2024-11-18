using System;

namespace CentroSaudeProject.Classes
{
    public class Exame
    {
        // Atributos
        public int Id { get; private set; } // Identificador único do exame
        public string Nome { get; set; } // Nome do exame (ex: "Raio-X", "Sangue")
        public DateTime Data { get; set; } // Data do exame
        public string Resultado { get; set; } // Resultado do exame (pode ser vazio inicialmente)
        public Paciente Paciente { get; set; } // Paciente associado ao exame
        public Funcionario Medico { get; set; } // Médico responsável pelo exame

        private static int ProximoId = 1; // Gerador automático de ID

        // Construtor
        public Exame(string nome, DateTime data, Paciente paciente, Funcionario medico)
        {
            Id = ProximoId++;
            Nome = nome;
            Data = data;
            Paciente = paciente;
            Medico = medico;
            Resultado = "Pendente"; // Define o resultado padrão como "Pendente"
        }

        // Método para atualizar o resultado do exame
        public void AtualizarResultado(string resultado)
        {
            Resultado = resultado;
            Console.WriteLine($"Resultado do exame {Id} ({Nome}) atualizado: {Resultado}");
        }

        // Método para exibir informações do exame
        public override string ToString()
        {
            return $"Exame {Id}: {Nome} | Data: {Data:dd/MM/yyyy} | Paciente: {Paciente.Nome} | Médico: {Medico.Nome} | Resultado: {Resultado}";
        }
    }
}
