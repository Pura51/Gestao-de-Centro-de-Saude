using System;
using System.Collections.Generic;

namespace CentroSaudeProject.Classes
{
    public class CentroSaude
    {
        #region Atributos
        private List<Quarto> _quartos;
        private List<Paciente> _pacientes;
        #endregion

        #region Properties
        public IReadOnlyList<Quarto> Quartos
        {
            get { return _quartos.AsReadOnly(); }
        }
        public IReadOnlyList<Paciente> Pacientes
        {
            get { return _pacientes.AsReadOnly(); }
        }
        
        #endregion

        #region Construtores
        public CentroSaude()
        {
            _quartos = new List<Quarto>();
            _pacientes = new List<Paciente>();
        }
        #endregion

        #region Métodos - Pacientes
        public void AdicionarPaciente(Paciente paciente)
        {
            if (paciente == null)
                throw new ArgumentNullException(nameof(paciente), "O paciente não pode ser nulo.");
            _pacientes.Add(paciente);
        }

        public void RemoverPaciente(Paciente paciente)
        {
            if (!_pacientes.Contains(paciente))
                throw new Exception("O paciente não existe no centro de saúde.");
            _pacientes.Remove(paciente);
        }

        public void ListarPacientes()
        {
            Console.WriteLine("=== Pacientes ===");
            foreach (var paciente in _pacientes)
            {
                Console.WriteLine(paciente);
            }
        }
        #endregion

        #region Métodos - Quartos
        public void AdicionarQuarto(Quarto quarto)
        {
            if (quarto == null)
                throw new ArgumentNullException(nameof(quarto), "O quarto não pode ser nulo.");
            _quartos.Add(quarto);
        }

        public void RemoverQuarto(Quarto quarto)
        {
            if (!_quartos.Contains(quarto))
                throw new Exception("O quarto não existe no centro de saúde.");
            _quartos.Remove(quarto);
        }

        public void ListarQuartos()
        {
            Console.WriteLine("=== Quartos ===");
            foreach (var quarto in _quartos)
            {
                Console.WriteLine(quarto);
            }
        }
        #endregion


    }
}
