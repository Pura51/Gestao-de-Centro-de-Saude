using CentroSaudeProject.Enums;

namespace CentroSaudeProject.Classes
{
    public class Funcionario
    {
        #region Atributos
        private static int _proximoId = 1; //Gera Id automaticamente
        private int _idFuncionario;
        private string _nome;
        private int _idade;
        private Categoria _categoria;
        #endregion

        #region Propriedades
        public int IdFuncionario
        {
            get { return _idFuncionario; }
            private set { _idFuncionario = value; } //Id definido apenas pela classe
        }
        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new Exception("Nome não pode ser vazio");
                _nome = value;
            }
        }
        public int Idade
        {
            get { return _idade; }
            set
            {
                if (value <= 0)
                    throw new Exception("Idade inválida");
                _idade = value;
            }
        }

        public Categoria Categoria
        {
            get { return _categoria; }
            set {
                if (!Enum.IsDefined(typeof(Categoria), value))
                    throw new Exception("Categoria não Existe");
                _categoria = value;
            }
        }

        #endregion

        #region Construtores
        public Funcionario(string nome, int idade, Categoria categoria)
        {
            IdFuncionario = _proximoId++;
            Nome = nome;
            Idade = idade;
            Categoria = categoria;
        }
        #endregion

        #region Metodos
        public override string ToString()
        {
            return $"Id: {IdFuncionario} | Nome: {Nome} | Idade: {Idade} | Categoria: {Categoria}";
        }
        #endregion

        #region Destrutores
        ~Funcionario()
        {
        }
        #endregion

    }
}




