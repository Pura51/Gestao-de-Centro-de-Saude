using System;
using System.Collections.Generic;

namespace CentroSaudeProject.Classes
{
    public class Consulta
    {
        public int Id { get; private set; }
        public DateTime Data { get; set; }
        public float Custo { get; set; }
        public string Diagnostico { get; set; }
        public Funcionario Medico { get; set; }
        public List<Exame> Exames { get; private set; } = new List<Exame>();

        private static int ProximoId = 1;

        public Consulta(DateTime data, float custo, Funcionario medico)
        {
            Id = ProximoId++;
            Data = data;
            Custo = custo;
            Medico = medico;
            Diagnostico = "Pendente";
        }

        public void AdicionarExame(Exame exame) => Exames.Add(exame);

        public List<Exame> ObterExames() => Exames;

        public override string ToString() => $"Consulta {Id}: {Data:dd/MM/yyyy}, Médico: {Medico.Nome}, Diagnóstico: {Diagnostico}";
    }
}
