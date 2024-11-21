namespace CentroSaudeProject.Classes
{
    public class Cama
    {
        #region Atributos
        private static int _proximoId = 1;
        private int _idCama;
        private int _numeroCama;
        private bool _disponivel;
        #endregion

        #region Propriedades
        public int IdCama
        {
            get { return _idCama; }
            private set { _idCama = value; }
        }
        public int NumeroCama
        {
            get { return _numeroCama; }
            set
            {
                if (value <= 0)
                    throw new Exception("Número da cama inválido");
                _numeroCama = value;
            }
        }
        public bool Disponivel
        {
            get { return _disponivel; }
            set { _disponivel = value; }
        }
        #endregion

        #region Construtores
        public Cama(int numeroCama, bool disponivel)
        {
            IdCama = _proximoId++;
            NumeroCama = numeroCama;
            Disponivel = disponivel;
        }
        #endregion

        #region Metodos
        /// <summary>
        /// Marca a cama como ocupada.
        /// </summary>
        public void Ocupar()
        {
            if (!_disponivel)
                throw new InvalidOperationException("A cama já está ocupada.");
            _disponivel = false;
        }

        /// <summary>
        /// Marca a cama como disponível.
        /// </summary>
        public void Libertar()
        {
            if (_disponivel)
                throw new InvalidOperationException("A cama já está disponível.");
            _disponivel = true;
        }

        public override string ToString()
        {
            return $"Id: {IdCama} | Numero: {NumeroCama} | Disponivel: {Disponivel}";
        }
        #endregion

        #region Destrutores
        ~Cama()
        {
        }
        #endregion
    }
}
