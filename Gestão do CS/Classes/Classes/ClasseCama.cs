namespace CentroSaudeProject.Classes
{
    public class Cama
    {
        #region Atributos
        private static int _proximoId = 1;
        public readonly int IdCama; // Marcar como readonly, já que o ID não muda após a criação
        private int _numeroCama;
        private bool _disponivel;
        private Enfermeiro _enfermeiroResponsavel;
        #endregion

        #region Propriedades
        public int NumeroCama
        {
            get { return _numeroCama; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("Número da cama inválido.");
                _numeroCama = value;
            }
        }

        public bool Disponivel
        {
            get { return _disponivel; }
            private set { _disponivel = value; }
        }

        public Enfermeiro EnfermeiroResponsavel
        {
            get { return _enfermeiroResponsavel; }
            set
            {
                if (!Disponivel)
                    throw new InvalidOperationException("Não é possível atribuir um enfermeiro a uma cama ocupada.");
                _enfermeiroResponsavel = value;
            }
        }
        #endregion

        #region Construtores
        public Cama(int numeroCama, bool disponivel)
        {
            IdCama = _proximoId++; // Incrementa automaticamente o ID
            NumeroCama = numeroCama;
            Disponivel = disponivel;
        }
        #endregion

        #region Métodos
        /// <summary>
        /// Marca a cama como ocupada.
        /// </summary>
        public void Ocupar()
        {
            if (!Disponivel)
                throw new InvalidOperationException("A cama já está ocupada.");
            Disponivel = false;
        }

        /// <summary>
        /// Marca a cama como disponível.
        /// </summary>
        public void Libertar()
        {
            if (Disponivel)
                throw new InvalidOperationException("A cama já está disponível.");
            Disponivel = true;
            EnfermeiroResponsavel = null; // Libera o enfermeiro responsável quando a cama for liberada
        }

        public override string ToString()
        {
            return $"Id: {IdCama} | Número: {NumeroCama} | Disponível: {Disponivel} | Enfermeiro Responsável: {(_enfermeiroResponsavel?.Nome ?? "Nenhum")}";
        }
        #endregion

        #region Destrutores
        ~Cama()
        {
            // Destruição do objeto Cama se necessário
        }
        #endregion
    }
}
