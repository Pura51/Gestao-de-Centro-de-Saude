using CentroSaudeProject.Enums;

namespace CentroSaudeProject.Classes
{
    public class Paciente : Pessoa
    {
        #region Atributos
        private static int _proximoId = 1; // Gera Id automaticamente
        private int _idPaciente;
        private List<Consulta> _consultas; // Consultas associadas ao paciente
        private Cama _camaOcupada; // Nova propriedade para cama ocupada
        private TipoEstadoPaciente _tipoEstadoPaciente; // Estado do paciente: Alta, Internado, Em espera
        #endregion

        #region Propriedades
        public int IdPaciente
        {
            get { return _idPaciente; }
            private set { _idPaciente = value; } // Id definido apenas pela classe
        }

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

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Nome não pode ser vazio");
                _nome = value;
            }
        }

        public int Idade
        {
            get { return _idade; }
            set
            {
                if (value <= 0)
                    throw new Exception("Idade inválida");
                _idade = value;
            }
        }

        public char Sexo
        {
            get { return _sexo; }
            set
            {
                if (value != 'M' && value != 'F')
                    throw new Exception("Sexo deve ser 'M' (Masculino) ou 'F' (Feminino)");
                _sexo = value;
            }
        }

        public IReadOnlyList<Consulta> Consultas
        {
            get { return _consultas.AsReadOnly(); }
        }
        #endregion

        #region Construtores
        public Paciente(string nome, int idade, char sexo, int ccNum, int ccNIF)
            : base(nome, idade, ccNum, ccNIF, sexo)  // Chama o construtor da classe base Pessoa
        {
            IdPaciente = _proximoId++;
            _consultas = new List<Consulta>();
            _tipoEstadoPaciente = TipoEstadoPaciente.EmEspera; // Estado inicial como "Em espera"
        }

        #endregion

        #region Métodos
        /// <summary>
        /// Atribui uma cama ao paciente
        /// </summary>
        public void AtribuirCama(Cama cama)
        {
            if (CamaOcupada != null)
                throw new Exception("O paciente já possui uma cama atribuída.");
            _camaOcupada = cama;
            cama.Ocupar();
            EstadoPaciente = TipoEstadoPaciente.Internado;
        }

        /// <summary>
        /// Libera a cama ocupada pelo paciente
        /// </summary>
        public void LiberarCama()
        {
            if (CamaOcupada == null)
                throw new Exception("O paciente não possui uma cama atribuída.");
            _camaOcupada.Libertar();
            _camaOcupada = null;
            EstadoPaciente = TipoEstadoPaciente.Alta;
        }

        /// <summary>
        /// Adiciona uma consulta ao paciente
        /// </summary>
        public void AdicionarConsulta(Consulta consulta)
        {
            if (consulta == null)
                throw new Exception("Consulta inválida");
            _consultas.Add(consulta);
        }

        /// <summary>
        /// Remove uma consulta do paciente
        /// </summary>
        public void RemoverConsulta(Consulta consulta)
        {
            if (!_consultas.Contains(consulta))
                throw new Exception("Consulta não está associada a este paciente");
            _consultas.Remove(consulta);
        }

        public override string ToString()
        {
            return $"Id: {IdPaciente} | Nome: {Nome} | Idade: {Idade} | Sexo: {Sexo} | Estado: {EstadoPaciente}";
        }
        #endregion

        #region Destrutores
        ~Paciente()
        {
        }
        #endregion
    }
}