using System;

namespace CentroSaudeProject.Classes
{
    public abstract class Pessoa
    {
        #region Atributos

        private string _nome;
        private int _idade;
        private int _ccNum;
        private int _ccNIF;
        private char _sexo;

        #endregion

        #region Propriedades

        public string Nome
        {
            get { return _nome; }
            set
            {
                if (string.IsNullOrWhiteSpace(value))
                    throw new ArgumentException("O nome não pode ser vazio ou nulo.");
                _nome = value;
            }
        }

        public int Idade
        {
            get { return _idade; }
            set
            {
                if (value < 0)
                    throw new ArgumentException("A idade não pode ser negativa.");
                _idade = value;
            }
        }

        public int CCNum
        {
            get { return _ccNum; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O número de CC tem de ser positivo.");
                _ccNum = value;
            }
        }

        public int CCNIF
        {
            get { return _ccNIF; }
            set
            {
                if (value <= 0)
                    throw new ArgumentException("O NIF tem de ser positivo.");
                _ccNIF = value;
            }
        }

        public char Sexo
        {
            get { return _sexo; }
            set
            {
                if (value != 'M' && value != 'F')
                    throw new ArgumentException("Use os seguintes caracteres 'M' ou 'F'.");
                _sexo = value;
            }
        }

        #endregion

        #region Construtores

        public Pessoa(string nome, int idade, int ccNum, int ccNIF, char sexo)
        {
            Nome = nome;
            Idade = idade;
            CCNum = ccNum;
            CCNIF = ccNIF;
            Sexo = sexo;
        }

        #endregion

        #region Métodos

        public override string ToString()
        {
            return $"Nome: {Nome}, Idade: {Idade}, CC: {CCNum}, NIF: {CCNIF}, Sexo: {Sexo}";
        }

        #endregion
    }
}
