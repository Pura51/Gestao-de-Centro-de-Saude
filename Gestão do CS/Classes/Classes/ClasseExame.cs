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
        #endregion

        #region Construtores
        public Exame(DateTime dataExame, string resultado, TipoExame tipo)
        {
            IdExame = _proximoId++;
            DataExame = dataExame;
            Resultado = resultado;
            Tipo = tipo;
        }
        #endregion

        #region Metodos
        public override string ToString() {
            return $"Id: {IdExame} | Data: {DataExame} | Resultado: {Resultado} | Tipo: {Tipo}";
        }
        #endregion

        #region Destructor
        ~Exame()
        {
        }
        #endregion
    }
}
