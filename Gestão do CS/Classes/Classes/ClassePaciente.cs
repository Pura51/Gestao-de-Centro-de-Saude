

namespace CentroSaudeProject.Classes
{
    public class Paciente
    {
        #region Atributos
        private static int _proximoId = 1; //Gera Id automaticamente
        private int _idPaciente;
        private string _nome;
        private int _idade;
        private char _sexo;
        private List<Consulta> _consultas; // Consultas associadas ao paciente
        #endregion

        #region Propriedades
        public int IdPaciente
        {
            get { return _idPaciente; }
            private set { _idPaciente = value; } //Id definido apenas pela classe
        }
        public string Nome
        {
            get { return _nome; }
            set {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Nome não pode ser vazio");
                _nome = value;
            }
        }
        public int Idade
        {
            get { return _idade; }
            set { 
                if (value<=0)
                    throw new Exception("Idade inválida");
                _idade = value;
            }
        }
        public char Sexo
        {
            get { return _sexo; }
            set {
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
        public Paciente(string nome, int idade, char sexo)
        {
            IdPaciente = _proximoId++;
            Nome = nome;
            Idade = idade;
            Sexo = sexo;
            _consultas = new List<Consulta>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// AdicionarConsulta
        /// </summary>
        public void AdicionarConsulta(Consulta consulta)
        {
            if (consulta== null)
                throw new Exception("Consulta inválida");
            _consultas.Add(consulta);
        }

        /// <summary>
        /// Remover Consulta
        /// </summary>
        public void RemoverConsulta(Consulta consulta)
        {
            if (!_consultas.Contains(consulta))
                throw new Exception("Consulta não está associada a este paciente");
            _consultas.Remove(consulta);
        }

        public override string ToString()
        {
            return $"Id: {IdPaciente} | Nome: {Nome} | Idade: {Idade} | Sexo: {Sexo}";
        }
        #endregion

        #region Destrutores
        ~Paciente()
        {
        }
        #endregion
    }
}
