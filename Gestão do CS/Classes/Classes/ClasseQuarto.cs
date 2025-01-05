namespace CentroSaudeProject.Classes
{
    public class Quarto
    {
        #region Atributos
        private static int _proximoId = 1; //Gera Id automaticamente
        private int _idQuarto;
        private int _numero;
        private bool _lotacao;
        private List<Enfermeiro> _enfermeiro;
        private List<Cama> _cama; // Associa camas ao quarto
        private const int MaxCamas = 2; // Numero maximo de camas
        private Enfermeiro _enfermeiroResponsavel;
        #endregion

        #region Propriedades
        public int IdQuarto
        {
            get { return _idQuarto; }
            private set { _idQuarto = value; } //Id definido apenas pela classe
        }

        public int Numero
        {
            get { return _numero; }
            set
            {
                if (value <= 0)
                    throw new Exception("Número do quarto inválido");
                _numero = value;
            }
        }
        public List<Cama> Camas
        {
            get { return _cama; }
        }
        public Enfermeiro EnfermeiroResponsavel
        {
            get { return _enfermeiroResponsavel; }
            set { _enfermeiroResponsavel = value; }
        }
        #endregion

        #region Construtores
        public Quarto(int numero)
        {
            IdQuarto = _proximoId++;
            Numero = numero;
            _cama = new List<Cama>();
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Adicionar cama ao quarto
        /// </summary>
        public void AdicionarCama(Cama cama)
        {
            if (_cama.Count >= MaxCamas)
                throw new Exception("Número máximo de camas atingido.");
            _cama.Add(cama);
        }

        /// </summary>
        /// Atribuir cama 
        /// </summary>
        public Cama AtribuirCama()
        {
            var camaDisponivel = Camas.FirstOrDefault(c => c.Disponivel);
            if (camaDisponivel == null)
                throw new Exception("Não há camas disponíveis neste quarto.");
            camaDisponivel.Ocupar();
            return camaDisponivel;
        }

        /// <summary>
        /// Remover cama do quarto
        /// </summary>
        public void RemoverCama(Cama cama)
        {
            if (!_cama.Contains(cama))
                throw new Exception("Cama não existe no quarto.");
            _cama.Remove(cama);
        }

        // Métodos para associar enfermeiros
        public void AtribuirEnfermeiro(Enfermeiro enfermeiro)
        {
            _enfermeiroResponsavel = enfermeiro;
        }

        public override string ToString()
        {
            return $"Quarto: {Numero}, Enfermeiro Responsável: {_enfermeiroResponsavel?._nome ?? "Nenhum"}";
        }

        
        #endregion

        #region Destrutores
        ~Quarto()
        {
        }
        #endregion
    }
}