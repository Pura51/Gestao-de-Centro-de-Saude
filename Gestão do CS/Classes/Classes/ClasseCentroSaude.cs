using System;
using System.Collections.Generic;

namespace CentroSaudeProject.Classes
{
    public class CentroSaude
    {
        public List<Funcionario> Funcionarios { get; private set; } = new List<Funcionario>();
        public List<Paciente> Pacientes { get; private set; } = new List<Paciente>();
        public List<Quarto> Quartos { get; private set; } = new List<Quarto>();

        // Métodos para Funcionários
        public void AdicionarFuncionario(Funcionario funcionario) => Funcionarios.Add(funcionario);

        public void RemoverFuncionario(Funcionario funcionario) => Funcionarios.Remove(funcionario);

        public List<Funcionario> ObterFuncionarios() => Funcionarios;

        // Métodos para Pacientes
        public void AdicionarPaciente(Paciente paciente) => Pacientes.Add(paciente);

        public void RemoverPaciente(Paciente paciente) => Pacientes.Remove(paciente);

        public List<Paciente> ObterPacientes() => Pacientes;

        // Métodos para Quartos
        public void AdicionarQuarto(Quarto quarto) => Quartos.Add(quarto);

        public List<Quarto> ObterQuartos() => Quartos;
    }
}
