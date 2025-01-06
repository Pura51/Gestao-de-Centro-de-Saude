namespace CentroSaudeProject.Classes
{
    public class Consulta
    {
        #region Atributos
        private static int _proximoId = 1;
        public readonly int IdConsulta; 
        private DateTime _dataConsulta;
        private float _custo;
        private string _diagnostico;
        private List<Exame> _exames; 
        private Medico _medico;
        #endregion

        #region Propriedades
        public DateTime DataConsulta
        {
            get { return _dataConsulta; }
            private set
            {
                if (value > DateTime.Now)
                    throw new Exception("Data da consulta não pode ser no futuro.");
                _dataConsulta = value;
            }
        }

        public float Custo
        {
            get { return _custo; }
            set
            {
                if (value < 0)
                    throw new Exception("O custo da consulta não pode ser negativo.");
                _custo = value;
            }
        }

        public string Diagnostico
        {
            get { return _diagnostico; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("O diagnóstico não pode ser vazio.");
                _diagnostico = value;
            }
        }

        public IReadOnlyList<Exame> Exames
        {
            get { return _exames.AsReadOnly(); }
        }

        public Medico Medico
        {
            get { return _medico; }
            private set
            {
                if (value == null)
                    throw new Exception("O médico não pode ser nulo.");
                _medico = value;
            }
        }
        #endregion

        #region Construtores
        public Consulta(DateTime dataConsulta, float custo, string diagnostico, Medico medico)
        {
            IdConsulta = _proximoId++;
            DataConsulta = dataConsulta;
            Custo = custo;
            Diagnostico = diagnostico;
            _exames = new List<Exame>();
            Medico = medico;
        }
        #endregion

        #region Métodos
        public void AdicionarExame(Exame exame)
        {
            if (_exames.Contains(exame))
                throw new InvalidOperationException("O exame já foi adicionado à consulta.");
            _exames.Add(exame);
        }

        public void RemoverExame(Exame exame)
        {
            if (!_exames.Contains(exame))
                throw new InvalidOperationException("O exame não foi adicionado à consulta.");
            _exames.Remove(exame);
        }

        public override string ToString()
        {
            return $"Id: {IdConsulta} | Médico: {_medico} | Data: {DataConsulta} | Custo: {Custo} | Diagnóstico: {Diagnostico}";
        }
        #endregion

        #region Destrutores
        ~Consulta()
        {
        }
        #endregion
    }
}
