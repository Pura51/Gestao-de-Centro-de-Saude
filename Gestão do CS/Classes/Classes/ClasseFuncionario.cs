using CentroSaudeProject.Enums;
using System;

namespace CentroSaudeProject.Classes
{
    public class Funcionario
    {
        public int Id { get; private set; }  // ID único para cada funcionário
        public string Nome { get; set; }
        public int Idade { get; set; }
        public Categoria Categoria { get; set; }

        private static int ProximoId = 1;  // Gerador automático de ID

        // Construtor
        public Funcionario(string nome, int idade, Categoria categoria)
        {
            Id = ProximoId++;  // Atribui um ID único para o funcionário
            Nome = nome;
            Idade = idade > 0 ? idade : throw new ArgumentException("Idade deve ser maior que zero.");
            Categoria = categoria;
        }

        // Método para atualizar a categoria do funcionário
        public void AtualizarCategoria(Categoria novaCategoria)
        {
            Categoria = novaCategoria;
        }

        // Método ToString para exibir informações do funcionário
        public override string ToString()
        {
            return $"ID: {Id} | Nome: {Nome} | Idade: {Idade} anos | Categoria: {Categoria}";
        }
    }
}
