using CentroSaudeProject.Enums;
using System;
using System.Collections.Generic;

namespace CentroSaudeProject.Classes
{
    public class Paciente : Pessoa
    {
        #region Atributos
        private static int _proximoId = 1;
        private int _idPaciente;
        private List<Consulta> _consultas;
        private Cama _camaOcupada;
        private TipoEstadoPaciente _tipoEstadoPaciente;
        #endregion

        #region Propriedades
        public int IdPaciente { get; private set; }

        public Cama CamaOcupada
        {
            get { return _camaOcupada; }
            private set { _camaOcupada = value; }
        }

        public TipoEstadoPaciente EstadoPaciente
        {
            get { return _tipoEstadoPaciente; }
            set { _tipoEstadoPaciente = value; }
        }

        public new string Nome
        {
            get { return base.Nome; }
            set { base.Nome = value; }
        }

        public new int Idade
        {
            get { return base.Idade; }
            set { base.Idade = value; }
        }

        public new char Sexo
        {
            get { return base.Sexo; }
            set { base.Sexo = value; }
        }

        public IReadOnlyList<Consulta> Consultas
        {
            get { return _consultas.AsReadOnly(); }
        }
        #endregion

        #region Construtores
        public Paciente(string nome, int idade, char sexo, int ccNum, int ccNIF)
            : base(nome, idade, ccNum, ccNIF, sexo)
        {
            IdPaciente = _proximoId++;
            _consultas = new List<Consulta>();
            _tipoEstadoPaciente = TipoEstadoPaciente.EmEspera;
        }
        #endregion

        #region Métodos
        public void AtribuirCama(Cama cama)
        {
            if (_camaOcupada != null)
                throw new InvalidOperationException("O paciente já possui uma cama atribuída.");
            _camaOcupada = cama;
            cama.Ocupar();
            EstadoPaciente = TipoEstadoPaciente.Internado;
        }

        public void LiberarCama()
        {
            if (_camaOcupada == null)
                throw new InvalidOperationException("O paciente não possui uma cama atribuída.");
            _camaOcupada.Libertar();
            _camaOcupada = null;
            EstadoPaciente = TipoEstadoPaciente.Alta;
        }

        public void AdicionarConsulta(Consulta consulta)
        {
            if (consulta == null)
                throw new ArgumentNullException(nameof(consulta), "Consulta inválida.");
            _consultas.Add(consulta);
        }

        public void RemoverConsulta(Consulta consulta)
        {
            if (!_consultas.Contains(consulta))
                throw new InvalidOperationException("Consulta não está associada a este paciente.");
            _consultas.Remove(consulta);
        }

        public override string ToString()
        {
            return $"Id: {IdPaciente} | Nome: {Nome} | Idade: {Idade} | Sexo: {Sexo} | Estado: {EstadoPaciente}";
        }
        #endregion
    }
}
