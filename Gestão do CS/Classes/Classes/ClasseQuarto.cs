using System;
using System.Collections.Generic;

namespace CentroSaudeProject.Classes
{
    public class Quarto
    {
        // Atributos
        public int Numero { get; set; } // Número identificador do quarto
        private List<Cama> Camas { get; set; } = new List<Cama>(); // Lista de camas no quarto (máx: 2)

        // Construtor
        public Quarto(int numero)
        {
            Numero = numero;
        }

        // Método para adicionar uma cama ao quarto
        public bool AdicionarCama(Cama cama)
        {
            if (Camas.Count >= 2)
            {
                Console.WriteLine($"O quarto {Numero} já atingiu o limite de 2 camas.");
                return false; // Indica falha ao adicionar a cama
            }

            Camas.Add(cama);
            Console.WriteLine($"Cama adicionada com sucesso ao quarto {Numero}.");
            return true; // Indica sucesso
        }

        // Método para verificar se o quarto está cheio
        public bool EstaCheio()
        {
            return Camas.Count == 2;
        }

        // Método para remover uma cama do quarto
        public bool RemoverCama(int numeroCama)
        {
            var cama = Camas.Find(c => c.Id == numeroCama);
            if (cama == null)
            {
                Console.WriteLine($"Cama {numeroCama} não encontrada no quarto {Numero}.");
                return false; // Indica falha na remoção
            }

            Camas.Remove(cama);
            Console.WriteLine($"Cama {numeroCama} removida com sucesso do quarto {Numero}.");
            return true; // Indica sucesso na remoção
        }

        // Método para obter as camas no quarto
        public List<Cama> ObterCamas()
        {
            return Camas;
        }

        // Método para exibir informações sobre o quarto
        public override string ToString()
        {
            string camasInfo = Camas.Count == 0
                ? "Sem camas"
                : string.Join(", ", Camas.ConvertAll(c => $"Cama {c.Id} ({(c.Disponivel ? "Disponível" : "Ocupada")})"));

            return $"Quarto {Numero}: {camasInfo}";
        }
    }
}
