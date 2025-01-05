using CentroSaudeProject.Enums;

namespace CentroSaudeProject.Classes
{
    public class Exame
    {
        #region Atributos
        private static int _proximoId = 1;
        private int _idExame;
        private DateTime _dataExame;
        private string _resultado;
        private TipoExame _tipo;
        private Medico _medicoResponsavel;
        #endregion

        #region Propriedades
        public int IdExame
        {
            get { return _idExame; }
            private set { _idExame = value; }
        }
        public DateTime DataExame
        {
            get { return _dataExame; }
            set { 
                if (value > DateTime.Now)
                    throw new Exception("Data do Exame errada");
                _dataExame = value;
            }
        }
        public string Resultado
        {
            get { return _resultado; }
            set { 
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Resultado do Exame não pode ser vazio");
                _resultado = value;
            }
        }
        public TipoExame Tipo
        {
            get { return _tipo; }
            set { 
                if (!Enum.IsDefined(typeof(TipoExame), value))
                    throw new Exception("Tipo de Exame não Existe");
                _tipo = value;
            }
        }
        public Medico MedicoResponsavel
        {
            get { return _medicoResponsavel; }
            private set { _medicoResponsavel = value; }
        }
        #endregion

        #region Construtores
        public Exame(DateTime dataExame, string resultado, TipoExame tipo)
        {
            IdExame = _proximoId++;
            DataExame = dataExame;
            Resultado = resultado;
            Tipo = tipo;
            MedicoResponsavel = null;  // Inicializa sem médico
        }
        #endregion

        #region Métodos
        // Método para associar o médico ao exame
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
            return $"Id: {IdExame} | Data: {DataExame} | Resultado: {Resultado} | Tipo: {Tipo} | Médico: {(MedicoResponsavel != null ? MedicoResponsavel._nome : "Não atribuído")}";
        }
        #endregion

        #region Destructor
        ~Exame()
        {
        }
        #endregion
    }
}
