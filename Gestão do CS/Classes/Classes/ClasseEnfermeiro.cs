namespace CentroSaudeProject.Classes
{
    public class Enfermeiro : Pessoa
    {
        #region Atributos

        private static int _proximoId = 1; 
        public readonly int IdEnfermeiro; 
        #endregion

        #region Construtores

        public Enfermeiro(string nome, int idade, int ccNum, int ccNIF, char sexo)
            : base(nome, idade, ccNum, ccNIF, sexo)
        {
            IdEnfermeiro = _proximoId++; 
        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return $"ID Enfermeiro: {IdEnfermeiro} | {base.ToString()}";
        }

        #endregion
    }
}
