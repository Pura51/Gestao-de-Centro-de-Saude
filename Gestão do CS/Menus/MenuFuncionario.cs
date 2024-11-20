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
        }

        // Alteração do método VerFuncionarios para receber CentroSaude como argumento
        private static void VerFuncionarios(CentroSaude centroSaude)
        {
        }
    }
}
