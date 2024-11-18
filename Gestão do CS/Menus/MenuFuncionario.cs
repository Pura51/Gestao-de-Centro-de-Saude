using CentroSaudeProject.Classes;
using CentroSaudeProject.Enums;
using System;
using System.Collections.Generic;

namespace Menus.Menu
{
    public static class MenuFuncionarios
    {
        // Altere o método ExibirMenu para receber o objeto CentroSaude
        public static void ExibirMenu(CentroSaude centroSaude)
        {
            bool continuar = true;

            while (continuar)
            {
                Console.Clear();
                Console.WriteLine("=== Gestão de Funcionários ===");
                Console.WriteLine("1. Adicionar Funcionário");
                Console.WriteLine("2. Ver Funcionários");
                Console.WriteLine("0. Voltar ao Menu Principal");
                Console.Write("Escolha uma opção: ");

                string opcao = Console.ReadLine();

                switch (opcao)
                {
                    case "1":
                        AdicionarFuncionario(centroSaude);
                        break;
                    case "2":
                        VerFuncionarios(centroSaude);
                        break;
                    case "0":
                        continuar = false;
                        break;
                    default:
                        Console.WriteLine("Opção inválida. Pressione qualquer tecla para continuar...");
                        Console.ReadKey();
                        break;
                }
            }
        }

        // Alteração do método AdicionarFuncionario para receber CentroSaude como argumento
        private static void AdicionarFuncionario(CentroSaude centroSaude)
        {
            Console.Clear();
            Console.WriteLine("=== Adicionar Funcionário ===");

            Console.Write("Nome do Funcionário: ");
            string nome = Console.ReadLine();

            Console.Write("Idade do Funcionário: ");
            if (!int.TryParse(Console.ReadLine(), out int idade))
            {
                Console.WriteLine("Idade inválida. Pressione qualquer tecla para retornar ao menu.");
                Console.ReadKey();
                return;
            }

            Console.WriteLine("Escolha a Categoria:");
            foreach (var categoria in Enum.GetValues(typeof(Categoria)))
            {
                Console.WriteLine($"{(int)categoria}. {categoria}");
            }

            Console.Write("Digite o número correspondente à categoria: ");
            if (!int.TryParse(Console.ReadLine(), out int categoriaEscolhida) || !Enum.IsDefined(typeof(Categoria), categoriaEscolhida))
            {
                Console.WriteLine("Categoria inválida. Pressione qualquer tecla para retornar ao menu.");
                Console.ReadKey();
                return;
            }

            var funcionario = new Funcionario(nome, idade, (Categoria)categoriaEscolhida);
            centroSaude.AdicionarFuncionario(funcionario);

            Console.WriteLine($"Funcionário {nome} adicionado com sucesso! Pressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
        }

        // Alteração do método VerFuncionarios para receber CentroSaude como argumento
        private static void VerFuncionarios(CentroSaude centroSaude)
        {
            Console.Clear();
            Console.WriteLine("=== Lista de Funcionários ===");

            List<Funcionario> funcionarios = centroSaude.ObterFuncionarios();

            if (funcionarios.Count == 0)
            {
                Console.WriteLine("Nenhum funcionário cadastrado.");
            }
            else
            {
                foreach (var funcionario in funcionarios)
                {
                    Console.WriteLine(funcionario);
                }
            }

            Console.WriteLine("\nPressione qualquer tecla para retornar ao menu.");
            Console.ReadKey();
        }
    }
}
