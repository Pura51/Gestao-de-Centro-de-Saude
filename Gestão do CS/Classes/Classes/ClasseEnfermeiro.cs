namespace CentroSaudeProject.Classes
{
    public class Enfermeiro : Pessoa
    {
        #region Atributos
        
        private static int _proximoId = 1; // Gera ID automaticamente
        private int _idEnfermeiro;

        #endregion

        #region Construtores

        // Construtor da classe Enfermeiro, chamando o construtor da classe base (Pessoa)
        public Enfermeiro(string nome, int idade, int ccNum, int ccNIF, char sexo)
            : base(nome, idade, ccNum, ccNIF, sexo)
        {
            _idEnfermeiro = _proximoId++;
        }

        #endregion

        #region Propriedades

        public int IdEnfermeiro
        {
            get { return _idEnfermeiro; }
        }

        #endregion

        #region Métodos

        // Método ToString para representar o enfermeiro como string
        public override string ToString()
        {
            return $"ID Enfermeiro: {IdEnfermeiro}, {base.ToString()}";
        }

        #endregion
    }
}
