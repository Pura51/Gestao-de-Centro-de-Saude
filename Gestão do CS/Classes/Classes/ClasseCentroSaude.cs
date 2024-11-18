using CentrodeSaudeProject.Classes;
using CentroSaudeProject.Enums;
using System.Xml.Linq;

namespace CentroSaudeProject.Classes 
{
    public class CentroSaude
    {
        private List<Paciente> Pacientes { get; set; } = new List<Paciente>();
        private List<Funcionario> Funcionarios { get; set; } = new List<Funcionario>();
        private List<Consulta> Consultas { get; set; } = new List<Consulta>();
        private List<Exame> Exames { get; set; } = new List<Exame>();
        private List<Cama> Camas { get; set; } = new List<Cama>();
        private List<Quarto> Quartos { get; set; } = new List<Quarto>();

        public void AdicionarPaciente(Paciente paciente)
        {
            Pacientes.Add(paciente);
        }

        public void AdicionarFuncionario(Funcionario funcionario)
        {
            Funcionarios.Add(funcionario);
        }

        public void AdicionarCama(Cama cama)
        {
            Camas.Add(cama);
        }

        public List<Paciente> ObterPacientes()
        {
            return Pacientes;
        }

        public List<Funcionario> ObterFuncionarios()
        {
            return Funcionarios;
        }
    }
}
