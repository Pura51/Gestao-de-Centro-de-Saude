namespace CentroSaudeProject.Classes
{
    public class Medico : Pessoa
    {
        #region Atributos
        
        private static int _proximoId = 1; // Gera ID automaticamente
        private int _idMedico;

        #endregion

        #region Construtores

        // Construtor da classe Medico, chamando o construtor da classe base (Pessoa)
        public Medico(string nome, int idade, int ccNum, int ccNIF, char sexo)
            : base(nome, idade, ccNum, ccNIF, sexo)
        {
            _idMedico = _proximoId++;
        }

        #endregion

        #region Propriedades

        public int IdMedico
        {
            get { return _idMedico; }
        }

        #endregion

        #region Métodos

        // Método ToString para representar o médico como string
        public override string ToString()
        {
            return $"ID Médico: {IdMedico}, {base.ToString()}";
        }

        #endregion
    }
}
