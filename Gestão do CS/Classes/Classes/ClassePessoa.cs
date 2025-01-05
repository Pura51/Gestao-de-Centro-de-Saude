using System;
using System.Collections.Generic;

namespace CentroSaudeProject.Classes
{
    public abstract class Pessoa
    {
        #region Atributos
        
        public string _nome;

        public int _idade;

        public int _ccNum;

        public int _ccNIF;

        public char _sexo;

        #endregion

        #region Construtores

        // Construtor da classe Pessoa, agora abstrata
        public Pessoa(string nome, int idade, int ccNum, int ccNIF, char sexo)
        {
            _nome = nome;
            _idade = idade;
            _ccNum = ccNum;
            _ccNIF = ccNIF;
            _sexo = sexo;
        }

        #endregion

        #region Métodos

        // Método ToString para representar a pessoa como string
        public override string ToString()
        {
            return $"Nome: {_nome}, Idade: {_idade}, CC: {_ccNum}, NIF: {_ccNIF}, Sexo: {_sexo}";
        }

        #endregion

        
    }
        
}
