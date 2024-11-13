using System;
using CentroSaudeProject.Classes;

namespace CentrodeSaudeProject.Classes
{
    public class Consulta
    {
        public int Id { get; set; }
        public Paciente Paciente { get; set; }
        public Funcionario Medico { get; set; }
        public DateTime Data { get; set; }
        public double Custo { get; set; }

        public Consulta(int id, Paciente paciente, Funcionario medico, DateTime data, double custo)
        {
            Id = id;
            Paciente = paciente;
            Medico = medico;
            Data = data;
            Custo = custo;
        }
    }
}