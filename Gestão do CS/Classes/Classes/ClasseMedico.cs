namespace CentroSaudeProject.Classes
{
    public class Medico : Pessoa
    {
        #region Atributos
        private static int _proximoId = 1; 
        public readonly int IdMedico; 
        #endregion

        #region Construtores

        public Medico(string nome, int idade, int ccNum, int ccNIF, char sexo)
            : base(nome, idade, ccNum, ccNIF, sexo)
        {
            IdMedico = _proximoId++; 
        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return $"ID Médico: {IdMedico} | {base.ToString()}";
        }

        #endregion
    }
}
