namespace CentroSaudeProject.Classes
{
    public class Consulta
    {
        #region Atributos
        private static int _proximoId = 1;
        private int _idConsulta;
        private DateTime _dataConsulta;
        private float _custo;
        private string _diagnostico;
        private List<Exame> _exames; // Exames associados à consulta
        private List<Medico> _medico;

        #endregion

        #region Propriedades
        public int IdConsulta
        {
            get { return _idConsulta; }
            private set { _idConsulta = value; }
        }
        public DateTime DataConsulta
        {
            get { return _dataConsulta; }
            set
            {
                if (value > DateTime.Now)
                    throw new Exception("Data da Consulta errada");
                _dataConsulta = value;
            }
        }
        public float Custo
        {
            get { return _custo; }
            set
            {
                if (value < 0)
                    throw new Exception("Custo da Consulta não pode ser negativo");
                _custo = value;
            }
        }
        public string Diagnostico
        {
            get { return _diagnostico; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Diagnostico da Consulta não pode ser vazio");
                _diagnostico = value;
            }
        }

        public List<Exame> Exames
        {
            get { return _exames; }
        }
        #endregion

        #region Construtores
        public Consulta(DateTime dataConsulta, float custo, string diagnostico)
        {
            IdConsulta = _proximoId++;
            DataConsulta = dataConsulta;
            Custo = custo;
            Diagnostico = diagnostico;
            _exames = new List<Exame>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Adiciona um exame à consulta.
        /// </summary>
        public void AdicionarExame(Exame exame)
        {
            if (_exames.Contains(exame))
                throw new InvalidOperationException("O exame já foi adicionado à consulta.");
            _exames.Add(exame);
        }
        /// <summary>
        /// Remove um exame da consulta.
        /// </summary>
        public void RemoverExame(Exame exame)
        {
            if (!_exames.Contains(exame))
                throw new InvalidOperationException("O exame não foi adicionado à consulta.");
            _exames.Remove(exame);
        }

        public override string ToString()
        {
            return $"Id: {IdConsulta} | Data: {DataConsulta} | Custo: {Custo} | Diagnostico: {Diagnostico}";
        }
        #endregion

        #region Destrutores
        ~Consulta()
        {
        }
        #endregion
    }
}