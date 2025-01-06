using CentroSaudeProject.Enums;

namespace CentroSaudeProject.Classes
{
    public class Exame
    {
        #region Atributos
        private static int _proximoId = 1;
        public readonly int IdExame; // Atributo readonly
        private DateTime _dataExame;
        private string _resultado;
        private TipoExame _tipo;
        private Medico _medicoResponsavel;
        #endregion

        #region Propriedades
        public DateTime DataExame
        {
            get { return _dataExame; }
            private set
            {
                if (value > DateTime.Now)
                    throw new ArgumentException("Data do Exame não pode ser no futuro.");
                _dataExame = value;
            }
        }

        public string Resultado
        {
            get { return _resultado; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("Resultado do Exame não pode ser vazio.");
                _resultado = value;
            }
        }

        public TipoExame Tipo
        {
            get { return _tipo; }
            set
            {
                if (!Enum.IsDefined(typeof(TipoExame), value))
                    throw new ArgumentException("Tipo de Exame não existe.");
                _tipo = value;
            }
        }

        public Medico MedicoResponsavel
        {
            get { return _medicoResponsavel; }
            private set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(value), "O médico não pode ser nulo.");
                _medicoResponsavel = value;
            }
        }
        #endregion

        #region Construtores
        public Exame(DateTime dataExame, string resultado, TipoExame tipo, Medico medicoResponsavel)
        {
            IdExame = _proximoId++;
            DataExame = dataExame;
            Resultado = resultado;
            Tipo = tipo;
            MedicoResponsavel = medicoResponsavel ?? throw new ArgumentNullException(nameof(medicoResponsavel), "O médico não pode ser nulo.");
        }
        #endregion

        #region Métodos
        public void AssociarMedico(Medico medico)
        {
            if (medico == null)
            {
                throw new ArgumentNullException(nameof(medico), "O médico não pode ser nulo.");
            }
            MedicoResponsavel = medico;
        }

        public override string ToString()
        {
            return $"Id: {IdExame} | Data: {DataExame} | Resultado: {Resultado} | Tipo: {Tipo} | Médico: {MedicoResponsavel?.ToString() ?? "Não atribuído"}";
        }
        #endregion

        #region Destructor
        ~Exame()
        {
        }
        #endregion
    }
}
