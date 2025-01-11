namespace CentroSaudeProject.Classes
{
    public class Quarto : IAdicionar<Cama>, IRemover<Cama>
    {
        #region Atributos
        private static int _proximoId = 1; // Gera Id automaticamente
        public readonly int IdQuarto; // ID definido apenas pela classe, readonly
        private int _numero;
        private List<Cama> _camas; // Associa camas ao quarto
        private const int MaxCamas = 2; // Número máximo de camas
        private Enfermeiro _enfermeiroResponsavel;
        #endregion

        #region Propriedades
        public int Numero
        {
            get { return _numero; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Número do quarto inválido.");
                _numero = value;
            }
        }

        public List<Cama> Camas
        {
            get { return _camas; }
        }

        public Enfermeiro EnfermeiroResponsavel
        {
            get { return _enfermeiroResponsavel; }
            set
            {
                if (value == null)
                    throw new ArgumentNullException(nameof(EnfermeiroResponsavel), "Enfermeiro responsável não pode ser nulo.");
                _enfermeiroResponsavel = value;
            }
        }
        #endregion

        #region Construtores
        public Quarto(int numero)
        {
            IdQuarto = _proximoId++;
            Numero = numero;
            _camas = new List<Cama>();
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Adiciona uma cama ao quarto.
        /// </summary>
        public void Adicionar(Cama cama)
        {
            if (_camas.Count >= MaxCamas)
                throw new InvalidOperationException("Número máximo de camas atingido.");
            _camas.Add(cama);
        }

        /// <summary>
        /// Atribui uma cama disponível ao quarto.
        /// </summary>
        public Cama AtribuirCama()
        {
            var camaDisponivel = _camas.FirstOrDefault(c => c.Disponivel);
            if (camaDisponivel == null)
                throw new InvalidOperationException("Não há camas disponíveis neste quarto.");
            camaDisponivel.Ocupar();
            return camaDisponivel;
        }

        /// <summary>
        /// Remove uma cama do quarto.
        /// </summary>
        public void Remover(Cama cama)
        {
            if (!_camas.Contains(cama))
                throw new InvalidOperationException("A cama não existe neste quarto.");
            _camas.Remove(cama);
        }

        /// <summary>
        /// Atribui um enfermeiro responsável ao quarto.
        /// </summary>
        public void AtribuirEnfermeiro(Enfermeiro enfermeiro)
        {
            if (enfermeiro == null)
                throw new ArgumentNullException(nameof(enfermeiro), "O enfermeiro não pode ser nulo.");
            _enfermeiroResponsavel = enfermeiro;
        }

        public override string ToString()
        {
            return $"Quarto: {Numero}, Enfermeiro Responsável: {_enfermeiroResponsavel?.Nome ?? "Nenhum"}";
        }
        #endregion

        #region Destrutores
        ~Quarto()
        {
            // Destruição do Quarto se necessário
        }
        #endregion
    }
}
