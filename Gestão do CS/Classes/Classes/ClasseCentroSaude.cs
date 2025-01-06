using System;
using System.Collections.Generic;
using System.Linq;

namespace CentroSaudeProject.Classes
{
    public class CentroSaude
    {
        #region Atributos
        private List<Quarto> _quartos;
        private List<Paciente> _pacientes;
        private List<Consulta> _consultas;
        private List<Exame> _exames;
        private List<Medico> _medicos; 
        private List<Enfermeiro> _enfermeiros; 
        private List<Cama> _camas;
        #endregion

        #region Properties
        public IReadOnlyList<Quarto> Quartos => _quartos.AsReadOnly();
        public IReadOnlyList<Paciente> Pacientes => _pacientes.AsReadOnly();
        public IReadOnlyList<Consulta> Consultas => _consultas.AsReadOnly();
        public IReadOnlyList<Exame> Exames => _exames.AsReadOnly();
        public IReadOnlyList<Medico> Medicos => _medicos.AsReadOnly();
        public IReadOnlyList<Enfermeiro> Enfermeiros => _enfermeiros.AsReadOnly();
        public IReadOnlyList<Cama> Camas => _camas.AsReadOnly();
        #endregion

        #region Construtores
        public CentroSaude()
        {
            _quartos = new List<Quarto>();
            _pacientes = new List<Paciente>();
            _consultas = new List<Consulta>();
            _exames = new List<Exame>();
            _medicos = new List<Medico>(); 
            _enfermeiros = new List<Enfermeiro>(); 
            _camas = new List<Cama>();
        }
        #endregion

        #region Métodos - Pacientes
        public void AdicionarPaciente(Paciente paciente)
        {
            if (paciente == null)
                throw new ArgumentNullException(nameof(paciente), "O paciente não pode ser nulo.");
            _pacientes.Add(paciente);
        }

        public void RemoverPaciente(int idPaciente)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);
            if (paciente == null)
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
            Console.WriteLine($"Quarto {quarto.Numero} adicionado. Total de quartos: {_quartos.Count}");
        }

        public void RemoverQuarto(int numeroQuarto)
        {
            var quarto = _quartos.FirstOrDefault(q => q.Numero == numeroQuarto);
            if (quarto == null)
                throw new Exception("O quarto não existe no centro de saúde.");
            _quartos.Remove(quarto);
        }

        public void ListarQuartos()
        {
            Console.WriteLine("=== Quartos ===");
            foreach (var quarto in _quartos)
            {
                Console.WriteLine(quarto); // ToString de Quarto será usado aqui.
            }
        }
        #endregion

        public void AlocarPacienteAutomatico(int idPaciente)
        {
            var paciente = _pacientes.FirstOrDefault(p => p.IdPaciente == idPaciente);
            if (paciente == null)
            {
                Console.WriteLine("Paciente não encontrado.");
                return;
            }

            if (paciente.CamaOcupada != null)
            {
                Console.WriteLine($"O paciente já está alocado na cama ID: {paciente.CamaOcupada.IdCama}.");
                return;
            }

            foreach (var quarto in _quartos)
            {
                var camaDisponivel = quarto.Camas.FirstOrDefault(c => c.Disponivel);
                if (camaDisponivel != null)
                {
                    paciente.AtribuirCama(camaDisponivel);
                    camaDisponivel.Ocupar();

                    Console.WriteLine($"Paciente {paciente.Nome} foi alocado automaticamente à cama {camaDisponivel.NumeroCama} no quarto {quarto.Numero} com sucesso!");
                    return;
                }
            }

            Console.WriteLine("Não há camas disponíveis em nenhum quarto.");
        }

        #region Métodos - Consultas
        public void ListarConsultas()
        {
            Console.WriteLine("=== Consultas ===");
            foreach (var consulta in _consultas)
            {
                Console.WriteLine(consulta);
            }
        }

        public void AdicionarConsulta(Consulta consulta)
        {
            if (consulta == null)
                throw new ArgumentNullException(nameof(consulta), "A consulta não pode ser nula.");
            _consultas.Add(consulta);
        }
        #endregion

        #region Métodos - Exames
        public void ListarExames()
        {
            Console.WriteLine("=== Exames ===");
            foreach (var exame in _exames)
            {
                Console.WriteLine(exame);
            }
        }
        #endregion

        #region Métodos - Médico
        public void AdicionarMedico(Medico medico)
        {
            if (medico == null)
                throw new ArgumentNullException(nameof(medico), "O médico não pode ser nulo.");
            _medicos.Add(medico);
        }
        #endregion

        #region Métodos - Enfermeiros
        public void AdicionarEnfermeiro(Enfermeiro enfermeiro)
        {
            if (enfermeiro == null)
                throw new ArgumentNullException(nameof(enfermeiro), "O enfermeiro não pode ser nulo.");
            _enfermeiros.Add(enfermeiro);
        }
        #endregion
    }
}
